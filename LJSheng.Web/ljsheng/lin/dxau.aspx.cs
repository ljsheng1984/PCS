using System;
using System.Linq;
using LJSheng.Data.EF;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using EntityFramework.Extensions;
using System.Text.RegularExpressions;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class dxau : CheckLoginPage
    {
        private static Regex Regsj = new Regex("(1[34578]\\d{9}\\s*|\\s*)*(1[34578]\\d{9})");
        private static Regex Regurl = new Regex("((http|ftp|https)://)(([a-zA-Z0-9\\._-]+\\.[a-zA-Z]{2,6})|([0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}))(:[0-9]{1,4})*(/[a-zA-Z0-9\\&%_\\./-~-]*)?");
        private static Regex Regyhk = new Regex("62\\d{17}|\\d{14}");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdxlx();
                EFDB db = new EFDB();
                Guid gid;
                if (!String.IsNullOrEmpty(Request.QueryString["gid"]))
                {
                    gid = Guid.Parse(Request.QueryString["gid"]);
                    var b = db.dxmb.Where(l => l.gid == gid).FirstOrDefault();
                    if (b != null)
                    {
                        gjz.Value = string.IsNullOrEmpty(b.gjz) ? Regdx(b.duanxin) : b.gjz;
                        duanxin.Value = b.duanxin;
                        weihai.Value = b.weihai.ToString();
                        //cishu.Value = b.cishu.ToString();
                        ztRB.Items.FindByValue(b.zt.ToString()).Selected = true;
                        lxRB.Items.FindByValue(b.lx.ToString()).Selected = true;
                    }
                }
                else if (!String.IsNullOrEmpty(Request.QueryString["jcgid"]))
                {
                    gid = Guid.Parse(Request.QueryString["jcgid"]);
                    var b = db.jiance.Where(l => l.gid == gid).FirstOrDefault();
                    if (b != null)
                    {
                        gjz.Value = Regdx(b.duanxin);
                        duanxin.Value = b.duanxin;
                        weihai.Value = b.weihai.ToString();
                        //cishu.Value = b.cishu.ToString();
                        //lxRB.Items.FindByValue(b.lx.ToString()).Selected = true;
                    }
                }
                else if (!String.IsNullOrEmpty(Request.QueryString["jbgid"]))
                {
                    gid = Guid.Parse(Request.QueryString["jbgid"]);
                    var b = db.jubao.Where(l => l.gid == gid).FirstOrDefault();
                    if (b != null)
                    {
                        gjz.Value = Regdx(b.duanxin);
                        duanxin.Value = b.duanxin;
                        weihai.Value = b.weihai.ToString();
                        //cishu.Value = b.cishu.ToString();
                        //lxRB.Items.FindByValue(b.lx.ToString()).Selected = true;
                    }
                }
            }
        }
        /// <summary>
        /// 截取短信里诈骗关键字
        /// </summary>
        public string Regdx(string duanxin)
        {
            Match url = Regurl.Match(duanxin);
            Match sj = Regsj.Match(duanxin);
            Match yhk = Regyhk.Match(duanxin);
            string urlstr = url.Success ? url.Value + "|" : "";
            string sjstr = sj.Success ? sj.Value + "|" : "";
            string yhkstr = yhk.Success ? yhk.Value + "|" : "";
            return (urlstr + sjstr + yhkstr).TrimEnd('|');
        }
        /// <summary>
        /// 获取防骗短信类型
        /// </summary>
        public void getdxlx()
        {
            List<object> list = new List<object>();
            foreach (string n in Enum.GetNames(typeof(Data.Helps.dxlx)))
            {
                Data.Helps.dxlx lx = (Data.Helps.dxlx)Enum.Parse(typeof(Data.Helps.dxlx), n, true);
                lxRB.Items.Add(new ListItem(n, ((int)lx).ToString()));
            }
            lxRB.Items[0].Selected = true;
        }

        protected void tijiao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(duanxin.Value) || string.IsNullOrEmpty(gjz.Value))
            {
                Common.JS.Alert("短信内容和关键字不能为空", this);
            }
            else
            {
                EFDB db = new EFDB();
                if (db.dxmb.Where(l => l.duanxin.Trim() == duanxin.Value.Trim()).Count() > 0 && (!String.IsNullOrEmpty(Request.QueryString["jcgid"]) || !String.IsNullOrEmpty(Request.QueryString["jbgid"])))
                {
                    Guid gid;
                    if (!String.IsNullOrEmpty(Request.QueryString["jcgid"]))
                    {
                        gid = Guid.Parse(Request.QueryString["jcgid"]);
                        db.jiance.Where(l => l.gid == gid).Update(l => new Data.EF.jiance { zt = 2 });
                    }
                    else if (!String.IsNullOrEmpty(Request.QueryString["jbgid"]))
                    {
                        gid = Guid.Parse(Request.QueryString["jbgid"]);
                        db.jubao.Where(l => l.gid == gid).Update(l => new Data.EF.jubao { zt = 2 });
                    }
                    Common.JS.Alert("已存在", this);
                }
                else
                {
                    dxmb ef;
                    if (String.IsNullOrEmpty(Request.QueryString["gid"]))
                    {
                        ef = new dxmb();
                        ef.gid = Guid.NewGuid();
                        ef.rukusj = DateTime.Now;
                    }
                    else
                    {
                        Guid gid = Guid.Parse(Request.QueryString["gid"]);
                        ef = db.dxmb.Where(l => l.gid == gid).FirstOrDefault();
                    }
                    ef.duanxin = duanxin.Value;
                    ef.gjz = gjz.Value.Trim().Replace("+", "").Replace("[", "").Replace("]", "").Replace("(", "").Replace(")", "").TrimEnd('|');
                    ef.weihai = int.Parse(weihai.Value);
                    //ef.cishu = int.Parse(cishu.Value);
                    ef.zt = int.Parse(ztRB.SelectedValue);
                    ef.lx = int.Parse(lxRB.SelectedValue);
                    if (String.IsNullOrEmpty(Request.QueryString["gid"]))
                    {
                        db.dxmb.Add(ef);
                    }
                    if (db.SaveChanges() == 1)
                    {
                        Guid gid;
                        if (!String.IsNullOrEmpty(Request.QueryString["jcgid"]))
                        {
                            gid = Guid.Parse(Request.QueryString["jcgid"]);
                            db.jiance.Where(l => l.gid == gid).Update(l => new Data.EF.jiance { zt = 2 });
                        }
                        else if (!String.IsNullOrEmpty(Request.QueryString["jbgid"]))
                        {
                            gid = Guid.Parse(Request.QueryString["jbgid"]);
                            db.jubao.Where(l => l.gid == gid).Update(l => new Data.EF.jubao { zt = 2 });
                        }
                        db.zdlb.Where(l => l.jian == "dxmb").Update(l => new zdlb { zhi = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });
                        Common.JS.Alert("操作成功", this);
                    }
                    else
                    {
                        Common.JS.Alert("操作失败,你可能更改的数据和旧数据一样,请重试!", this);
                    }
                }
            }
        }
    }
}