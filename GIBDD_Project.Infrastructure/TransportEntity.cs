namespace GIBDD_Project.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transport")]
    public partial class TransportEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TransportEntity()
        {
            Fine = new HashSet<FineEntity>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string StateNumber { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Status { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Year { get; set; }

        public long UserID { get; set; }

        public long BrandID { get; set; }

        public long CarCategoryID { get; set; }

        public virtual BrandEntity Brand { get; set; }

        public virtual CarCategoryEntity CarCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FineEntity> Fine { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
