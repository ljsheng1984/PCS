using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using LJSheng.Data.EF;
using EntityFramework.Extensions;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class zdlist : CheckLoginPage
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
            LVljsheng.DataSource = Data.Tables.Table_List("zdlb", "px DESC", "*", 88888, 1, ViewState["where"].ToString());
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
                    if (db.zdlb.Where(l => l.gid == gid).Delete() != 1)
                    {
                        Common.JS.Alert("删除失败,请重试", this);
                    }
                    break;
                case "up":
                    //string jian = ((TextBox)e.Item.FindControl("jian")).Text;
                    string zhi = ((TextBox)e.Item.FindControl("zhi")).Text;
                    string jshao = ((TextBox)e.Item.FindControl("jshao")).Text;
                    byte px = byte.Parse(((TextBox)e.Item.FindControl("px")).Text);
                    if (db.zdlb.Where(l => l.gid == gid).Update(l => new LJSheng.Data.EF.zdlb {zhi = zhi, jshao = jshao, px = px }) != 1)
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
        protected void where()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                ViewState["where"] = "zdgid='" + Request.QueryString["gid"] + "'";
            }
            else
            {
                ViewState["where"] = "";
            }
        }
        protected void sel_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(j.Value.Trim()))
            {
                sb.Append(" AND jian like '%" + j.Value.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(z.Value.Trim()))
            {
                sb.Append(" AND zhi like '%" + z.Value.Trim() + "%'");
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

        protected void ok_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(jian.Value) && !string.IsNullOrEmpty(zhi.Value) && !string.IsNullOrEmpty(jshao.Value) && !string.IsNullOrEmpty(px.Value))
            {
                EFDB db = new EFDB();
                if (db.zdlb.Where(l => l.jian.Equals(jian.Value)).Count() < 1)
                {
                    zdlb ef = new zdlb();
                    ef.gid = Guid.NewGuid();
                    ef.zdgid = Guid.Parse(Request.QueryString["gid"]);
                    ef.jian = jian.Value;
                    ef.zhi = zhi.Value;
                    ef.jshao = jshao.Value;
                    ef.px = byte.Parse(px.Value);
                    ef.rukusj = DateTime.Now;
                    db.zdlb.Add(ef);
                    if (db.SaveChanges() != 1)
                    {
                        Common.JS.Alert("增加失败", this);
                    }
                }
                else
                {
                    Common.JS.Alert("已存在键名", this);
                }
            }
            else
            {
                Common.JS.Alert("所有内容必须填写", this);
            }
        }
    }
}