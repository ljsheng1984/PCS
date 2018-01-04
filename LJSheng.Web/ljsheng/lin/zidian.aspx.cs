using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using LJSheng.Data.EF;
using EntityFramework.Extensions;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class zidian : CheckLoginPage
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
            LVljsheng.DataSource = Data.Tables.Table_List("zidian", "px DESC", "*", 88888, 1, ViewState["where"].ToString());
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
                    if (db.zidian.Where(l => l.gid == gid).Delete() != 1)
                    {
                        Common.JS.Alert("删除失败,请重试", this);
                    }
                    else
                    {
                        db.zdlb.Where(l => l.zdgid == gid).Delete();
                    }
                    break;
                case "up":
                    //string zdlx = ((TextBox)e.Item.FindControl("zdlx")).Text;
                    string jshao = ((TextBox)e.Item.FindControl("jshao")).Text;
                    byte px = byte.Parse(((TextBox)e.Item.FindControl("px")).Text);
                    if (db.zidian.Where(l => l.gid == gid).Update(l=>new LJSheng.Data.EF.zidian {jshao=jshao,px=px}) != 1)
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
            if (!string.IsNullOrEmpty(zd.Value.Trim()))
            {
                sb.Append(" AND zdlx like '%" + zd.Value.Trim() + "%'");
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

        protected void ok_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(zdlx.Value) && !string.IsNullOrEmpty(jshao.Value) && !string.IsNullOrEmpty(px.Value))
            {
                EFDB db = new EFDB();
                if (db.zidian.Where(l => l.zdlx.Equals(zdlx.Value)).Count() < 1)
                {
                    Data.EF.zidian ef = new Data.EF.zidian();
                    ef.gid = Guid.NewGuid();
                    ef.zdlx = zdlx.Value;
                    ef.jshao = jshao.Value;
                    ef.px = byte.Parse(px.Value);
                    ef.rukusj = DateTime.Now;
                    db.zidian.Add(ef);
                    if (db.SaveChanges() != 1)
                    {
                        Common.JS.Alert("增加失败", this);
                    }
                }
                else
                {
                    Common.JS.Alert("字典类型已存在", this);
                }
            }
            else
            {
                Common.JS.Alert("所有内容必须填写", this);
            }
        }
    }
}