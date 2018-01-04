using System;
using System.Linq;
using LJSheng.Data.EF;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class appau : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                EFDB db = new EFDB();
                Guid gid = Guid.Parse(Request.QueryString["gid"]);
                var b = db.app.Where(l => l.gid == gid).FirstOrDefault();
                if (b != null)
                {
                    sjRB.Items.FindByValue(b.sjxt.ToString()).Selected = true;
                    gxRB.Items.FindByValue(b.sfgx.ToString()).Selected = true;
                    bbh.Value = b.bbh.ToString();
                    nbbbh.Value = b.nbbbh.ToString();
                    gxnr.Value = b.gxnr;
                    //url.Value = b.url;
                }
            }
        }

        protected void tijiao_Click(object sender, EventArgs e)
        {
            EFDB db = new EFDB();
            byte xt = byte.Parse(sjRB.SelectedValue);
            byte gx = byte.Parse(gxRB.SelectedValue);
            string app = "";
            //上传APP文件
            if (file.PostedFile.ContentLength != 0)
            {
                LJSheng.Common.UploadFile up = new Common.UploadFile();
                up.ExecUploadFile(System.Web.HttpContext.Current.Server.MapPath("/uploadfiles/app/"), file);
                if (up.UploadState == 0)
                {
                    app = up.NewFileName;
                }
            }
            if (!String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                //更新操作
                Guid gid = Guid.Parse(Request.QueryString["gid"]);
                if (db.app.Where(l => l.sjxt == xt && l.gid != gid).Count() > 0)
                {
                    Common.JS.Alert("此系统已存在", this);
                    return;
                }
                var b = db.app.Where(l => l.gid == gid).FirstOrDefault();
                b.sjxt = xt;
                b.sfgx = gx;
                b.gxnr = gxnr.Value;
                b.bbh = bbh.Value;
                b.nbbbh = int.Parse(nbbbh.Value);
                b.url = url.Value + app;
                b.rukusj = DateTime.Now;
                if (db.SaveChanges() == 1)
                {
                    Common.JS.AlertAndRedirect("操作成功", "applist.aspx", this);
                }
                else
                { Common.JS.Alert("操作失败,你可能更改的数据和旧数据一样,请重试", this); }
            }
            else
            {
                //增加操作
                if (db.app.Where(l => l.sjxt == xt).Count() > 0)
                {
                    Common.JS.Alert("此系统已存在", this);
                    return;
                }
                var b = new LJSheng.Data.EF.app
                {
                    gid = Guid.NewGuid(),
                    sjxt = xt,
                    sfgx = gx,
                    gxnr = gxnr.Value,
                    bbh = bbh.Value,
                    nbbbh = int.Parse(nbbbh.Value),
                    url = url.Value + app,
                    rukusj = DateTime.Now
                };

                db.app.Add(b);
                if (db.SaveChanges() == 1)
                {
                    Common.JS.AlertAndRedirect("操作成功", "applist.aspx", this);
                }
                else
                { Common.JS.Alert("操作失败,请重试", this); }
            }
        }
    }
}