using System.Web;
using System;
using System.Configuration;
using Newtonsoft.Json.Linq;
using LJSheng.Data.EF;
using System.Linq;
using LJSheng.Common;

namespace LJSheng.Web.ajax
{
    /// <summary>
    /// api 的摘要说明
    /// </summary>
    public class api : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string returnstr = "";
            switch (context.Request["function"])
            {
                case "post":
                    returnstr = post(context.Request["ffm"], context.Request["json"]);
                    break;
                case "jiance":
                    returnstr = jiance(HttpContext.Current.Server.HtmlDecode(context.Request["nr"]));
                    break;
                case "jubao":
                    returnstr = jubao(HttpContext.Current.Server.HtmlDecode(context.Request["nr"]));
                    break;
                default:
                    if (context.Request.QueryString["ff"] == "oauth2")
                    {
                        oauth2(context, context.Request.QueryString["tourl"]);
                    }
                    else
                    {
                        returnstr = "你想干嘛?";
                    }
                    break;
            }
            context.Response.Write(returnstr);
        }

        /// <summary> 
        /// 微信网页授权页面调用
        /// </summary> 
        /// <param name="逻辑说明"></param> 
        /// <param>修改备注</param> 
        /// 2014-5-20 林建生
        public void oauth2(HttpContext context, string tourl)
        {
            string openid = LJSheng.Common.LCookie.GetCookie("wxhy");
            if (String.IsNullOrEmpty(openid))
            {
                var code = context.Request.QueryString["code"];
                if (string.IsNullOrEmpty(code))
                {
                    var url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri=" + context.Server.UrlEncode(Data.Helps.imgurl + "/ajax/api.ashx?ff=oauth2&tourl=" + tourl) + "&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect", System.Web.Configuration.WebConfigurationManager.AppSettings["AppId"].ToString());
                    context.Response.Redirect(url);
                }
                else
                {
                    var client = new System.Net.WebClient();
                    client.Encoding = System.Text.Encoding.UTF8;
                    var url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", System.Web.Configuration.WebConfigurationManager.AppSettings["AppId"].ToString(), System.Web.Configuration.WebConfigurationManager.AppSettings["AppSecret"].ToString(), code);
                    JObject jb = JObject.Parse(client.DownloadString(url));
                    openid = jb["openid"].ToString();
                    //注册用户
                    EFDB db = new EFDB();
                    var hy = db.huiyuan.Where(l => l.openid == openid).FirstOrDefault();
                    Guid hygid = Guid.NewGuid();
                    if (hy == null)
                    {
                        //判断是否有该用户.没有就增加一个
                        var b = new LJSheng.Data.EF.huiyuan
                        {
                            gid = hygid,
                            zhanghao = openid,
                            mima = LJSheng.Common.MD5.GetMD5ljsheng(openid),
                            xb = 0,
                            openid = openid,
                            rukusj = DateTime.Now
                        };

                        db.huiyuan.Add(b);
                        if (db.SaveChanges() != 1)
                        {
                            LJSheng.Common.LogManager.WriteLog("注册openid失败", "OPENID:" + openid);
                        }
                    }
                    else
                    {
                        hygid = hy.gid;
                    }
                    LJSheng.Common.LCookie.AddCookie("wxhy", hygid.ToString(), 0);
                }
            }
            string gourl = tourl.Replace("$", "?").Replace("@", "&");
            if (String.IsNullOrEmpty(openid))
            {
                gourl = "/weixin/openid.aspx?" + tourl;
            }
            LJSheng.Common.LogManager.WriteLog("openid跳转的URL", "openid=" + openid + ",URL=" + gourl + ",tourl=" + tourl);
            context.Response.Redirect(gourl);
        }

        /// <summary> 
        /// API模拟POST接口
        /// </summary> 
        /// <param name="ffm">调用的API方法名称</param> 
        /// <param name="json">请求的JSON参数</param> 
        private string post(string ffm,string json)
        {
            return Common.postget.GetPage(ConfigurationManager.AppSettings["post"] + "?ffm=" + ffm, json);
        }

        /// <summary> 
        /// 检测
        /// </summary> 
        /// <param>修改备注</param> 
        /// 2014-5-20 林建生
        public string jiance(string nr)
        {
            string str;
            if (nr.Length > 5)
            {
                EFDB db = new EFDB();
                //匹配检测相似度
                var b = db.dxmb;
                string dxnr = nr.Replace(" ", "").Replace("-", "");
                int dxlx = 0;
                int xsd = 0;
                foreach (var dr in b)
                {
                    if (!string.IsNullOrEmpty(dr.gjz))
                    {
                        string[] gjz = dr.gjz.Split('|');
                        foreach (string s in gjz)
                        {
                            //StringCompute stringcompute1 = new StringCompute();
                            //stringcompute1.SpeedyCompute(dxnr, s);    // 计算相似度， 不记录比较时间
                            //decimal rate = stringcompute1.ComputeResult.Rate; // 相似度百分之几，完全匹配相似度为1
                            //if (rate > (decimal)0.3)
                            //{
                            //    xsd = 100;
                            //    dxlx = (int)dr.lx;
                            //}
                            if (dxnr.Contains(s))
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
                ef = db.jiance.Where(l => l.duanxin == nr && l.hygid == hygid).FirstOrDefault();
                if (ef == null)
                {
                    ef = new LJSheng.Data.EF.jiance();
                    ef.gid = Guid.NewGuid();
                    ef.rukusj = DateTime.Now;
                    ef.hygid = hygid;
                    ef.duanxin = nr;
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
                        str = "jcxq.aspx?xsd=" + xsd + "&dxlx=" + HttpContext.Current.Server.HtmlEncode(((LJSheng.Data.Helps.dxlx)Enum.Parse(typeof(LJSheng.Data.Helps.dxlx), dxlx.ToString(), true)).ToString()) + "&nr=" + HttpContext.Current.Server.HtmlEncode(nr);
                        //Response.Redirect("jcxq.aspx?xsd=" + xsd + "&dxlx=" + Server.HtmlEncode(((LJSheng.Data.Helps.dxlx)Enum.Parse(typeof(LJSheng.Data.Helps.dxlx), dxlx.ToString(), true)).ToString()) + "&nr=" + Server.HtmlEncode(nr.Value));
                    }
                    else
                    {
                        str = "安全性未知,你可以点举报提交给我们";
                    }
                }
                else
                {
                    str = "检测失败";
                }
            }
            else
            {
                str = "内容太少";
            }
            return str;
        }

        /// <summary> 
        /// 举报
        /// </summary> 
        /// <param>修改备注</param> 
        /// 2014-5-20 林建生
        public string jubao(string nr)
        {
            string str;
            EFDB db = new EFDB();
            jubao ef;
            Guid? hygid = null;
            if (!string.IsNullOrEmpty(Common.LCookie.GetCookie("wxhy")))
            {
                hygid = Guid.Parse(Common.LCookie.GetCookie("wxhy"));
            }
            if (nr.Length > 8)
            {
                ef = db.jubao.Where(l => l.duanxin == nr).FirstOrDefault();
                if (ef == null)
                {
                    ef = new jubao();
                    ef.gid = Guid.NewGuid();
                    ef.rukusj = DateTime.Now;
                    ef.duanxin = nr;
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
                        str = "举报成功,该内容被举报: " + ef.cishu + " 次";
                    }
                    else
                    {
                        str = "举报成功";
                    }
                }
                else
                {
                    str ="举报失败";
                }
            }
            else
            {
                str = "内容太少了";
            }
            return str;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}