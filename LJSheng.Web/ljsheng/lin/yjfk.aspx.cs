using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using LJSheng.Data.EF;
using EntityFramework.Extensions;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class yjfk : CheckLoginPage
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
            LVljsheng.DataSource = Data.Tables.Table_List("yjfk", "zt DESC", "*",88888,1, ViewState["where"].ToString());
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
                    if (db.yjfk.Where(l => l.gid == gid).Delete() != 1)
                    {
                        Common.JS.Alert("删除失败,请重试", this);
                    }
                    else
                    {
                        if (db.yjtp.Where(l => l.yjgid == gid).Delete() < 0)
                        {
                            Common.JS.Alert("删除反馈图片失败,请重试", this);
                        }
                    }
                    break;
                case "hf":
                    if (db.yjfk.Where(l => l.gid == gid).Update(l => new Data.EF.yjfk { huifu = ((TextBox)e.Item.FindControl("huifu")).Text, zt = 1, hfsj = DateTime.Now }) != 1)
                    {
                        Common.JS.Alert("回复失败,请重试", this);
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
            if (ztDDL.SelectedValue != "0")
            {
                sb.Append(" AND zt = '" + ztDDL.SelectedValue + "'");
            }
            if (!string.IsNullOrEmpty(wenti.Value.Trim()))
            {
                sb.Append(" AND wenti like '%" + wenti.Value.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(huifu.Value.Trim()))
            {
                sb.Append(" AND huifu like '%" + huifu.Value.Trim() + "%'");
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