using System;

namespace LJSheng.Web.ljsheng
{
    public class CheckLoginPage: System.Web.UI.Page
    {
        public CheckLoginPage()
        {
            Load += CheckLogin;//构造函数中加载CheckLogin方法 
        }

        /// <summary> 
        /// 判断是否登录 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        public void CheckLogin(object sender, EventArgs e)
        {
            if (Session["ljsheng"] == null)//登录时保存在Session的值 
            {
                //Response.Redirect("denglu.aspx");//如果为空，转到要调转的页面 
                if (string.IsNullOrEmpty(Common.LCookie.GetCookie("ljsheng")))
                {
                    Response.Write("<script type=\"text/javascript\">alert(\"登录异常,请重新登录!\");parent.location.href = \"/ljsheng/denglu.aspx\";</script>");
                }
            }
        }
    }
}
