namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("huiyuan")]
    public partial class huiyuan
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime rukusj { get; set; }

        [Required]
        [StringLength(50)]
        public string zhanghao { get; set; }

        [Required]
        [StringLength(50)]
        public string mima { get; set; }

        [StringLength(50)]
        public string openid { get; set; }

        [StringLength(50)]
        public string tupian { get; set; }

        [StringLength(50)]
        public string xingming { get; set; }

        [StringLength(50)]
        public string nicheng { get; set; }

        [StringLength(50)]
        public string shouji { get; set; }

        public int? xb { get; set; }
    }
}
