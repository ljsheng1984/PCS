namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("xinwen")]
    public partial class xinwen
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime? rukusj { get; set; }

        public int? lx { get; set; }

        [StringLength(50)]
        public string tupian { get; set; }

        [StringLength(200)]
        public string biaoti { get; set; }

        [StringLength(500)]
        public string fubiao { get; set; }

        [StringLength(200)]
        public string url { get; set; }

        public string nrong { get; set; }

        [StringLength(50)]
        public string laiyuan { get; set; }

        [StringLength(50)]
        public string zuozhe { get; set; }

        public int? fwl { get; set; }

        public int? xs { get; set; }

        public int? px { get; set; }
    }
}
