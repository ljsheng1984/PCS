using LJSheng.Common;
using LJSheng.Data.EF;
using System;
using System.Linq;
using System.Text;

namespace LJSheng.Web.weixin
{
    public partial class jcxq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EFDB db = new EFDB();
                ljdx.InnerHtml = db.lanjie.Sum(l => l.cishu).ToString();
                var b = db.dxmb;
                StringBuilder sb = new StringBuilder();
                foreach (var dr in b)
                {
                    StringCompute stringcompute1 = new StringCompute();
                    stringcompute1.SpeedyCompute(Server.HtmlDecode(Request.QueryString["nr"]), dr.duanxin);    // 计算相似度， 不记录比较时间
                    decimal rate = stringcompute1.ComputeResult.Rate; // 相似度百分之几，完全匹配相似度为1
                    if (rate > (decimal)0.3)
                    {
                        sb.Append("<li><p class=\"mess\">" + dr.duanxin + "</p></li>");
                    }
                }
                anli.InnerHtml = sb.ToString();
            }
        }
    }
}