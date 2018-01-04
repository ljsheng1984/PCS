using LJSheng.Data.EF;
using System;
using System.Linq;

namespace LJSheng.Web.app
{
    public partial class hd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["gid"]))
                {
                    LJSheng.Common.JS.Alert("未能获取你的信息,请重新打开APP", this);
                }
                else
                {
                    Guid hygid = Guid.Parse(Request.QueryString["gid"]);
                    EFDB db = new EFDB();
                    var b = db.huiyuan.Where(l => l.gid == hygid).FirstOrDefault();
                    if (b != null)
                    {
                        xingming.Text = b.xingming;
                        shouji.Text = b.shouji;
                    }
                }
            }
        }

        protected void tijiao_Click(object sender, EventArgs e)
        {
            Guid? hygid = Guid.Parse(Request.QueryString["gid"]);
            EFDB db = new EFDB();
            var hy = db.huiyuan.Where(l => l.gid == hygid).FirstOrDefault();
            if (hy != null)
            {
                if (hy.shouji != shouji.Text || hy.xingming != xingming.Text)
                {
                    hy.xingming = xingming.Text;
                    hy.shouji = shouji.Text;
                    if (db.SaveChanges() == 1)
                    {
                        LJSheng.Common.JS.Alert("登记资料成功", this);
                    }
                    else
                    {
                        LJSheng.Common.JS.Alert("登记资料失败", this);
                    }
                }
            }
            else
            {
                LJSheng.Common.JS.Alert("未能获取你的微信登录信息,请取消关注在关注", this);
            }
        }
    }
}