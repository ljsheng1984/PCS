using System;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class sendsms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            zhanghao.Value = Request.QueryString["zhanghao"];
        }

        protected void tijiao_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nrong.Value) || String.IsNullOrEmpty(zhanghao.Value))
            {
                Common.JS.Alert("请输入你要发送的短信内容或发送人", this);
            }
            else
            {
                if (linjiansheng.dx(zhanghao.Value, nrong.Value, 1) == 200)
                {
                    Common.JS.Alert("发送成功", this);
                }
                else
                {
                    Common.JS.Alert("发送失败", this);
                }
            }
        }
    }
}