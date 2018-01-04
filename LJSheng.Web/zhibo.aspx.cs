using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LJSheng.Web
{
    public partial class zhibo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ljsheng"]))
            {
                zhuce.Visible = true;
            }
        }

        private string Encrypt(string encryptString, string encryptKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Mode = System.Security.Cryptography.CipherMode.ECB;
            byte[] inputByteArray = Encoding.GetEncoding("UTF-8").GetBytes(encryptString);
            //建立加密对象的密钥和偏移量   
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法   
            //使得输入密码必须输入英文文本   
            des.Key = ASCIIEncoding.ASCII.GetBytes(encryptKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(encryptKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        protected void zhuce_Click(object sender, EventArgs e)
        {
            try
            {
                string diskid = Request.QueryString["ljsheng"];
                StringBuilder sb = new StringBuilder();
                if (lmcb.Checked)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
                if (zjcb.Checked)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
                if (phbcb.Checked)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
                if (cjcb.Checked)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
                if (xqcb.Checked)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
                if (pkcb.Checked)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
                if (xqpkcb.Checked)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
                if (spxqcb.Checked)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
                sb.Append("0000000000");
                Response.Write(Encrypt(sb.ToString() + diskid, "ljsheng1"));
            }
            catch { }
        }
    }
}