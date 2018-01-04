using System;
using System.Text;
using System.Net;
using LJSheng.Data.EF;
using System.Configuration;
using System.Collections.Generic;

namespace LJSheng.Data
{
    public static class JPush
    {
        static Random random = new Random();
        /// <summary>
        /// 获取发送序列号
        /// </summary>
        /// <returns></returns>
        private static int getSendNo()
        {    
            return random.Next(2147483647);
        }

        /// <summary>
        /// 推送
        /// </summary>
        /// <param name="alias">设备ID</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="extras">附加信息</param>
        /// <param name="sendno">发送序列号</param>
        /// <param name="ifacereturn">接口返回内容</param>
        /// <param name="httpcode">http状态值</param>
        /// <param name="messageid">消息id</param>
        /// <param name="lx">发送类型</param>
        /// <returns></returns>
        public static bool push(List<string> alias, string title, string content, object extras, out string sendno, out string ifacereturn, out string httpcode, out string messageid)
        {
            //string appKey = lx == 3 ? ConfigurationManager.AppSettings["padappKey"] : ConfigurationManager.AppSettings["jappKey"];
            //string masterSecret = lx == 3 ? ConfigurationManager.AppSettings["padmasterSecret"] : ConfigurationManager.AppSettings["jmasterSecret"];
            string appKey = "03c587853bcab3ad4ab82c29";
            string masterSecret = "1e5f04cb6b33a116ef4d7aa4";
            sendno = "";
            httpcode = "";
            messageid = "";

            //实例化HttpWebRequest对象
            string url = ConfigurationManager.AppSettings["jpushurl"];
            HttpWebRequest hwrequest = (HttpWebRequest)WebRequest.Create(url);
            hwrequest.Method = "POST";
            hwrequest.ContentType = "application/x-www-form-urlencoded";
            //添加验证内容
            hwrequest.Headers.Add("Authorization", " Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(appKey + ":" + masterSecret)));
            sendno = getSendNo().ToString();
            //构建发送对象
            var sendObject = new {
                platform = "all",
                audience = new {
                    alias = alias.ToArray()
                },
                notification = new {
                    android = new {
                        alert = content,
                        title = title,
                        extras = extras != null ? extras : new { }
                    },
                    ios = new {
                        alert = content,
                        title = title,
                        extras = extras != null ? extras : new { },
                        badge = 1,
                        sound = "happy"
                    }
                },
                options = new {
                    sendno = sendno,
                    apns_production = ConfigurationManager.AppSettings["apns_production"]
                }
            };
            byte[] buffer = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(sendObject));
            hwrequest.ContentLength = buffer.Length;
            try
            {
                hwrequest.GetRequestStream().Write(buffer, 0, buffer.Length);
                hwrequest.GetRequestStream().Close();
                HttpWebResponse hwresponse = (HttpWebResponse)hwrequest.GetResponse();
                byte[] responseBuffer = new byte[1024];
                hwresponse.GetResponseStream().Read(responseBuffer, 0, 1024);
                hwresponse.GetResponseStream().Close();
                ifacereturn = Encoding.UTF8.GetString(responseBuffer);
                httpcode = ((int)hwresponse.StatusCode).ToString();
                messageid = (Newtonsoft.Json.JsonConvert.DeserializeObject(ifacereturn) as Newtonsoft.Json.Linq.JObject)["msg_id"].ToString();
                if (hwresponse.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (WebException e)
            {
                httpcode = ((int)(e.Response as HttpWebResponse).StatusCode).ToString();
                ifacereturn = e.ToString();
                return false;
            }
            catch (Exception e)
            {
                ifacereturn = e.ToString();
                return false;
            }
        }

        /// <summary>
        /// 推送
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="extras">附加信息</param>
        /// <param name="lx">发送类型</param>
        /// <returns></returns>
        public static bool sendpush(List<string> alias, string title, string nrong, object extras)
        {
            if (extras is string)
            {
                extras = Newtonsoft.Json.JsonConvert.DeserializeObject(extras as string);
            }
            string sendno = "";
            string ifacereturn = "";
            string httpcode = "";
            string messageid = "";
            bool isSuccess = JPush.push(alias, title, nrong, extras, out sendno, out ifacereturn, out httpcode, out messageid);
            EFDB db = new EFDB();
            Guid gid = Guid.NewGuid();
            var b = new tuisong
            {
                gid = gid,
                lx = 2,
                alias = string.Join(",", alias.ToArray()),
                title = title,
                nrong = nrong,
                extras = Newtonsoft.Json.JsonConvert.SerializeObject(extras),
                sendno = sendno,
                ifacereturn = ifacereturn,
                httpcode = httpcode,
                messageid = messageid,
                rukusj = DateTime.Now
            };
            db.tuisong.Add(b);
            db.SaveChanges();
            return isSuccess;
        }
    }
}