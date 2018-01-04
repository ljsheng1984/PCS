using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using LJSheng.Data.EF;
using EntityFramework.Extensions;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class yhklist : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["where"] = "";
            }
        }

        private void Bind()
        {
            LVljsheng.DataSource = Data.Tables.Table_List("yhkmb", "rukusj DESC", "*", 88888, 1, ViewState["where"].ToString());
            LVljsheng.DataBind();
        }

        protected void LVljsheng_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            EFDB db = new EFDB();
            Guid gid = Guid.Parse(((Label)e.Item.FindControl("gid")).Text);
            var b = db.yhkmb.Where(l => l.gid == gid).FirstOrDefault();
            switch (e.CommandName)
            {
                case "del":
                    if (db.yhkmb.Where(l => l.gid == gid).Delete() != 1)
                    {
                        Common.JS.Alert("删除失败,请重试", this);
                    }
                    break;
                case "zt":
                    b.zt = e.CommandArgument.ToString() == "1" ? 2 : 1;
                    if (db.SaveChanges() != 1)
                    {
                        Common.JS.Alert("更新失败,请重试", this);
                    }
                    break;
                default:
                    break;
            }
            Bind();
        }

        protected void pager_PreRender(object sender, EventArgs e)
        {
            Bind();
        }

        protected void sel_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(yhk.Value.Trim()))
            {
                sb.Append(" AND yhk like '%" + yhk.Value.Trim() + "%'");
            }
            if (ztDDL.SelectedValue != "0")
            {
                sb.Append(" AND zt = " + ztDDL.SelectedValue);
            }
            //根据开始时间和结束时间查询
            if (!string.IsNullOrEmpty(kssj.Value) || !string.IsNullOrEmpty(jssj.Value))
            {
                //开始时间不为空
                if (!string.IsNullOrEmpty(kssj.Value) && string.IsNullOrEmpty(jssj.Value))
                {
                    jssj.Value = kssj.Value;
                }
                else if (!string.IsNullOrEmpty(jssj.Value) && string.IsNullOrEmpty(kssj.Value))
                {
                    kssj.Value = jssj.Value;
                }
                sb.Append(" AND rukusj >= '" + kssj.Value + " 00:00:00' AND rukusj <= '" + jssj.Value + " 23:59:59" + "'");
            }
            ViewState["where"] = sb.ToString().TrimStart(" AND ".ToCharArray());
        }
    }
}