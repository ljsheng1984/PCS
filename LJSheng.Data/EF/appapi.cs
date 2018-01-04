namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("appapi")]
    public partial class appapi
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime? rukusj { get; set; }

        [StringLength(50)]
        public string ffm { get; set; }

        public int? sjxt { get; set; }

        [StringLength(20)]
        public string bbh { get; set; }

        [StringLength(100)]
        public string sjxh { get; set; }

        [StringLength(50)]
        public string imei { get; set; }

        [StringLength(200)]
        public string dizhi { get; set; }

        [StringLength(20)]
        public string jingdu { get; set; }

        [StringLength(20)]
        public string weidu { get; set; }

        public int? haoshi { get; set; }
    }
}
