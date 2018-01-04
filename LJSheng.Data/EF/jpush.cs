namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("jpush")]
    public partial class jpush
    {
        [Key]
        public Guid gid { get; set; }

        public int lx { get; set; }

        [StringLength(50)]
        public string alias { get; set; }

        [StringLength(50)]
        public string registrationid { get; set; }

        public DateTime? rukusj { get; set; }
    }
}
