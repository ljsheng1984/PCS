//----------------------------------------
//创建描述: 接受/发送消息帮助类
//创建信息: 2014-07-21 林建生
//----------------------------------------
using LJSheng.Data.EF;
using System;
using System.Linq;
using System.Xml;
using LJSheng.Common;
using System.Web;

namespace LJSheng.WX
{
    public class messageHelp
    {
        #region 对微信发送过来的数据转换成,分析接收到的类型是什么类型(一个逻辑多个函数处理只用一个代码块) - 林XX 2015-03-18(不是本人创建的文件增加函数要备注)
        /// <summary>
        /// 接收 postStr 字符串 进行XML解析,获取消息类型(函数作用说明,可以把重要的函数逻辑写这里)
        /// </summary>
        /// <param name="postStr">解析的数据包</param>
        /// <returns>返回responseContent给微信</returns>
        public string ReturnMessage(string postStr)
        {
            string responseContent = "";//返回给微信的变量
            //进行字符串解析
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(new System.IO.MemoryStream(System.Text.Encoding.GetEncoding("utf-8").GetBytes(postStr)));
            XmlNode MsgType = xmldoc.SelectSingleNode("/xml/MsgType");
            //增加/修改判断消息类型 - 林建生 2015-03-18(修改或增加不是自己的写的函数加此备注)
            if (MsgType != null)
            {
                switch (MsgType.InnerText)
                {
                    case "event"://事件
                        responseContent = EventHandle(xmldoc);//事件处理
                        break;
                    case "text"://文本
                        responseContent = TextHandle(xmldoc);//接受文本消息处理
                        break;
                    case "image"://图片
                        responseContent = ImageHandle(xmldoc);
                        break;
                    case "voice": //声音

                        break;

                    case "video"://视频

                        break;

                    case "location"://地理位置

                        break;
                    case "link"://链接

                        break;
                    default:
                        break;
                }
            }
            return responseContent;
        }
        #endregion

        #region 处理图片消息类型并应答
        /// <summary>
        /// 图片消息类型的返回
        /// </summary>
        /// <param name="xmldoc">微信发过来的XML</param>
        /// <returns>返回XML格式的消息类型</returns>
        public string ImageHandle(XmlDocument xmldoc)
        {
            string responseContent = "";
            XmlNode ToUserName = xmldoc.SelectSingleNode("/xml/ToUserName");
            XmlNode FromUserName = xmldoc.SelectSingleNode("/xml/FromUserName");
            XmlNode PicUrl = xmldoc.SelectSingleNode("/xml/PicUrl");
            EFDB db = new EFDB();
            var hy = db.huiyuan.Where(l => l.openid == FromUserName.InnerText).FirstOrDefault();
            if (hy != null)
            {
                //下载远程图片
                string wjm = LJSheng.Common.RandStr.CreateOrderNO("zf") + ".jpg";
                System.Net.WebClient web = new System.Net.WebClient();
                web.DownloadFile(PicUrl.InnerText, HttpContext.Current.Server.MapPath(LJSheng.Data.Helps.zhuanfa + wjm));
                zhuanfa zf = new zhuanfa();
                zf.gid = Guid.NewGuid();
                zf.rukusj = DateTime.Now;
                zf.hygid = hy.gid;
                zf.hdzt = 1;
                zf.tupian = wjm;
                db.zhuanfa.Add(zf);
                if (db.SaveChanges() == 1)
                {
                    responseContent = string.Format(ReplyType.Message_Text,
                                                    FromUserName.InnerText,
                                                    ToUserName.InnerText,
                                                    DateTime.Now.Ticks,
                                                    "收取转发截图成功,请记得打开 " + Data.Helps.imgurl + "/app/hdzl.aspx 登记联系方式领取奖品");
                }
            }
            else
            {
                responseContent = string.Format(ReplyType.Message_Text,
                                FromUserName.InnerText,
                                ToUserName.InnerText,
                                DateTime.Now.Ticks,
                                "系统接收截图失败");
                LogManager.WriteLog("会员不存在", FromUserName.InnerText);
            }
            return responseContent;
        }
        #endregion

