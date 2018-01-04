using System;
using LJSheng.Data.EF;

namespace LJSheng.Web
{
    public static class linjiansheng
    {
        /// <summary>
        /// 短信发送
        /// </summary>
        public static int dx(string shouji, string dxnr, byte lx)
        {
            //是验证码短信重置短信内容
            string SMSmsg = dxnr;
            if (lx == 2)
            {
                SMSmsg = "您当前操作需要的验证码是:" + dxnr + ", 十分钟内有效!";
            }
            //把手机变成500一组发送
            string[] sj = shouji.Split('#');
            EFDB db = new EFDB();
            int zt = 404;//发送状态
            for (int i = 0; i < sj.Length; i++)
            {
                string rzt = Common.SMS.postsend(shouji, SMSmsg);
                //发送成功
                Guid gid = Guid.NewGuid();
                var b = new duanxin
                {
                    gid = gid,
                    shouji = sj[i],
                    dxnr = dxnr,
                    tiaoshu = ((dxnr.Length + 8) / 70) + 1,
                    lx = lx,
                    beizhu = rzt,
                    rukusj = DateTime.Now
                };
                db.duanxin.Add(b);
                if (db.SaveChanges() == 1 && rzt.IndexOf("success") > -1)
                {
                    zt = 200; 
                }
                else
                {
                    Common.LogManager.WriteLog("短信发送失败", "发送回执:" + rzt + "\r\n发送类型:" + lx.ToString() + "\r\n发送号码:" + sj[i] + "\r\n发送内容:" + dxnr);
                }
            }
            return zt;
        }
    }
}
