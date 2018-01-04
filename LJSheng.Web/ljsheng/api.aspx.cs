using System;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Configuration;

namespace LJSheng.Web.ljsheng
{
    public partial class api : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string getff()
        {
            //XDocument xmldoc = XDocument.Load(Server.MapPath("~/bin/LJSheng.API.XML"));
            XDocument xmldoc = XDocument.Load(ConfigurationManager.AppSettings["apixml"]);
            var apilist = (from api in xmldoc.Descendants("member")
                           where api.Attribute("name").Value.IndexOf(".goapi.") != -1
                           select new
                           {
                               summary = api.Element("summary").Value.Replace("\n", ""),
                               remarks = api.Element("remarks").Value.Replace("\n", ""),
                               api = api.Attribute("name").Value.Replace("System.", "").Replace("M:LJSheng.API.goapi.", "")
                           });
            StringBuilder sb = new StringBuilder();
            foreach (var goapi in apilist)
            {
                sb.Append("<ul class=\"p_con\">");
                sb.Append("<li>" + goapi.api + "</li>");
                sb.Append("<li>" + goapi.summary + "</li>");
                sb.Append("<li><span>" + goapi.remarks + "</span></li>");
                sb.Append("<li><input type=\"button\" class=\"btn2\" value=\"调用\" onclick=\"javascript:showiframe('" + goapi.summary + "', 'runapi.aspx?ffm=" + goapi.api + "&jj=" + Server.UrlEncode(goapi.summary) + "&dl=需要登录');\" /></li>");
                sb.Append("</ul>");
            }
            return sb.ToString();
        }
    }
}