        #region 处理事件类型并应答
        /// <summary>
        /// 处理事件类型
        /// </summary>
        /// <param name="xmldoc">微信发过来的XML</param>
        /// <returns>返回事件类型的消息</returns>
        public string EventHandle(XmlDocument xmldoc)
        {
            XmlNode Event = xmldoc.SelectSingleNode("/xml/Event");
            XmlNode EventKey = xmldoc.SelectSingleNode("/xml/EventKey");
            XmlNode ToUserName = xmldoc.SelectSingleNode("/xml/ToUserName");
            XmlNode FromUserName = xmldoc.SelectSingleNode("/xml/FromUserName");
            string responseContent = "";
            EFDB db = new EFDB();
            var query = db.wxgjz.Where(l => l.gjz.Contains("其他")).FirstOrDefault();
            if (query != null)
            {
                responseContent = string.Format(ReplyType.Message_Text,
                FromUserName.InnerText,
                ToUserName.InnerText,
                DateTime.Now.Ticks,
                query.huifu);
            }
            if (Event != null)
            {
                switch (Event.InnerText)
                {
                    //事件类型，subscribe(订阅)
                    case "subscribe":
                        Guid hygid = Guid.NewGuid();
                        var hy = db.huiyuan.Where(l => l.openid == FromUserName.InnerText).FirstOrDefault();
                        if (hy == null)
                        {
                            //判断是否有该用户.没有就增加一个
                            var b = new LJSheng.Data.EF.huiyuan
                            {
                                gid = hygid,
                                zhanghao = FromUserName.InnerText,
                                mima = LJSheng.Common.MD5.GetMD5ljsheng(FromUserName.InnerText),
                                xb = 0,
                                openid = FromUserName.InnerText,
                                rukusj = DateTime.Now
                            };

                            db.huiyuan.Add(b);
                            if (db.SaveChanges() != 1)
                            {
                                LogManager.WriteLog("关注注册失败", "OPENID=" + FromUserName.InnerText);
                            }
                            else
                            {
                                LogManager.WriteLog("关注注册成功", "OPENID=" + FromUserName.InnerText);
                            }
                        }
                        else
                        {
                            hygid = hy.gid;
                        }
                        query = db.wxgjz.Where(l => l.gjz.Contains("关注")).FirstOrDefault();
                        if (query != null)
                        {
                            if (query.lx == 2)
                            {
                                responseContent = string.Format(ReplyType.Message_Text,
                                                                   FromUserName.InnerText,
                                                                   ToUserName.InnerText,
                                                                   DateTime.Now.Ticks,
                                                                   query.huifu);
                            }
                            else
                            {
                                string News_Item = "";
                                string ArticleCount = "1";
                                if (query.huifu.IndexOf('$') != -1)
                                {
                                    string[] wzlist = query.huifu.Split('$');
                                    ArticleCount = wzlist.Length.ToString();
                                    for (int i = 0; i < wzlist.Length; i++)
                                    {
                                        Guid gid = Guid.Parse(wzlist[i]);
                                        var news = db.xinwen.Where(l => l.gid == gid).FirstOrDefault();
                                        if (news != null)
                                        {
                                            News_Item += string.Format(ReplyType.Message_News_Item,
                                                                                                news.biaoti,
                                                                                                news.fubiao,
                                                                                                Data.Helps.imgurl + Data.Helps.xinwen + "/" + news.tupian,
                                                                                                string.IsNullOrEmpty(news.url) ? Data.Helps.url + news.gid : news.url);
                                        }
                                    }
                                }
                                else
                                {
                                    Guid gid = Guid.Parse(query.huifu);
                                    var news = db.xinwen.Where(l => l.gid == gid).FirstOrDefault();
                                    if (news != null)
                                    {
                                        News_Item = string.Format(ReplyType.Message_News_Item,
                                                                                            news.biaoti,
                                                                                            news.fubiao,
                                                                                            Data.Helps.imgurl + Data.Helps.xinwen + "/" + news.tupian,
                                                                                            string.IsNullOrEmpty(news.url) ? Data.Helps.url + news.gid : news.url);
                                    }
                                }
                                responseContent = string.Format(ReplyType.Message_News_Main,
                                                                                          FromUserName.InnerText,
                                                                                          ToUserName.InnerText,
                                                                                          DateTime.Now.Ticks,
                                                                                          ArticleCount,
                                                                                          News_Item);
                            }
                        }
                        break;
                    //菜单单击事件
                    case "CLICK":
                        query = db.wxgjz.Where(l => l.gjz.Contains(EventKey.InnerText)).FirstOrDefault();
                        if (query != null)
                        {
                            if (query.lx == 2)
                            {
                                responseContent = string.Format(ReplyType.Message_Text,
                                                                   FromUserName.InnerText,
                                                                   ToUserName.InnerText,
                                                                   DateTime.Now.Ticks,
                                                                   query.huifu);
                            }
                            else
                            {
                                string News_Item = "";
                                string ArticleCount = "1";
                                if (query.huifu.IndexOf('$') != -1)
                                {
                                    string[] wzlist = query.huifu.Split('$');
                                    ArticleCount = wzlist.Length.ToString();
                                    for (int i = 0; i < wzlist.Length; i++)
                                    {
                                        Guid gid = Guid.Parse(wzlist[i]);
                                        var news = db.xinwen.Where(l => l.gid == gid).FirstOrDefault();
                                        if (news != null)
                                        {
                                            News_Item += string.Format(ReplyType.Message_News_Item,
                                                                                                news.biaoti,
                                                                                                news.fubiao,
                                                                                                Data.Helps.imgurl + Data.Helps.xinwen + "/" + news.tupian,
                                                                                                string.IsNullOrEmpty(news.url) ? Data.Helps.url + news.gid : news.url);
                                        }
                                    }
                                }
                                else
                                {
                                    Guid gid = Guid.Parse(query.huifu);
                                    var news = db.xinwen.Where(l => l.gid == gid).FirstOrDefault();
                                    if (news != null)
                                    {
                                        News_Item = string.Format(ReplyType.Message_News_Item,
                                                                                            news.biaoti,
                                                                                            news.fubiao,
                                                                                            Data.Helps.imgurl + Data.Helps.xinwen + "/" + news.tupian,
                                                                                            string.IsNullOrEmpty(news.url) ? Data.Helps.url + news.gid : news.url);
                                    }
                                }
                                responseContent = string.Format(ReplyType.Message_News_Main,
                                                                                          FromUserName.InnerText,
                                                                                          ToUserName.InnerText,
                                                                                          DateTime.Now.Ticks,
                                                                                          ArticleCount,
                                                                                          News_Item);

                            }
                        }
                        break;
                    //菜单单击事件
                    case "VIEW":
                        responseContent = "";
                        break;
                    default:
                        break;
                }
            }
            return responseContent;
        }
        #endregion

