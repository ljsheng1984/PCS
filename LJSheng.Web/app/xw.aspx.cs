using LJSheng.Data.EF;
using System;
using System.Linq;

namespace LJSheng.Web.app
{
    public partial class xw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                EFDB db = new EFDB();
                Guid gid = Guid.Parse(Request.QueryString["gid"]);
                var b = db.xinwen.Where(l => l.gid == gid).FirstOrDefault();
                if (b != null)
                {
                    shijian.InnerHtml = b.rukusj.ToString();
                    laiyuan.InnerHtml = b.laiyuan;
                    nrong.InnerHtml = b.nrong;
                    biaoti.InnerHtml = b.biaoti;
                }
            }
        }
    }
}