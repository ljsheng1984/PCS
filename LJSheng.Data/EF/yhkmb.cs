namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("yhkmb")]
    public partial class yhkmb
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime? rukusj { get; set; }

        public int? zt { get; set; }

        public int? weihai { get; set; }

        [StringLength(50)]
        public string yhk { get; set; }
    }
}
