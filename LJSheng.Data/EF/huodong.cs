namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("huodong")]
    public partial class huodong
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime rukusj { get; set; }

        public Guid hygid { get; set; }

        public int lx { get; set; }

        public int cishu { get; set; }

        public int zt { get; set; }

        [StringLength(50)]
        public string lxr { get; set; }

        [StringLength(50)]
        public string shouji { get; set; }

        [StringLength(100)]
        public string dizhi { get; set; }

        [StringLength(50)]
        public string jp { get; set; }
    }
}
