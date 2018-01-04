namespace LJSheng.Data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("apibug")]
    public partial class apibug
    {
        [Key]
        public Guid gid { get; set; }

        public DateTime? rukusj { get; set; }

        [StringLength(50)]
        public string ffm { get; set; }

        [StringLength(200)]
        public string mcheng { get; set; }

        [StringLength(800)]
        public string xiaoxi { get; set; }

        [StringLength(2000)]
        public string duizhai { get; set; }

        [StringLength(5000)]
        public string canshu { get; set; }

        [StringLength(20)]
        public string deskey { get; set; }
    }
}
