namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("dhmb")]
    public partial class dhmb
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime? rukusj { get; set; }

        public int? zt { get; set; }

        public int? weihai { get; set; }

        [StringLength(100)]
        public string dianhua { get; set; }
    }
}
