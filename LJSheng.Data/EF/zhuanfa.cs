namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("zhuanfa")]
    public partial class zhuanfa
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime rukusj { get; set; }

        public Guid hygid { get; set; }

        [Required]
        [StringLength(50)]
        public string tupian { get; set; }

        public int hdzt { get; set; }
    }
}
