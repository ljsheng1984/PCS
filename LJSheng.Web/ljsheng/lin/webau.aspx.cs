using System;
using System.Linq;
using LJSheng.Data.EF;
using EntityFramework.Extensions;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class webau : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["gid"]))
                {
                    EFDB db = new EFDB();
                    Guid gid = Guid.Parse(Request.QueryString["gid"]);
                    var b = db.webmb.Where(l => l.gid == gid).FirstOrDefault();
                    if (b != null)
                    {
                        url.Value = b.url;
                        weihai.Value = b.weihai.ToString();
                        ztRB.Items.FindByValue(b.zt.ToString()).Selected = true;
                    }
                }
            }
        }

        protected void tijiao_Click(object sender, EventArgs e)
        {
            EFDB db = new EFDB();
            webmb ef;
            if (String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                ef = new webmb();
                ef.gid = Guid.NewGuid();
                ef.rukusj = DateTime.Now;
            }
            else
            {
                Guid gid = Guid.Parse(Request.QueryString["gid"]);
                ef = db.webmb.Where(l => l.gid == gid).FirstOrDefault();
            }
            ef.url = url.Value;
            ef.weihai = int.Parse(weihai.Value);
            ef.zt = int.Parse(ztRB.SelectedValue);
            if (String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                db.webmb.Add(ef);
            }
            if (db.SaveChanges() == 1)
            {
                db.zdlb.Where(l => l.jian == "webmb").Update(l => new zdlb { zhi = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });
                Common.JS.Alert("操作成功", this);
            }
            else
            {
                Common.JS.Alert("操作失败,你可能更改的数据和旧数据一样,请重试!", this);
            }
        }
    }
}