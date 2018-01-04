namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ljsheng")]
    public partial class ljsheng
    {
        [Key]
        public Guid gid { get; set; }

        [StringLength(50)]
        public string zhanghao { get; set; }

        [StringLength(50)]
        public string mima { get; set; }

        public Guid? qxgid { get; set; }

        [StringLength(50)]
        public string shouji { get; set; }

        [StringLength(50)]
        public string xming { get; set; }

        [StringLength(50)]
        public string bumen { get; set; }

        public DateTime? rukusj { get; set; }
    }
}
