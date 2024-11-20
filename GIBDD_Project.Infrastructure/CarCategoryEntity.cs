namespace GIBDD_Project.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarCategory")]
    public partial class CarCategoryEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarCategoryEntity()
        {
            Transport = new HashSet<TransportEntity>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportEntity> Transport { get; set; }
    }
}