        #region 处理文本消息类型并应答
        /// <summary>
        /// 文本消息类型的返回
        /// </summary>
        /// <param name="xmldoc">微信发过来的XML</param>
        /// <returns>返回XML格式的消息类型</returns>
        public string TextHandle(XmlDocument xmldoc)
        {
            XmlNode ToUserName = xmldoc.SelectSingleNode("/xml/ToUserName");
            XmlNode FromUserName = xmldoc.SelectSingleNode("/xml/FromUserName");
            XmlNode Content = xmldoc.SelectSingleNode("/xml/Content");
            string responseContent = "";
            EFDB db = new EFDB();
            var query = db.wxgjz.Where(l => l.gjz.Contains("其他")).FirstOrDefault();
            if (query != null)
            {
                responseContent = string.Format(ReplyType.Message_Text,
                                                FromUserName.InnerText,
                                                ToUserName.InnerText,
                                                DateTime.Now.Ticks,
                                                query.huifu);
            }
            //匹配数据库对应的关键字
            if (Content != null)
            {
                query = db.wxgjz.Where(l => l.gjz.Contains(Content.InnerText)).FirstOrDefault();
                if (query != null)
                {
                    if (query.lx == 2)
                    {
                        responseContent = string.Format(ReplyType.Message_Text,
                                                           FromUserName.InnerText,
                                                           ToUserName.InnerText,
                                                           DateTime.Now.Ticks,
                                                           query.huifu);
                    }
                    else
                    {
                        string News_Item = "";
                        string ArticleCount = "1";
                        if (query.huifu.IndexOf('$') != -1)
                        {
                            string[] wzlist = query.huifu.Split('$');
                            ArticleCount = wzlist.Length.ToString();
                            for (int i = 0; i < wzlist.Length; i++)
                            {
                                Guid gid = Guid.Parse(wzlist[i]);
                                var news = db.xinwen.Where(l => l.gid == gid).FirstOrDefault();
                                if (news != null)
                                {
                                    News_Item += string.Format(ReplyType.Message_News_Item,
                                                                                        news.biaoti,
                                                                                        news.fubiao,
                                                                                        Data.Helps.imgurl + Data.Helps.xinwen + "/" + news.tupian,
                                                                                        string.IsNullOrEmpty(news.url) ? Data.Helps.url + news.gid : news.url);
                                }
                            }
                        }
                        else
                        {
                            Guid gid = Guid.Parse(query.huifu);
                            var news = db.xinwen.Where(l => l.gid == gid).FirstOrDefault();
                            if (news != null)
                            {
                                News_Item = string.Format(ReplyType.Message_News_Item,
                                                                                    news.biaoti,
                                                                                    news.fubiao,
                                                                                    Data.Helps.imgurl + Data.Helps.xinwen + "/" + news.tupian,
                                                                                    string.IsNullOrEmpty(news.url) ? Data.Helps.url + news.gid : news.url);
                            }
                        }
                        responseContent = string.Format(ReplyType.Message_News_Main,
                                                                                  FromUserName.InnerText,
                                                                                  ToUserName.InnerText,
                                                                                  DateTime.Now.Ticks,
                                                                                  ArticleCount,
                                                                                  News_Item);
                    }
                }
            }
            return responseContent;
        }
        #endregion
    }

