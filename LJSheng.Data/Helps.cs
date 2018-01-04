using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace LJSheng.Data
{
    public static class Helps
    {
        #region 图片分类路径

        //访问的图片URL
        public static string imgurl
        {
            get
            {
                return @"http://www.fpzs110.com";
            }
        }

        //新闻资讯访问地址
        public static string url
        {
            get
            {
                return @"http://www.fpzs110.com/app/xw.aspx?gid=";
            }
        }

        //意见反馈
        public static string yjfk
        {
            get
            {
                return "/uploadfiles/yjfk/";
            }
        }

        //意见反馈
        public static string xinwen
        {
            get
            {
                return "/uploadfiles/xinwen/";
            }
        }

        //会员头像路径
        public static string huiyuan
        {
            get
            {
                return "/uploadfiles/huiyuan/";
            }
        }

        //转发路径
        public static string zhuanfa
        {
            get
            {
                return "/uploadfiles/zhuanfa/";
            }
        }
        #endregion

        #region 手机系统
        public enum sjxt
        {
            苹果 = 1,
            安卓 = 2,
            苹果PAD = 3,
            安卓PAD = 4,
            网页 = 5
        };
        #endregion

        #region 防骗短信类型
        public enum dxlx
        {
            安全或未知 = 0,
            诈骗短信 = 1,
            木马病毒 = 2,
            骚扰信息 = 3,
            诈骗电话 = 4,
            虚假新闻 = 5,
            骚扰电话 = 6
        };
        #endregion

        #region 性别
        public enum xb
        {
            未设置 = 0,
            男 = 1,
            女 = 2
        }
        #endregion

        #region EF查询不重复数据扩展方法
        /// <summary>
        /// EF查询不重复数据扩展方法
        /// </summary>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        #endregion
    }

    #region EF查询不重复数据扩展方法
    public class FastPropertyComparer<T> : IEqualityComparer<T>
    {
        private Func<T, Object> getPropertyValueFunc = null;

        /// <summary>
        /// 通过propertyName 获取PropertyInfo对象
        /// </summary>
        /// <param name="propertyName"></param>
        public FastPropertyComparer(string propertyName)
        {
            PropertyInfo _PropertyInfo = typeof(T).GetProperty(propertyName,
            BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
            if (_PropertyInfo == null)
            {
                throw new ArgumentException(string.Format("{0} is not a property of type {1}.",
                    propertyName, typeof(T)));
            }

            ParameterExpression expPara = Expression.Parameter(typeof(T), "obj");
            MemberExpression me = Expression.Property(expPara, _PropertyInfo);
            getPropertyValueFunc = Expression.Lambda<Func<T, object>>(me, expPara).Compile();
        }

        #region IEqualityComparer<T> Members

        public bool Equals(T x, T y)
        {
            object xValue = getPropertyValueFunc(x);
            object yValue = getPropertyValueFunc(y);

            if (xValue == null)
                return yValue == null;

            return xValue.Equals(yValue);
        }

        public int GetHashCode(T obj)
        {
            object propertyValue = getPropertyValueFunc(obj);

            if (propertyValue == null)
                return 0;
            else
                return propertyValue.GetHashCode();
        }

        #endregion
    }
    #endregion
}