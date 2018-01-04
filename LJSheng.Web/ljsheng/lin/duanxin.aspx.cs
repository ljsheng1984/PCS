using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using LJSheng.Data.EF;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class duanxin : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["where"] = "";
            }
        }

        //数据绑定
        private void Bind()
        {
            LVljsheng.DataSource = Data.Tables.Table_List("duanxin", "rukusj DESC", "*",88888,1, ViewState["where"].ToString());
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
                    LJSheng.Data.EF.duanxin b = db.duanxin.Where(l => l.gid == gid).FirstOrDefault();
                    db.duanxin.Attach(b);
                    db.duanxin.Remove(b);
                    if (db.SaveChanges() != 1)
                    {
                        Common.JS.Alert("删除失败,请重试", this);
                    }
                    break;
                case "send":
                    if (linjiansheng.dx(((Label)e.Item.FindControl("shouji")).Text, ((Label)e.Item.FindControl("dxnr")).Text, (byte)int.Parse(((Label)e.Item.FindControl("lx")).Text)) != 200)
                    {
                        Common.JS.Alert("发送失败", this);
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
            if (lxDDL.SelectedValue != "0")
            {
                sb.Append(" AND lx = '" + lxDDL.SelectedValue + "'");
            }
            if (!string.IsNullOrEmpty(shouji.Value.Trim()))
            {
                sb.Append(" AND shouji like '%" + shouji.Value.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(dxnr.Value.Trim()))
            {
                sb.Append(" AND dxnr like '%" + dxnr.Value.Trim() + "%'");
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