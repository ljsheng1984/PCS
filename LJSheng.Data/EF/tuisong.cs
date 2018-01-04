namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tuisong")]
    public partial class tuisong
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime? rukusj { get; set; }

        public int lx { get; set; }

        public string alias { get; set; }

        [StringLength(500)]
        public string title { get; set; }

        [StringLength(500)]
        public string nrong { get; set; }

        [StringLength(500)]
        public string extras { get; set; }

        [StringLength(20)]
        public string sendno { get; set; }

        [StringLength(8000)]
        public string ifacereturn { get; set; }

        [StringLength(50)]
        public string httpcode { get; set; }

        [StringLength(50)]
        public string messageid { get; set; }
    }
}
