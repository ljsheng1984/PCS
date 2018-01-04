namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("webmb")]
    public partial class webmb
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime? rukusj { get; set; }

        public int? zt { get; set; }

        public int? weihai { get; set; }

        [StringLength(200)]
        public string url { get; set; }
    }
}
