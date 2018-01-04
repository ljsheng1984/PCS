﻿using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using LJSheng.Data.EF;
using EntityFramework.Extensions;
using System.IO;

namespace LJSheng.Web.ljsheng.lin
{
    public partial class yjtp : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                where();
            }
        }

        //数据绑定
        private void Bind()
        {
            LVljsheng.DataSource = Data.Tables.Table_List("View_yjtp", "rukusj DESC", "*",88888,1, ViewState["where"].ToString());
            LVljsheng.DataBind();
        }

        //listviet操作
        protected void LVljsheng_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            EFDB db = new EFDB();
            Guid gid = Guid.Parse(((Label)e.Item.FindControl("gid")).Text);
            var b = db.yjtp.Where(l => l.gid == gid).FirstOrDefault();
            switch (e.CommandName)
            {
                case "del":
                    if (db.yjtp.Where(l => l.gid == gid).Delete() != 1)
                    {
                        Common.JS.Alert("删除失败,请重试", this);
                    }
                    else
                    {
                        if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(Data.Helps.yjfk + b.tupian)))
                            File.Delete(System.Web.HttpContext.Current.Server.MapPath(Data.Helps.yjfk + b.tupian));
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
        protected void where()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                ViewState["where"] = "yjgid ='" + Request.QueryString["gid"] + "'";
            }
            else
            {
                ViewState["where"] = "";
            }
        }
        protected void sel_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(zhanghao.Value.Trim()))
            {
                sb.Append(" AND zhanghao like '%" + zhanghao.Value.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(wenti.Value.Trim()))
            {
                sb.Append(" AND wenti like '%" + wenti.Value.Trim() + "%'");
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
            where();
            if (String.IsNullOrEmpty(ViewState["where"].ToString()))
            {
                ViewState["where"] = sb.ToString().TrimStart(" AND ".ToCharArray());
            }
            else
            {
                ViewState["where"] += sb.ToString();
            }
        }
    }
}