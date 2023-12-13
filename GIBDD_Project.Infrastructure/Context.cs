using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GIBDD_Project.Infrastructure
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<BrandEntity> Brands { get; set; }
        public virtual DbSet<CarCategoryEntity> CarCategories { get; set; }
        public virtual DbSet<FineEntity> Fines { get; set; }
        public virtual DbSet<GIBDDEntity> GIBDDs { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<TransportEntity> Transports { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandEntity>()
                .HasMany(e => e.Transport)
                .WithRequired(e => e.Brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoleEntity>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransportEntity>()
                .HasMany(e => e.Fine)
                .WithRequired(e => e.Transport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserEntity>()
                .HasMany(e => e.Transport)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
