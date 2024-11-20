namespace GIBDD_Project.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class UserEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserEntity()
        {
            Transport = new HashSet<TransportEntity>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string SurName { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Birthday { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Gender { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Login { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Password { get; set; }

        public long RoleID { get; set; }

        public virtual RoleEntity Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportEntity> Transport { get; set; }
    }
}
