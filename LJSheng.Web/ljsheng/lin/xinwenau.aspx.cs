using System;
using System.Linq;
using LJSheng.Data.EF;
using System.IO;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class xinwenau : CheckLoginPage
    {
        public string path = Data.Helps.xinwen;
        public string nrong;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                //设置编辑器上传图片的路径
                Common.LCookie.AddCookie("bdpath", "xinwen", 0);
                EFDB db = new EFDB();
                Guid gid = Guid.Parse(Request.QueryString["gid"]);
                var b = db.xinwen.Where(l => l.gid == gid).FirstOrDefault();
                if (b != null)
                {
                    biaoti.Value = b.biaoti;
                    fubiao.Value = b.fubiao;
                    nrong = b.nrong;
                    laiyuan.Value = b.laiyuan;
                    url.Value = b.url;
                    zuozhe.Value = b.zuozhe;
                    px.Value = b.px.ToString();
                    fwl.Value = b.fwl.ToString();
                    xsRB.Items.FindByValue(b.xs.ToString()).Selected = true;
                    fmlogo.Src = path + b.tupian;
                }
            }
        }
        protected void tijiao_Click(object sender, EventArgs e)
        {
            EFDB db = new EFDB();
            string tp = Common.UploadImg.UPimg("", tupian, path);
            xinwen ef;
            if (String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                ef = new xinwen();
                ef.gid = Guid.NewGuid();
                ef.rukusj = DateTime.Now;
            }
            else
            {
                Guid gid = Guid.Parse(Request.QueryString["gid"]);
                ef = db.xinwen.Where(l => l.gid == gid).FirstOrDefault();
            }
            ef.url = url.Value.Trim();
            ef.biaoti = biaoti.Value.Trim();
            ef.fubiao = fubiao.Value.Trim();
            ef.nrong = Request.Form["editorValue"];
            if (!string.IsNullOrEmpty(tp))
            {
                if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(path + ef.tupian)))
                {
                    File.Delete(System.Web.HttpContext.Current.Server.MapPath(path + ef.tupian));
                }
                ef.tupian = tp;
            }
            ef.laiyuan = laiyuan.Value.Trim();
            ef.zuozhe = zuozhe.Value.Trim();
            ef.px = int.Parse(px.Value);
            ef.fwl = int.Parse(fwl.Value);
            ef.xs = int.Parse(xsRB.SelectedValue);
            if (String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                db.xinwen.Add(ef);
            }
            if (db.SaveChanges() == 1)
            {
                Common.JS.Alert("操作成功", this);
            }
            else
            {
                Common.JS.Alert("操作失败,你可能更改的数据和旧数据一样,请重试!", this);
            }
        }
    }
}