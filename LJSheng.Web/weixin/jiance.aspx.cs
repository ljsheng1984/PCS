using LJSheng.Common;
using LJSheng.Data.EF;
using System;
using System.Linq;
using System.Text;

namespace LJSheng.Web.weixin
{
    public partial class jiance : System.Web.UI.Page
    {
        //Guid hygid = string.IsNullOrEmpty(Common.LCookie.GetCookie("wxhy")) ? Guid.Parse("00000000-0000-0000-0000-000000000000") : Guid.Parse(Common.LCookie.GetCookie("wxhy"));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(LJSheng.Common.LCookie.GetCookie("wxhy")))
                {
                    Response.Redirect("/ajax/api.ashx?ff=oauth2&tourl=/weixin/jiance.aspx");
                }
                EFDB db = new EFDB();
                Guid? hygid = null;
                if (!string.IsNullOrEmpty(Common.LCookie.GetCookie("wxhy")))
                {
                    hygid = Guid.Parse(Common.LCookie.GetCookie("wxhy"));
                }
                var b = db.jiance.Where(l => l.hygid == hygid).OrderByDescending(l=>l.rukusj);
                StringBuilder sb = new StringBuilder();
                foreach (var dr in b)
                {
                    string dxlx = ((LJSheng.Data.Helps.dxlx)Enum.Parse(typeof(LJSheng.Data.Helps.dxlx), dr.lx.ToString(), true)).ToString();
                    sb.Append("<li><tt><b>"+ dxlx +"</b><em>相似度：<b>"+dr.weihai.ToString()+ "%</b></em><em>危害程度：<b>" + dr.weihai.ToString() +"%</b></em></tt>");
                    sb.Append("<p class=\"mess\"><a href =\"jcxq.aspx?xsd=" + dr.weihai.ToString() + "&dxlx=" + Server.HtmlEncode(dxlx) + "&nr=" + Server.HtmlEncode(dr.duanxin) +"\">" + dr.duanxin + "</a></p>");
                    sb.Append("<small>"+dr.rukusj+"</small></li>");
                }
                lsjl.InnerHtml = sb.ToString();
            }
        }

        protected void jc_Click(object sender, EventArgs e)
        {
            if (nr.Value.Length > 5)
            {
                EFDB db = new EFDB();
                //匹配检测相似度
                var b = db.dxmb;
                string dxnr = nr.Value.Replace(" ", "").Replace("-", "");
                int dxlx = 0;
                int xsd = 0;
                foreach (var dr in b)
                {
                    if (!string.IsNullOrEmpty(dr.gjz))
                    {
                        string[] gjz = dr.gjz.Split('|');
                        foreach (string s in gjz)
                        {
                            if (dxnr == s)
                            {
                                xsd = 100;
                                dxlx = (int)dr.lx;
                            }
                        }
                    }
                }
                //写入数据
                LJSheng.Data.EF.jiance ef;
                Guid hygid = Guid.Parse(Common.LCookie.GetCookie("wxhy"));
                ef = db.jiance.Where(l => l.duanxin == nr.Value && l.hygid== hygid).FirstOrDefault();
                if (ef == null)
                {
                    ef = new LJSheng.Data.EF.jiance();
                    ef.gid = Guid.NewGuid();
                    ef.rukusj = DateTime.Now;
                    ef.hygid = hygid;
                    ef.duanxin = nr.Value;
                    ef.lx = dxlx;
                    ef.weihai = xsd;
                    ef.zt = 1;
                    ef.cishu = 1;
                    db.jiance.Add(ef);
                }
                else
                {
                    ef.cishu = ef.cishu + 1;
                    ef.rukusj = DateTime.Now;
                }
                if (db.SaveChanges() == 1)
                {
                    if (xsd != 0)
                    {
                        Response.Redirect("jcxq.aspx?xsd=" + xsd + "&dxlx=" + Server.HtmlEncode(((LJSheng.Data.Helps.dxlx)Enum.Parse(typeof(LJSheng.Data.Helps.dxlx), dxlx.ToString(), true)).ToString()) + "&nr=" + Server.HtmlEncode(nr.Value));
                    }
                    else
                    {
                        LJSheng.Common.JS.Alert("安全性未知,你可以点举报提交给我们", this);
                    }
                }
                else
                {
                    LJSheng.Common.JS.Alert("检测失败", this);
                }
            }
            else
            {
                LJSheng.Common.JS.Alert("内容太少了", this);
            }
        }

        protected void jb_Click(object sender, EventArgs e)
        {
            EFDB db = new EFDB();
            jubao ef;
            Guid? hygid = null;
            if (!string.IsNullOrEmpty(Common.LCookie.GetCookie("wxhy")))
            {
                hygid = Guid.Parse(Common.LCookie.GetCookie("wxhy"));
            }
            if (nr.Value.Length > 8)
            {
                ef = db.jubao.Where(l => l.duanxin == nr.Value).FirstOrDefault();
                if (ef == null)
                {
                    ef = new jubao();
                    ef.gid = Guid.NewGuid();
                    ef.rukusj = DateTime.Now;
                    ef.duanxin = nr.Value;
                    ef.zt = 1;
                    ef.hdzt = 1;
                    ef.cishu = 1;
                    ef.lx = 0;
                    ef.weihai = 0;
                    ef.hygid = hygid;
                    db.jubao.Add(ef);
                }
                else
                {
                    ef.cishu = ef.cishu + 1;
                    ef.rukusj = DateTime.Now;
                }
                if (db.SaveChanges() == 1)
                {
                    if (ef != null)
                    {
                        LJSheng.Common.JS.Alert("感谢你的支持,该内容已被["+ ef.cishu + "]人举报过了", this);
                    }
                    else
                    {
                        LJSheng.Common.JS.Alert("举报成功", this);
                    }
                }
                else
                {
                    LJSheng.Common.JS.Alert("举报失败", this);
                }
            }
            else
            {
                LJSheng.Common.JS.Alert("内容太少了", this);
            }
        }
    }
}