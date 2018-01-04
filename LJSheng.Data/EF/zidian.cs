namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("zidian")]
    public partial class zidian
    {
        [Key]
        public Guid gid { get; set; }

        [Required]
        [StringLength(50)]
        public string zdlx { get; set; }

        [StringLength(200)]
        public string jshao { get; set; }

        public int px { get; set; }

        public DateTime? rukusj { get; set; }
    }
}
