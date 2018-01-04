namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("dxmb")]
    public partial class dxmb
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime? rukusj { get; set; }

        public int? zt { get; set; }

        public int? lx { get; set; }

        public int? weihai { get; set; }

        [StringLength(500)]
        public string duanxin { get; set; }

        [StringLength(500)]
        public string gjz { get; set; }

        public int? cishu { get; set; }
    }
}
