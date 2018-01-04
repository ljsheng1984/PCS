using System;
using System.Linq;
using LJSheng.Data.EF;
using System.Data;
using System.Text;

namespace LJSheng.Web.ljsheng
{
    public partial class gjzau : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["where"] = "";
                if (!String.IsNullOrEmpty(Request.QueryString["gid"]))
                {
                    EFDB db = new EFDB();
                    Guid gid = Guid.Parse(Request.QueryString["gid"]);
                    var b = db.wxgjz.Where(l => l.gid == gid).FirstOrDefault();
                    if (b != null)
                    {
                        gjz.Value = b.gjz;
                        lxRB.Items.FindByValue(b.lx.ToString()).Selected = true;
                        if (b.lx != 1)
                        {
                            huifu.Value = b.huifu;
                        }
                    }
                }
            }
        }

        protected void tijiao_Click(object sender, EventArgs e)
        {
            if (Request.Headers["accept"] == "*/*")
            {
                return;
            }
            EFDB db = new EFDB();
            if (!String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                Guid gid = Guid.Parse(Request.QueryString["gid"]);
                //更新操作
                var b = db.wxgjz.Where(l => l.gid == gid).FirstOrDefault();
                b.gjz = gjz.Value.Trim();
                b.lx = LJSheng.Common.LCommon.StringToInt(lxRB.SelectedValue);
                b.huifu = huifu.Value;
                if (db.SaveChanges() == 1)
                {
                    LJSheng.Common.JS.AlertAndRedirect("操作成功", "gjzlist.aspx", this);
                }
                else
                { LJSheng.Common.JS.Alert("操作失败,你可能更改的数据和旧数据一样,请重试", this); }
            }
            else
            {
                //增加操作
                Guid gid = Guid.NewGuid();
                var b = new wxgjz
                {
                    gid = gid,
                    gjz = gjz.Value.Trim(),
                    lx = LJSheng.Common.LCommon.StringToInt(lxRB.SelectedValue),
                    huifu = huifu.Value,
                    rukusj = DateTime.Now
                };

                db.wxgjz.Add(b);
                if (db.SaveChanges() == 1)
                {
                    LJSheng.Common.JS.AlertAndRedirect("操作成功", "gjzlist.aspx", this);
                }
                else
                { LJSheng.Common.JS.Alert("操作失败,请重试", this); }
            }
        }

        //数据绑定
        private void Bind()
        {
            LVljsheng.DataSource = LJSheng.Data.Tables.Table_List("xinwen", "rukusj DESC", "*", 888888, 1, ViewState["where"].ToString());
            LVljsheng.DataBind();
        }

        protected void pager_PreRender(object sender, EventArgs e)
        {
            Bind();
        }

        protected void sel_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(biaoti.Value.Trim()))
            {
                sb.Append(" AND biaoti like '%" + biaoti.Value + "%'");
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