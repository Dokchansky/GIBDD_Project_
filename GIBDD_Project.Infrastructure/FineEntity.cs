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
        [Column("ID")]
        public long ID { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [Column("Value")]
        [Required]
        [StringLength(2147483647)]
        public string Value { get; set; }

        [Column("Status")]
        [Required]
        [StringLength(2147483647)]
        public string Status { get; set; }

        [Column("TransportID")]
        public long TransportID { get; set; }

        public virtual TransportEntity Transport { get; set; }
    }
}
