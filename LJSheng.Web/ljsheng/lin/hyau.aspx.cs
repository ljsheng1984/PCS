using System;
using System.Linq;
using LJSheng.Data.EF;
using System.IO;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class hyau : CheckLoginPage
    {
        string path = Data.Helps.huiyuan;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                EFDB db = new EFDB();
                Guid gid = Guid.Parse(Request.QueryString["gid"]);
                var b = db.huiyuan.Where(l => l.gid == gid).FirstOrDefault();
                if (b != null)
                {
                    zhanghao.Disabled = true;
                    zhanghao.Value = b.shouji;
                    mima.Value = b.mima;
                    shouji.Value = b.shouji;
                    xbRB.Items.FindByValue(b.xb.ToString()).Selected = true;
                    nicheng.Value = b.nicheng;
                    xingming.Value = b.xingming;
                    fmlogo.Src = path + b.tupian;
                }
            }
        }

        protected void tijiao_Click(object sender, EventArgs e)
        {
            EFDB db = new EFDB();
            string tp = Common.UploadImg.UPimg("", tupian, path);
            if (!String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                Guid gid = Guid.Parse(Request.QueryString["gid"]);
                //更新操作
                var b = db.huiyuan.Where(l => l.gid == gid).FirstOrDefault();
                b.shouji = shouji.Value.Trim();
                if (b.mima != mima.Value.Trim())
                {
                    b.mima = Common.MD5.GetMD5ljsheng(mima.Value);
                }
                b.xingming = xingming.Value;
                b.nicheng = nicheng.Value;
                if (!string.IsNullOrEmpty(tp))
                {
                    if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(path + b.tupian)))
                    {
                        File.Delete(System.Web.HttpContext.Current.Server.MapPath(path + b.tupian));
                    }
                    b.tupian = tp;
                }
                b.xb = byte.Parse(xbRB.SelectedValue);
                if (db.SaveChanges() == 1)
                {
                    Common.JS.AlertAndRedirect("操作成功", "hylist.aspx", this);
                }
                else
                {
                    Common.JS.Alert("操作失败,你可能更改的数据和旧数据一样,请重试.", this);
                }
            }
            else
            {
                if (db.huiyuan.Where(l => l.zhanghao == zhanghao.Value.Trim()).Count() > 0)
                {
                    Common.JS.Alert("帐号已存在", this);
                    return;
                }
                //增加操作
                Guid gid = Guid.NewGuid();
                DateTime? dt = null;
                if (!String.IsNullOrEmpty(csrq.Value))
                {
                    dt = DateTime.Parse(csrq.Value);
                }
                var b = new huiyuan
                {
                    gid = gid,
                    zhanghao = zhanghao.Value.Trim(),
                    tupian = tp,
                    shouji = shouji.Value,
                    mima = Common.MD5.GetMD5ljsheng(mima.Value),
                    xingming = xingming.Value,
                    nicheng = nicheng.Value,
                    xb = byte.Parse(xbRB.SelectedValue),
                    rukusj = DateTime.Now
                };

                db.huiyuan.Add(b);
                if (db.SaveChanges() == 1)
                {
                    if (!String.IsNullOrEmpty(tupian.Value))
                    {
                        Common.UploadImg.UPimg(gid.ToString(), tupian, path);
                    }
                    Common.JS.AlertAndRedirect("操作成功", "hylist.aspx", this);
                }
                else
                {
                    File.Delete(System.Web.HttpContext.Current.Server.MapPath(path + tp));
                    Common.JS.Alert("操作失败,请重试", this);
                }
            }
        }
    }
}