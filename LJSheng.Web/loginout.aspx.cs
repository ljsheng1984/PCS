using System;

namespace LJSheng.Web
{
    public partial class loginout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.LCookie.DelALLCookie();
            Response.Write("<script type=\"text/javascript\">parent.location.href = \"" + Request.QueryString["url"] + "\";</script>");
        }
    }
}