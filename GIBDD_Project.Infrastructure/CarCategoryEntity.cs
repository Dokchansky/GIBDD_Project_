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
        [Column("ID")]
        public long ID { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }
    }
}
