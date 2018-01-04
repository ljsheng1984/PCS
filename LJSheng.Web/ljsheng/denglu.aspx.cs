using System;
using LJSheng.Data.EF;
using System.Linq;
using Newtonsoft.Json;

namespace LJSheng.Web.ljsheng
{
    public partial class denglu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void dl_Click(object sender, EventArgs e)
        {
            EFDB db = new EFDB();
            string md5mima = Common.MD5.GetMD5ljsheng(mima.Value.Trim());
            LJSheng.Data.EF.ljsheng b = db.ljsheng.Where(l => l.zhanghao == zhanghao.Value.Trim() && l.mima == md5mima).FirstOrDefault();
            //判断用户名密码是否正确
            if (b != null)
            {
                string dl = Common.DESRSA.DESEnljsheng(JsonConvert.SerializeObject(new { b.gid, b.zhanghao }));
                Session["ljsheng"] = dl;
                if (bcdl.Checked)
                {
                    Common.LCookie.AddCookie("ljsheng", dl, 7);
                }
                Response.Redirect("houtai.aspx");
            }
            else
            {
                Common.JS.Alert("用户名或密码错误", this);
            }
        }
    }
}