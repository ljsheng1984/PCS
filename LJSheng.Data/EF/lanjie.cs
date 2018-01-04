namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("lanjie")]
    public partial class lanjie
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime? rukusj { get; set; }

        public int? lx { get; set; }

        public int? weihai { get; set; }

        [StringLength(50)]
        public string haoma { get; set; }

        [StringLength(2000)]
        public string duanxin { get; set; }

        [StringLength(20)]
        public string jingdu { get; set; }

        [StringLength(20)]
        public string weidu { get; set; }

        public int? cishu { get; set; }
    }
}
