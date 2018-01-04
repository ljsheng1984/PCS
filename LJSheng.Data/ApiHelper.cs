using System;
using System.Collections.Generic;
using System.Web;
using System.Diagnostics;

namespace LJSheng.Data
{
    public class ApiHelper
    {
        #region 接口必须的参数赋值
        /// <summary>
        /// 会员登录GID
        /// </summary>
        public static Guid? gid
        {
            get
            {
                if (HttpContext.Current.Session["gid"] != null && HttpContext.Current.Session["gid"].ToString() != "")
                {
                    return Guid.Parse(HttpContext.Current.Session["gid"].ToString());
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 请求时候的IP
        /// </summary>
        public static string ip
        {
            get
            {
                if (HttpContext.Current.Session["ip"] != null)
                {
                    return HttpContext.Current.Session["ip"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 手机系统
        /// </summary>
        public static int sjxt
        {
            get
            {
                if (HttpContext.Current.Session["sjxt"] != null)
                {
                    return byte.Parse(HttpContext.Current.Session["sjxt"].ToString());
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// APP版本号
        /// </summary>
        public static string bbh
        {
            get
            {
                if (HttpContext.Current.Session["bbh"] != null)
                {
                    return HttpContext.Current.Session["bbh"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 手机型号
        /// </summary>
        public static string sjxh
        {
            get
            {
                if (HttpContext.Current.Session["sjxh"] != null)
                {
                    return HttpContext.Current.Session["sjxh"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region 计算接口调用时间
        public static DateTime StartTime
        {
            get
            {
                if (HttpContext.Current.Session["StartTime"] != null)
                {
                    return Convert.ToDateTime(HttpContext.Current.Session["StartTime"].ToString());
                }
                else
                {
                    return new DateTime(1, 1, 1);
                }
            }
        }
        public static Stopwatch Stopwatch
        {
            get
            {
                if (HttpContext.Current.Session["Stopwatch"] != null)
                {
                    return HttpContext.Current.Session["Stopwatch"] as Stopwatch;
                }
                else
                {
                    return null;
                }
            }
        }
        public static List<long> StopwatchTimes
        {
            get
            {
                if (HttpContext.Current.Session["StopwatchTimes"] != null)
                {
                    return HttpContext.Current.Session["StopwatchTimes"] as List<long>;
                }
                else
                {
                    return null;
                }
            }
        }
        public static void AddStopwatchTime()
        {
            StopwatchTimes.Add(Stopwatch.ElapsedMilliseconds);
        }
        #endregion
    }

    #region 接口状态
    public enum ApiResultCodeEnum
    {
        Success = 200,//访问成功
        LoginError = 300,//登入相关错误
        ParameterError = 400,//参数错误       
        Error = 500,//自定义错误
    }

    public class ApiResult
    {
        public int code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }

        public ApiResult(ApiResultCodeEnum code, string msg, object data)
        {
            this.code = (int)code;
            this.msg = msg;
            this.data = data;
        }

        public ApiResult(ApiResultCodeEnum code, string msg)
        {
            this.code = (int)code;
            this.msg = msg;
            this.data = new { };
        }

        public ApiResult(string msg)
        {
            this.code = (int)ApiResultCodeEnum.Error;
            this.msg = msg;
            this.data = "";
        }
        public ApiResult(string msg,object data)
        {
            this.code = (int)ApiResultCodeEnum.Success;
            this.msg = msg;
            this.data = data;
        }
    }
    #endregion

    #region 需要登入特性
    /// <summary>
    /// 需要登入特性
    /// </summary>
    public class LoginAttribute : Attribute { }
    #endregion
}
