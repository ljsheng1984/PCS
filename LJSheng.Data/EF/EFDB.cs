namespace LJSheng.Data.EF
{
    using System.Data.Entity;

    public partial class EFDB : DbContext
    {
        public EFDB()
            : base("name=SQL")
        {
        }

        public virtual DbSet<apibug> apibug { get; set; }
        public virtual DbSet<app> app { get; set; }
        public virtual DbSet<appapi> appapi { get; set; }
        public virtual DbSet<dhmb> dhmb { get; set; }
        public virtual DbSet<dianhua> dianhua { get; set; }
        public virtual DbSet<duanxin> duanxin { get; set; }
        public virtual DbSet<dxmb> dxmb { get; set; }
        public virtual DbSet<huiyuan> huiyuan { get; set; }
        public virtual DbSet<huodong> huodong { get; set; }
        public virtual DbSet<jiance> jiance { get; set; }
        public virtual DbSet<jpush> jpush { get; set; }
        public virtual DbSet<jubao> jubao { get; set; }
        public virtual DbSet<lanjie> lanjie { get; set; }
        public virtual DbSet<ljsheng> ljsheng { get; set; }
        public virtual DbSet<tuisong> tuisong { get; set; }
        public virtual DbSet<webmb> webmb { get; set; }
        public virtual DbSet<wxgjz> wxgjz { get; set; }
        public virtual DbSet<xinwen> xinwen { get; set; }
        public virtual DbSet<yhkmb> yhkmb { get; set; }
        public virtual DbSet<yjfk> yjfk { get; set; }
        public virtual DbSet<yjtp> yjtp { get; set; }
        public virtual DbSet<zdlb> zdlb { get; set; }
        public virtual DbSet<zhuanfa> zhuanfa { get; set; }
        public virtual DbSet<zidian> zidian { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<apibug>()
                .Property(e => e.ffm)
                .IsUnicode(false);

            modelBuilder.Entity<apibug>()
                .Property(e => e.mcheng)
                .IsUnicode(false);

            modelBuilder.Entity<apibug>()
                .Property(e => e.xiaoxi)
                .IsUnicode(false);

            modelBuilder.Entity<apibug>()
                .Property(e => e.duizhai)
                .IsUnicode(false);

            modelBuilder.Entity<apibug>()
                .Property(e => e.canshu)
                .IsUnicode(false);

            modelBuilder.Entity<apibug>()
                .Property(e => e.deskey)
                .IsUnicode(false);

            modelBuilder.Entity<app>()
                .Property(e => e.bbh)
                .IsUnicode(false);

            modelBuilder.Entity<app>()
                .Property(e => e.gxnr)
                .IsUnicode(false);

            modelBuilder.Entity<app>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<appapi>()
                .Property(e => e.ffm)
                .IsUnicode(false);

            modelBuilder.Entity<appapi>()
                .Property(e => e.bbh)
                .IsUnicode(false);

            modelBuilder.Entity<appapi>()
                .Property(e => e.sjxh)
                .IsUnicode(false);

            modelBuilder.Entity<appapi>()
                .Property(e => e.imei)
                .IsUnicode(false);

            modelBuilder.Entity<appapi>()
                .Property(e => e.dizhi)
                .IsUnicode(false);

            modelBuilder.Entity<appapi>()
                .Property(e => e.jingdu)
                .IsUnicode(false);

            modelBuilder.Entity<appapi>()
                .Property(e => e.weidu)
                .IsUnicode(false);

            modelBuilder.Entity<dhmb>()
                .Property(e => e.dianhua)
                .IsUnicode(false);

            modelBuilder.Entity<dianhua>()
                .Property(e => e.haoma)
                .IsUnicode(false);

            modelBuilder.Entity<dianhua>()
                .Property(e => e.xsmc)
                .IsUnicode(false);

            modelBuilder.Entity<duanxin>()
                .Property(e => e.shouji)
                .IsUnicode(false);

            modelBuilder.Entity<duanxin>()
                .Property(e => e.dxnr)
                .IsUnicode(false);

            modelBuilder.Entity<duanxin>()
                .Property(e => e.beizhu)
                .IsUnicode(false);

            modelBuilder.Entity<dxmb>()
                .Property(e => e.duanxin)
                .IsUnicode(false);

            modelBuilder.Entity<dxmb>()
                .Property(e => e.gjz)
                .IsUnicode(false);

            modelBuilder.Entity<huiyuan>()
                .Property(e => e.zhanghao)
                .IsUnicode(false);

            modelBuilder.Entity<huiyuan>()
                .Property(e => e.mima)
                .IsUnicode(false);

            modelBuilder.Entity<huiyuan>()
                .Property(e => e.openid)
                .IsUnicode(false);

            modelBuilder.Entity<huiyuan>()
                .Property(e => e.tupian)
                .IsUnicode(false);

            modelBuilder.Entity<huiyuan>()
                .Property(e => e.xingming)
                .IsUnicode(false);

            modelBuilder.Entity<huiyuan>()
                .Property(e => e.nicheng)
                .IsUnicode(false);

            modelBuilder.Entity<huiyuan>()
                .Property(e => e.shouji)
                .IsUnicode(false);

            modelBuilder.Entity<huodong>()
                .Property(e => e.lxr)
                .IsUnicode(false);

            modelBuilder.Entity<huodong>()
                .Property(e => e.shouji)
                .IsUnicode(false);

            modelBuilder.Entity<huodong>()
                .Property(e => e.dizhi)
                .IsUnicode(false);

            modelBuilder.Entity<huodong>()
                .Property(e => e.jp)
                .IsUnicode(false);

            modelBuilder.Entity<jiance>()
                .Property(e => e.duanxin)
                .IsUnicode(false);

            modelBuilder.Entity<jiance>()
                .Property(e => e.jingdu)
                .IsUnicode(false);

            modelBuilder.Entity<jiance>()
                .Property(e => e.weidu)
                .IsUnicode(false);

            modelBuilder.Entity<jpush>()
                .Property(e => e.alias)
                .IsUnicode(false);

            modelBuilder.Entity<jpush>()
                .Property(e => e.registrationid)
                .IsUnicode(false);

            modelBuilder.Entity<jubao>()
                .Property(e => e.haoma)
                .IsUnicode(false);

            modelBuilder.Entity<jubao>()
                .Property(e => e.duanxin)
                .IsUnicode(false);

            modelBuilder.Entity<jubao>()
                .Property(e => e.gjz)
                .IsUnicode(false);

            modelBuilder.Entity<jubao>()
                .Property(e => e.jingdu)
                .IsUnicode(false);

            modelBuilder.Entity<jubao>()
                .Property(e => e.weidu)
                .IsUnicode(false);

            modelBuilder.Entity<lanjie>()
                .Property(e => e.haoma)
                .IsUnicode(false);

            modelBuilder.Entity<lanjie>()
                .Property(e => e.duanxin)
                .IsUnicode(false);

            modelBuilder.Entity<lanjie>()
                .Property(e => e.jingdu)
                .IsUnicode(false);

            modelBuilder.Entity<lanjie>()
                .Property(e => e.weidu)
                .IsUnicode(false);

            modelBuilder.Entity<ljsheng>()
                .Property(e => e.zhanghao)
                .IsUnicode(false);

            modelBuilder.Entity<ljsheng>()
                .Property(e => e.mima)
                .IsUnicode(false);

            modelBuilder.Entity<ljsheng>()
                .Property(e => e.shouji)
                .IsUnicode(false);

            modelBuilder.Entity<ljsheng>()
                .Property(e => e.xming)
                .IsUnicode(false);

            modelBuilder.Entity<ljsheng>()
                .Property(e => e.bumen)
                .IsUnicode(false);

            modelBuilder.Entity<tuisong>()
                .Property(e => e.alias)
                .IsUnicode(false);

            modelBuilder.Entity<tuisong>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<tuisong>()
                .Property(e => e.nrong)
                .IsUnicode(false);

            modelBuilder.Entity<tuisong>()
                .Property(e => e.extras)
                .IsUnicode(false);

            modelBuilder.Entity<tuisong>()
                .Property(e => e.sendno)
                .IsUnicode(false);

            modelBuilder.Entity<tuisong>()
                .Property(e => e.ifacereturn)
                .IsUnicode(false);

            modelBuilder.Entity<tuisong>()
                .Property(e => e.httpcode)
                .IsUnicode(false);

            modelBuilder.Entity<tuisong>()
                .Property(e => e.messageid)
                .IsUnicode(false);

            modelBuilder.Entity<webmb>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<wxgjz>()
                .Property(e => e.gjz)
                .IsUnicode(false);

            modelBuilder.Entity<wxgjz>()
                .Property(e => e.huifu)
                .IsUnicode(false);

            modelBuilder.Entity<xinwen>()
                .Property(e => e.tupian)
                .IsUnicode(false);

            modelBuilder.Entity<xinwen>()
                .Property(e => e.biaoti)
                .IsUnicode(false);

            modelBuilder.Entity<xinwen>()
                .Property(e => e.fubiao)
                .IsUnicode(false);

            modelBuilder.Entity<xinwen>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<xinwen>()
                .Property(e => e.nrong)
                .IsUnicode(false);

            modelBuilder.Entity<xinwen>()
                .Property(e => e.laiyuan)
                .IsUnicode(false);

            modelBuilder.Entity<xinwen>()
                .Property(e => e.zuozhe)
                .IsUnicode(false);

            modelBuilder.Entity<yhkmb>()
                .Property(e => e.yhk)
                .IsUnicode(false);

            modelBuilder.Entity<yjfk>()
                .Property(e => e.wenti)
                .IsUnicode(false);

            modelBuilder.Entity<yjfk>()
                .Property(e => e.huifu)
                .IsUnicode(false);

            modelBuilder.Entity<yjfk>()
                .Property(e => e.lxfs)
                .IsUnicode(false);

            modelBuilder.Entity<yjfk>()
                .Property(e => e.beizhu)
                .IsUnicode(false);

            modelBuilder.Entity<yjtp>()
                .Property(e => e.tupian)
                .IsUnicode(false);

            modelBuilder.Entity<zdlb>()
                .Property(e => e.jian)
                .IsUnicode(false);

            modelBuilder.Entity<zdlb>()
                .Property(e => e.zhi)
                .IsUnicode(false);

            modelBuilder.Entity<zdlb>()
                .Property(e => e.jshao)
                .IsUnicode(false);

            modelBuilder.Entity<zhuanfa>()
                .Property(e => e.tupian)
                .IsUnicode(false);

            modelBuilder.Entity<zidian>()
                .Property(e => e.zdlx)
                .IsUnicode(false);

            modelBuilder.Entity<zidian>()
                .Property(e => e.jshao)
                .IsUnicode(false);
        }
    }
}
