using LJSheng.Common;
using System;
using System.IO;
using System.Text;

namespace LJSheng.Web.demo
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringCompute stringcompute1 = new StringCompute();
            string s = "山东省济宁市南张镇，昨天下午因吃樱桃感染H7N9死亡，姓名刘旭年龄26岁，参与抢救的医生任海军已经被隔离，紧急通知，暂时别吃樱桃，芒果，香蕉，已经感染寄生虫。收到马上发给你关心的人，预防永远胜过治疗。看到，群发扩散，此消息属实";
            stringcompute1.SpeedyCompute(s.Trim(), "吃樱桃感染H7N9");    // 计算相似度， 不记录比较时间
            decimal rate = stringcompute1.ComputeResult.Rate; // 相似度百分之几，完全匹配相似度为1

            string haoma = "19840";
            if (!string.IsNullOrEmpty(haoma) && haoma.IndexOf('1') == 0 && haoma.IndexOf('9') == 0 && haoma.IndexOf('8') == 0 && haoma.IndexOf('4') == 0)
            {
                
            }
            else
            {
                haoma = "无效";
            }
            Response.Write(haoma);
        }

        protected void ssc_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"D:\ssc.txt", Encoding.UTF8);
            string nextLine;
            StringBuilder sb = new StringBuilder();
            string haoma;
            int num = 0;
            int nonum = 0;
            while ((nextLine = sr.ReadLine()) != null)
            {
                string[] ssc = nextLine.Split(',');
                foreach (string s in ssc)
                {
                    haoma = zuliu(s);
                    if (!string.IsNullOrEmpty(haoma))
                    {
                        sb.Append(haoma);
                        num++;
                    }
                    else {
                        nonum++;
                    }
                }
            }
            sr.Close();
            LogManager.WriteLog("ssc", sb.ToString().TrimEnd(','));
            Response.Write("合格的数据:" + num.ToString() + ",不合格数据:" + nonum.ToString());
        }

        protected string zuliu(string ssc)
        {
            char[] temp = ssc.ToCharArray();
            int n1 = int.Parse(temp[0].ToString());
            int n2 = int.Parse(temp[1].ToString());
            int n3 = int.Parse(temp[2].ToString());
            int n4 = int.Parse(temp[3].ToString());
            int n5 = int.Parse(temp[4].ToString());
            if (n1 == n2 || n1 == n3 || n2 == n3 || n3 == n4 || n3 == n5 || n4 == n5) //不为组三
            {
                return "";
            }
            else if (n1 > 4 && n2 > 4 && n3 > 4)//前3不为小
            { return ""; }
            else if (n1 < 5 && n2 < 5 && n3 < 5)//前3不为大
            { return ""; }
            else if (n3 > 4 && n4 > 4 && n5 > 4)//后3不为小
            { return ""; }
            else if (n3 < 5 && n4 < 5 && n5 < 5)//后3不为大
            { return ""; }
            else if (n1 % 2 == 0 && n2 % 2 == 0 && n3 % 2 == 0)//前3不为双
            { return ""; }
            else if (n1 % 2 != 0 && n2 % 2 != 0 && n3 % 2 != 0)//前3不为单
            { return ""; }
            else if (n3 % 2 == 0 && n4 % 2 == 0 && n5 % 2 == 0)//后3不为双
            { return ""; }
            else if (n3 % 2 != 0 && n4 % 2 != 0 && n5 % 2 != 0)//后3不为单
            { return ""; }
            //else if (n1 == n4 && n2 == n5)//12不等45
            //{ return ""; }
            //5个数字没有重复的
            //else if (n1 == n2 || n1 == n3 || n1 == n4 || n1 == n5 || n2 == n3 || n2 == n4 || n2 == n5 || n3 == n4 || n3 == n5 || n4 == n5)
            //{ return ""; }
            //else if (n1 != 8)//8开头的
            //{ return ""; }
            else
            {
                #region 大小单双
                //大小32
                int da = 0;
                int xiao = 0;
                if (n1 > 4)
                {
                    da++;
                }
                else
                {
                    xiao++;
                }
                if (n2 > 4)
                {
                    da++;
                }
                else
                {
                    xiao++;
                }
                if (n3 > 4)
                {
                    da++;
                }
                else
                {
                    xiao++;
                }
                if (n4 > 4)
                {
                    da++;
                }
                else
                {
                    xiao++;
                }
                if (n5 > 4)
                {
                    da++;
                }
                else
                {
                    xiao++;
                }
                if (da == 1 || da == 4)
                {
                    return "";
                }
                //奇偶32
                da = 0;
                xiao = 0;
                if (n1 % 2 == 0)
                {
                    da++;
                }
                else
                {
                    xiao++;
                }
                if (n2 % 2 == 0)
                {
                    da++;
                }
                else
                {
                    xiao++;
                }
                if (n3 % 2 == 0)
                {
                    da++;
                }
                else
                {
                    xiao++;
                }
                if (n4 % 2 == 0)
                {
                    da++;
                }
                else
                {
                    xiao++;
                }
                if (n5 % 2 == 0)
                {
                    da++;
                }
                else
                {
                    xiao++;
                }
                if (da == 1 || da == 4)
                {
                    return "";
                }
                #endregion

                #region 前后包含1984
                int qm = 0;
                int hm = 0;
                if (n1 == 1 || n1 == 9 || n1 == 8 || n1 == 4)
                {
                    qm++;
                }
                if (n2 == 1 || n2 == 9 || n2 == 8 || n2 == 4)
                {
                    qm++;
                }
                if (n3 == 1 || n3 == 9 || n3 == 8 || n3 == 4)
                {
                    qm++;
                    hm++;
                }
                if (n4 == 1 || n4 == 9 || n4 == 8 || n4 == 4)
                {
                    hm++;
                }
                if (n5 == 1 || n5 == 9 || n5 == 8 || n5 == 4)
                {
                    hm++;
                }
                #endregion
                //前后1984
                if (hm > 1 && qm > 1)
                {
                    //return ssc + ",";
                    //第一位第五位包含1984
                    if (n1 == 1 || n1 == 9 || n1 == 8 || n1 == 4 || n5 == 1 || n5 == 9 || n5 == 8 || n5 == 4)
                    {
                        //后三包含19,18
                        int houm = 0;
                        if (n3 == 1)
                        {
                            if (n4 == 9 || n4 == 8 || n5 == 8 || n5 == 9)
                                houm = 2;
                        }
                        if (n4 == 1)
                        {
                            if (n3 == 9 || n3 == 8 || n5 == 8 || n5 == 9)
                                houm = 2;
                        }
                        if (n5 == 1)
                        {
                            if (n4 == 9 || n4 == 8 || n3 == 8 || n3 == 9)
                                houm = 2;
                        }
                        //前三包含18,19
                        int qianm = 0;
                        if (n3 == 1)
                        {
                            if (n1 == 9 || n1 == 8 || n2 == 8 || n2 == 9)
                                qianm = 2;
                        }
                        if (n2 == 1)
                        {
                            if (n3 == 9 || n3 == 8 || n1 == 8 || n1 == 9)
                                qianm = 2;
                        }
                        if (n1 == 1)
                        {
                            if (n2 == 9 || n2 == 8 || n3 == 8 || n3 == 9)
                                qianm = 2;
                        }
                        if (qianm == 2)
                        {
                            return ssc + ",";
                        }
                        if (qianm ==2 && houm == 2)
                        {
                            return ssc + ",";
                        }
                    }
                }
            }
            return "";
        }

        protected string zusan(string ssc)
        {
            char[] temp = ssc.ToCharArray();
            int n1 = int.Parse(temp[0].ToString());
            int n2 = int.Parse(temp[1].ToString());
            int n3 = int.Parse(temp[2].ToString());
            int n4 = int.Parse(temp[3].ToString());
            int n5 = int.Parse(temp[4].ToString());
            if (n3 == n4 && n3 == n5)//后面豹子
            {
                return "";
            }
            else if (n1 == n2 && n1 == n3)//前面豹子
            {
                return "";
            }
            else if (n2 == n3 && n2 == n4)//中间豹子
            {
                return "";
            }
            else if (n1 > 4 && n2 > 4 && n3 > 4 && n4 > 4 && n5 > 4)//全小
            { return ""; }
            else if (n1 < 5 && n2 < 5 && n3 < 5 && n4 < 5 && n5 < 5)//全大
            { return ""; }
            else if (n1 % 2 == 0 && n2 % 2 == 0 && n3 % 2 == 0 && n4 % 2 == 0 && n5 % 2 == 0)//全双
            { return ""; }
            else if (n1 % 2 != 0 && n2 % 2 != 0 && n3 % 2 != 0 && n4 % 2 != 0 && n5 % 2 != 0)//全单
            { return ""; }
            else if (n1 ==n2 && n4==n5)//头尾对子
            { return ""; }
            else if (n1 == n2 && n3 == n4) //连续对子
            { return ""; }
            else if (n2 == n3 && n4 == n5) //连续对子
            { return ""; }
            else if (n1 == n3 && n1 == n5) //135 相等
            { return ""; }
            else
            {
                if ((n1 == n2 || n1 == n3 || n2 == n3) && (n3 == n4 || n3 == n5 || n4 == n5)) //组三
                {
                    return ssc + ",";
                }
            }
            return "";
        }
    }
}