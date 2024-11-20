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
        public long ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Address { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string StartWork { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string StopWork { get; set; }
    }
}
