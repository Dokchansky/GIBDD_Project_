namespace GIBDD_Project.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIBDD")]
    public partial class GIBDDEntity
    {
        [Column("ID")]
        public long ID { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [Column("Address")]
        [Required]
        [StringLength(2147483647)]
        public string Address { get; set; }

        [Column("StartWork")]
        [Required]
        [StringLength(2147483647)]
        public string StartWork { get; set; }

        [Column("StopWork")]
        [Required]
        [StringLength(2147483647)]
        public string StopWork { get; set; }
    }
}
