using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using LJSheng.Data.EF;
using System.Data.Entity;
using System.Text;

namespace LJSheng.Web.ljsheng
{
    public partial class gjzlist : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["where"] = "";
            }
        }

        public string Getlx(string MsgType)
        {
            string str = "未知";
            switch (MsgType)
            {
                case "event"://事件
                    str = "事件";
                    break;
                case "text"://文本
                    str = "文本";
                    break;
                case "image"://图片
                    str = "图片";
                    break;
                case "voice": //声音
                    str = "声音";
                    break;
                case "video"://视频
                    str = "视频";
                    break;
                case "location"://地理位置
                    str = "地理位置";
                    break;
                case "link"://链接
                    str = "链接";
                    break;
                default:
                    break;
            }
            return str;
        }

        //数据绑定
        private void Bind()
        {
            LVljsheng.DataSource = LJSheng.Data.Tables.Table_List("wxgjz","rukusj DESC", "*", 888888, 1, ViewState["where"].ToString());
            LVljsheng.DataBind();
        }

        //listviet操作
        protected void LVljsheng_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (Request.Headers["accept"] == "*/*")
            {
                Common.JS.Alert("请勿刷新操作", this);
                return;
            }
            EFDB db = new EFDB();
            Guid gid = Guid.Parse(((Label)e.Item.FindControl("gid")).Text);
            switch (e.CommandName)
            {
                case "del":
                    var b = db.wxgjz.Where(l => l.gid == gid).FirstOrDefault();
                    db.Entry(b).State = EntityState.Deleted;
                    if (db.SaveChanges() != 1)
                    {
                        Common.JS.Alert("删除失败,请重试", this);
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
            if (!string.IsNullOrEmpty(gjz.Value.Trim()))
            {
                sb.Append(" AND gjz like '%" + gjz.Value + "%'");
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