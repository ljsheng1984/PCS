using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using LJSheng.Data.EF;
using System.IO;
using System.Data;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class hylist : CheckLoginPage
    {
        //Func<huiyuan, bool> where;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // where= b => 1==1;
                ViewState["where"] = "";
            }
        }
        //数据绑定
        private void Bind()
        {
            //LVljsheng.DataSource = LJSheng.Data.EFOperation<huiyuan>.getPageDate(b => new { b.gid, b.csrq, b.zhanghao, b.xingbie, b.nianji, b.nicheng, b.rukusj, b.xingming, b.shouji }, where, b => b.rukusj, ((pager.StartRowIndex / pager.PageSize) + 1), pager.PageSize, true, out Total);
            DataSet ds = Data.Tables.Table_List("huiyuan", "rukusj DESC", "*", 88888, 1, ViewState["where"].ToString());
            LVljsheng.DataSource = ds;
            LVljsheng.DataBind();
        }

        //listviet操作
        protected void LVljsheng_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            EFDB db = new EFDB();
            Guid gid = Guid.Parse(((Label)e.Item.FindControl("gid")).Text);
            string zhanghao = ((Label)e.Item.FindControl("zhanghao")).Text;
            switch (e.CommandName)
            {
                case "del":
                    var b = db.huiyuan.Where(l => l.gid == gid).FirstOrDefault();
                    db.huiyuan.Attach(b);
                    db.huiyuan.Remove(b);
                    if (db.SaveChanges() != 1)
                    {
                        Common.JS.Alert("删除失败,请重试", this);
                    }
                    else
                    {
                        if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(Data.Helps.huiyuan + b.tupian)))
                            File.Delete(System.Web.HttpContext.Current.Server.MapPath(Data.Helps.huiyuan + b.tupian));
                    }
                    break;
                case "mima":
                    //更新操作
                    string mima = Common.RandStr.CreateValidateNumber(6);
                    var mm = db.huiyuan.Where(l => l.gid == gid).FirstOrDefault();
                    mm.mima = Common.MD5.GetMD5ljsheng(mima);
                    if (db.SaveChanges() == 1)
                    {
                        if (linjiansheng.dx(zhanghao, "系统已为你重置密码为:" + mima + ",请尽快登录即时修改", 1) != 200)
                        {
                            Common.JS.Alert("重置密码成功,但是短信通知用户失败", this);
                        }
                    }
                    else
                    {
                        Common.JS.Alert("重置密码失败,请重试!", this);
                    }
                    break;
                default:
                    break;
            }
            Bind();
        }

        protected void pager_PreRender(object sender, EventArgs e)
        {
            Bind();
        }
        protected void sel_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(zhanghao.Value.Trim()))
            {
                sb.Append(" AND zhanghao like '%" + zhanghao.Value.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(shouji.Value.Trim()))
            {
                sb.Append(" AND shouji like '%" + shouji.Value.Trim() + "%'");
            }
            //根据开始时间和结束时间查询
            if (!string.IsNullOrEmpty(kssj.Value) || !string.IsNullOrEmpty(jssj.Value))
            {
                //开始时间不为空
                if (!string.IsNullOrEmpty(kssj.Value) && string.IsNullOrEmpty(jssj.Value))
                {
                    jssj.Value = kssj.Value;
                }
                else if (!string.IsNullOrEmpty(jssj.Value) && string.IsNullOrEmpty(kssj.Value))
                {
                    kssj.Value = jssj.Value;
                }
                sb.Append(" AND rukusj >= '" + kssj.Value + " 00:00:00' AND rukusj <= '" + jssj.Value + " 23:59:59" + "'");
            }
            ViewState["where"] = sb.ToString().TrimStart(" AND ".ToCharArray());
        }
    }
}