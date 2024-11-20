namespace GIBDD_Project.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fine")]
    public partial class FineEntity
    {
        public long ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Value { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Status { get; set; }

        public long TransportID { get; set; }

        public virtual TransportEntity Transport { get; set; }
    }
}
