namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("yjtp")]
    public partial class yjtp
    {
        [Key]
        public Guid gid { get; set; }

        public Guid? yjgid { get; set; }

        [StringLength(50)]
        public string tupian { get; set; }

        public DateTime? rukusj { get; set; }
    }
}
