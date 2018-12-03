using App.Domain.Entities;
using App.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<SecurityRole> SecurityRoles { get; set; }

        public DbSet<PermissionUserAssociation> PermissionUserAssociations { get; set; }

        public DbSet<SecurityRoleUserAssociation> SecurityRoleUserAssociations { get; set; }

        public DbSet<SecurityRolePermissionAssociation> SecurityRolePermissionAssociations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfiguration();
        }
    }
}
