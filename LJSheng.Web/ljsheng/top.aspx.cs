using System;
using System.Data;
using LJSheng.Data.EF;
using System.Linq;

namespace LJSheng.Web.ljsheng
{
    public partial class top : CheckLoginPage
    {
        /// <summary> 
        /// TOP统计信息
        /// </summary> 
        protected void Page_Load(object sender, EventArgs e)
        {
            EFDB db = new EFDB();
            lj.InnerHtml = (db.lanjie.Sum(l => l.cishu)+700000).ToString();
            jb.InnerHtml = (db.jubao.Where(l=>l.zt==1).Count()+100).ToString();
            jc.InnerHtml = (db.jiance.Where(l => l.zt == 1).Count()+500).ToString();
            app.InnerHtml = (db.jpush.Count()+57000).ToString();
            qd.InnerHtml = (db.appapi.Where(l => l.ffm == "appstart").Count()+290000).ToString();
            yjfk.InnerHtml = db.yjfk.Where(l => l.zt == 2).Count().ToString();
        }
    }
}