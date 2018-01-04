using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using LJSheng.Data.EF;
using EntityFramework.Extensions;
using System.Collections.Generic;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class dxlist : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdxlx();
                ViewState["where"] = "";
            }
        }
        /// <summary>
        /// 获取防骗短信类型
        /// </summary>
        public void getdxlx()
        {
            List<object> list = new List<object>();
            lxDDL.Items.Add(new ListItem("=全 部=", "0"));
            foreach (string n in Enum.GetNames(typeof(Data.Helps.dxlx)))
            {
                Data.Helps.dxlx lx = (Data.Helps.dxlx)Enum.Parse(typeof(Data.Helps.dxlx), n, true);
                lxDDL.Items.Add(new ListItem(n, ((int)lx).ToString()));
            }
        }
        private void Bind()
        {
            LVljsheng.DataSource = Data.Tables.Table_List("dxmb", "rukusj DESC", "*", 88888, 1, ViewState["where"].ToString());
            LVljsheng.DataBind();
        }
        protected void LVljsheng_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            EFDB db = new EFDB();
            Guid gid = Guid.Parse(((Label)e.Item.FindControl("gid")).Text);
            var b = db.dxmb.Where(l => l.gid == gid).FirstOrDefault();
            switch (e.CommandName)
            {
                case "del":
                    if (db.dxmb.Where(l => l.gid == gid).Delete() != 1)
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
            if (!string.IsNullOrEmpty(duanxin.Value.Trim()))
            {
                sb.Append(" AND (duanxin like '%" + duanxin.Value + "%' OR gjz like '%" + duanxin.Value + "%')");
            }
            if (lxDDL.SelectedValue != "0")
            {
                sb.Append(" AND lx = " + lxDDL.SelectedValue);
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