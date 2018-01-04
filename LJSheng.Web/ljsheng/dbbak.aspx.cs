using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Collections.Generic;

namespace LJSheng.Web.ljsheng
{
    public partial class dbbak : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        //数据绑定
        private void Bind()
        {
            try
            {
                string directory = System.Web.HttpContext.Current.Server.MapPath("/uploadfiles/dbbak/");
                List<FileInfo> files = new List<FileInfo>();
                ///获取文件列表信息  
                foreach (var file in Directory.GetFiles(directory))
                {
                    files.Add(new FileInfo(file));
                }
                ///查询文件列表信息  
                var filevalues = from file in files
                                 where file.Extension == ".bak"
                                 orderby file.CreationTime descending
                                 select file;
                LVljsheng.DataSource = filevalues;
                LVljsheng.DataBind();
            }
            catch { }
        }

        //listviet操作
        protected void LVljsheng_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "del":
                    string file = System.Web.HttpContext.Current.Server.MapPath("/uploadfiles/dbbak/" + ((Label)e.Item.FindControl("name")).Text);
                    switch (e.CommandName)
                    {
                        case "del":
                            if (File.Exists(file))
                                File.Delete(file);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            Bind();
        }

        protected void bf_Click(object sender, EventArgs e)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("/uploadfiles/dbbak/");
            string name = "backup_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Data.DbHelperSQL.ExecuteSql("BACKUP DATABASE [pcs] TO  DISK = N'" + path + name + ".bak' WITH  RETAINDAYS = 7, NOFORMAT, NOINIT,  NAME = N'" + name + "', SKIP, REWIND, NOUNLOAD,  STATS = 10");
            LJSheng.Common.JS.AlertAndRedirect("备份成功", "dbbak.aspx", this);
        }
    }
}