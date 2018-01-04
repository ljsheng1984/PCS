namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("dianhua")]
    public partial class dianhua
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime? rukusj { get; set; }

        [StringLength(50)]
        public string haoma { get; set; }

        [StringLength(100)]
        public string xsmc { get; set; }

        public int? xs { get; set; }
    }
}
