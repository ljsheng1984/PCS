using System;
using System.Text;

namespace LJSheng.Web.ljsheng
{
    public partial class caidan : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StringBuilder sb = new StringBuilder();
                int qx = Common.LCommon.StringToInt(Common.LCookie.GetCookie("qx"));
                if (qx == 1)
                {
                    sb.Append("<h2>"); 
                    sb.Append("<img src=\"images/01.png\" />系统管理</h2>");
                    sb.Append("<ul>");
                    sb.Append("<li><a href=\"glylist.aspx\" target=\"main\">管理员管理</a></li>");
                    sb.Append("<li><a href=\"glyau.aspx\" target=\"main\">增加管理员</a></li>");
                    sb.Append("</ul>");
                }
                //menu.InnerHtml = sb.ToString();
            }
        }
    }
}