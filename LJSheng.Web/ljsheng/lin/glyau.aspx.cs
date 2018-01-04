using System;
using System.Linq;
using LJSheng.Data.EF;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class glyau : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                EFDB db = new EFDB();
                Guid gid = Guid.Parse(Request.QueryString["gid"]);
                var b = db.ljsheng.Where(l => l.gid == gid).FirstOrDefault();
                if (b != null)
                {
                    zhanghao.Disabled = true;
                    zhanghao.Value = b.zhanghao;
                    mima.Value = b.mima;
                }
            }
        }

        protected void tijiao_Click(object sender, EventArgs e)
        {
            EFDB db = new EFDB();
            if (!String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                //更新操作
                Guid gid = Guid.Parse(Request.QueryString["gid"]);
                if (db.ljsheng.Where(l => l.zhanghao == zhanghao.Value.Trim()&& l.gid!=gid).Count() > 0)
                {
                    Common.JS.Alert("登录名已存在", this);
                    return;
                }
                var b = db.ljsheng.Where(l => l.gid == gid).FirstOrDefault();
                b.zhanghao = zhanghao.Value.Trim();
                if (b.mima != mima.Value.Trim())
                {
                    b.mima = Common.MD5.GetMD5ljsheng(mima.Value);
                }
                if (db.SaveChanges() == 1)
                {
                    Common.JS.AlertAndRedirect("操作成功", "glylist.aspx", this);
                }
                else
                { Common.JS.Alert("操作失败,你可能更改的数据和旧数据一样,请重试", this); }
            }
            else
            {
                //增加操作
                if (db.ljsheng.Where(l => l.zhanghao == zhanghao.Value.Trim()).Count() > 0)
                {
                    Common.JS.Alert("登录名已存在", this);
                    return;
                }
                var b = new LJSheng.Data.EF.ljsheng
                {
                    gid = Guid.NewGuid(),
                    zhanghao = zhanghao.Value.Trim(),
                    mima = Common.MD5.GetMD5ljsheng(mima.Value),
                    rukusj = DateTime.Now
                };

                db.ljsheng.Add(b);
                if (db.SaveChanges() == 1)
                {
                    Common.JS.AlertAndRedirect("操作成功", "glylist.aspx", this);
                }
                else
                { Common.JS.Alert("操作失败,请重试", this); }
            }
        }
    }
}