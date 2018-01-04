using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LJSheng.Web.ljsheng
{
    public partial class runapi : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ffm"]))
            {
                XDocument xmldoc = XDocument.Load(ConfigurationManager.AppSettings["apixml"]);
                var returns = (from r in xmldoc.Descendants("member")
                               where r.Attribute("name").Value.IndexOf("goapi." + Request.QueryString["ffm"].Split('(')[0]) != -1
                               select new
                               {
                                   paramlist = from cs in r.Elements("param")
                                               select new
                                               {
                                                   name = cs.Attribute("name").Value,
                                                   value = cs.Value
                                               },
                                   paralist = from cs in r.Elements("para")
                                              select new
                                              {
                                                  namevalue = cs.Attribute("name").Value + " = " + cs.Value
                                              }
                               });
                StringBuilder sb = new StringBuilder();
                //接口用的参数
                foreach (var p in returns)
                {
                    foreach (var nv in p.paramlist)
                    {
                        sb.Append("<ul class=\"p_con\">");
                        sb.Append("<li>" + nv.name + "</li>");
                        sb.Append("<li><input type=\"text\" name=\"" + nv.name + "\" /></li>");
                        sb.Append("<li>" + nv.value + "</li>");
                        sb.Append("</ul>");
                    }
                }
                cslist.InnerHtml = sb.ToString();
                sb.Clear();
                //返回的参数
                foreach (var p in returns)
                {
                    foreach (var nv in p.paralist)
                    {
                        sb.Append("<li>" + nv.namevalue + "</li>");
                    }
                }
                rlist.InnerHtml = sb.ToString();
            }
            else
            {
                Response.Redirect("houtai.aspx");
            }
        }
    }
}