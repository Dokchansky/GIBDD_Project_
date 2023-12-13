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

        [Column("ID")]
        public long ID { get; set; }

        [Column("SurName")]
        [Required]
        [StringLength(2147483647)]
        public string SurName { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [Column("Patronymic")]
        [Required]
        [StringLength(2147483647)]
        public string Patronymic { get; set; }

        [Column("Birthday")]
        [Required]
        [StringLength(2147483647)]
        public string Birthday { get; set; }

        [Column("Gender")]
        [Required]
        [StringLength(2147483647)]
        public string Gender { get; set; }

        [Column("Login")]
        [Required]
        [StringLength(2147483647)]
        public string Login { get; set; }

        [Column("Password")]
        [Required]
        [StringLength(2147483647)]
        public string Password { get; set; }

        [Column("RoleID")]
        public long RoleID { get; set; }

        public virtual RoleEntity Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportEntity> Transport { get; set; }
    }
}
