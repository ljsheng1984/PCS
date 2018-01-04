namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("yjfk")]
    public partial class yjfk
    {
        [Key]
        public Guid gid { get; set; }

        [StringLength(500)]
        public string wenti { get; set; }

        [StringLength(500)]
        public string huifu { get; set; }

        [StringLength(50)]
        public string lxfs { get; set; }

        public DateTime? hfsj { get; set; }

        [StringLength(50)]
        public string beizhu { get; set; }

        public int? zt { get; set; }

        public DateTime? rukusj { get; set; }
    }
}
