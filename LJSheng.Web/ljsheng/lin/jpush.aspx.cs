using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using LJSheng.Data.EF;
using EntityFramework.Extensions;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class jpush : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                where();
            }
        }
        //数据绑定
        private void Bind()
        {
            LVljsheng.DataSource = Data.Tables.Table_List("jpush", "rukusj DESC", "*", 88888, 1, ViewState["where"].ToString());
            LVljsheng.DataBind();
        }

        //listviet操作
        protected void LVljsheng_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            EFDB db = new EFDB();
            Guid gid = Guid.Parse(((Label)e.Item.FindControl("gid")).Text);
            switch (e.CommandName)
            {
                case "del":
                    if (db.jpush.Where(l => l.gid == gid).Delete() <= 0)
                    {
                        Common.JS.Alert("删除失败,请重试", this);
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
        protected void where()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["lx"]))
            {
                if (Request.QueryString["lx"] == "3")
                {
                    ViewState["where"] = "lx=3";
                }
                else
                {
                    ViewState["where"] = "lx!=3";
                }
            }
            else
            {
                ViewState["where"] = "";
            }
        }
        protected void sel_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (GMDDL.SelectedValue != "0")
            {
                sb.Append(" AND lx = " + GMDDL.SelectedValue);
            }
            if (!string.IsNullOrEmpty(alias.Value.Trim()))
            {
                sb.Append(" AND alias like '%" + alias.Value.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(registrationid.Value.Trim()))
            {
                sb.Append(" AND registrationid like '%" + registrationid.Value.Trim() + "%'");
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
            where();
            if (String.IsNullOrEmpty(ViewState["where"].ToString()))
            {
                ViewState["where"] = sb.ToString().TrimStart(" AND ".ToCharArray());
            }
            else
            {
                ViewState["where"] += sb.ToString();
            }
        }
    }
}