namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("app")]
    public partial class app
    {
        [Key]
        public Guid gid { get; set; }

        public int sjxt { get; set; }

        [Required]
        [StringLength(20)]
        public string bbh { get; set; }

        public int nbbbh { get; set; }

        public int sfgx { get; set; }

        [StringLength(200)]
        public string gxnr { get; set; }

        [StringLength(100)]
        public string url { get; set; }

        public DateTime rukusj { get; set; }
    }
}
