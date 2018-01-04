namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("duanxin")]
    public partial class duanxin
    {
        [Key]
        public Guid gid { get; set; }

        public byte lx { get; set; }

        [Required]
        [StringLength(8000)]
        public string shouji { get; set; }

        [Required]
        [StringLength(500)]
        public string dxnr { get; set; }

        public int? tiaoshu { get; set; }

        public DateTime? rukusj { get; set; }

        [StringLength(500)]
        public string beizhu { get; set; }
    }
}
