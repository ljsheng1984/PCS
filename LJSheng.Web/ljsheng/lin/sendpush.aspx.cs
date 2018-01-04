using LJSheng.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class sendpush : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tijiao_Click(object sender, EventArgs e)
        {
            List<string> alias = new List<string>();
            dynamic extras = null;
            int lx = int.Parse(lxRB.SelectedValue);
            if (Request.QueryString["hygid"] == "all")
            {
                //群发
                EFDB db = new EFDB();
                var b = db.jpush.ToList();
                if (Request.QueryString["lx"] == "3")
                {
                    b = b.Where(l => l.lx ==3).ToList();
                }
                else
                {
                    b = b.Where(l => l.lx !=3).ToList();
                }
                foreach (var dr in b)
                {
                    alias.Add(dr.alias);
                }
                extras = new
                {
                    //1=网页跳转(url) 2=跳转到接收的短信界面 插入短信内容(参数haoma,msg) 其他值直接打开APP
                    lx = lx,
                    title = lx == 1 ? title.Value : "",
                    url = lx == 1 ? nrong.Value : "",
                    haoma = lx == 2 ? title.Value : "",
                    msg = lx == 2 ? nrong.Value : ""
                };
            }
            else
            {
                //单发
                if (!string.IsNullOrEmpty(Request.QueryString["alias"]))
                {
                    alias.Add(Request.QueryString["alias"]);
                    extras = new
                    {
                        lx = lx,
                        title = lx == 1 ? title.Value : "",
                        url = lx == 1 ? nrong.Value : "",
                        haoma = lx == 2 ? title.Value : "",
                        msg = lx == 2 ? nrong.Value : ""
                    };
                }
                else
                {
                    Common.JS.Alert("推送人不能为空", this);
                    return;
                }
            }
            //开始发送
            if (LJSheng.Data.JPush.sendpush(alias, title.Value, nrong.Value, extras))
            {
                Common.JS.Alert("推送成功", this);
            }
            else {
                Common.JS.Alert("推送失败", this);
            }
        }
    }
}