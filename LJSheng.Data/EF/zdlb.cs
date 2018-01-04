namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("zdlb")]
    public partial class zdlb
    {
        [Key]
        public Guid gid { get; set; }

        public Guid zdgid { get; set; }

        [Required]
        [StringLength(50)]
        public string jian { get; set; }

        [Required]
        [StringLength(50)]
        public string zhi { get; set; }

        [StringLength(200)]
        public string jshao { get; set; }

        public int px { get; set; }

        public DateTime? rukusj { get; set; }
    }
}