    #region 微信回复类型列表
    public class ReplyType
    {
        /// <summary>
        /// 普通文本消息
        /// </summary>
        public static string Message_Text
        {
            get
            {
                return @"<xml>
                                                    <ToUserName><![CDATA[{0}]]></ToUserName>
                                                    <FromUserName><![CDATA[{1}]]></FromUserName>
                                                    <CreateTime>{2}</CreateTime>
                                                    <MsgType><![CDATA[text]]></MsgType>
                                                    <Content><![CDATA[{3}]]></Content>
                                                    </xml>";
            }
        }

        /// <summary>
        /// 图文消息主体
        /// </summary>
        public static string Message_News_Main
        {
            get
            {
                return @"<xml>
                                                    <ToUserName><![CDATA[{0}]]></ToUserName>
                                                    <FromUserName><![CDATA[{1}]]></FromUserName>
                                                    <CreateTime>{2}</CreateTime>
                                                    <MsgType><![CDATA[news]]></MsgType>
                                                    <ArticleCount>{3}</ArticleCount>
                                                    <Articles>
                                                    {4}
                                                    </Articles>
                                                    </xml> ";
            }
        }

        /// <summary>
        /// 图文消息项
        /// </summary>
        public static string Message_News_Item
        {
            get
            {
                return @"<item>
                                                    <Title><![CDATA[{0}]]></Title> 
                                                    <Description><![CDATA[{1}]]></Description>
                                                    <PicUrl><![CDATA[{2}]]></PicUrl>
                                                    <Url><![CDATA[{3}]]></Url>
                                                    </item>";
            }
        }

        /// <summary>
        /// 回复图片
        /// </summary>
        public static string Message_image
        {
            get
            {
                return @"<xml>
                                                    <ToUserName><![CDATA[{0}]]></ToUserName>
                                                    <FromUserName><![CDATA[{1}]]></FromUserName>
                                                    <CreateTime>{2}</CreateTime>
                                                    <MsgType><![CDATA[image]]></MsgType>
                                                    <Image>
                                                    <MediaId><![CDATA[{3}]]></MediaId>
                                                    </Image>
                                                    </xml>";
            }
        }
    }
    #endregion
}