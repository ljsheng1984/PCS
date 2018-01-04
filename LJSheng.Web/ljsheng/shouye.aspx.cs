using EntityFramework.Extensions;
using LJSheng.Data.EF;
using System;
using System.Linq;

namespace LJSheng.Web.ljsheng
{
    public partial class shouye : CheckLoginPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EFDB db = new EFDB();
                biaoti.Value = db.zdlb.Where(l => l.jian == "biaoti").FirstOrDefault().zhi;
            }
        }

        protected void ok_Click(object sender, EventArgs e)
        {
            EFDB db = new EFDB();
            if (db.zdlb.Where(l => l.jian == "biaoti").Update(l => new zdlb { zhi = biaoti.Value }) != 1)
            {
                LJSheng.Common.JS.Alert("设置失败", this);
            }
        }
    }
}