namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("wxgjz")]
    public partial class wxgjz
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime rukusj { get; set; }

        public int lx { get; set; }

        [Required]
        [StringLength(50)]
        public string gjz { get; set; }

        [Required]
        [StringLength(500)]
        public string huifu { get; set; }
    }
}
