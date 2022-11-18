using MiniCRM.Domain.Enums;
using MiniCRM.Domain.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;


namespace MiniCRM.EFDataAccess
{
    public class MainContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public MainContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new InitializerDB());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Staff)
                .WithRequired(e => e.Department)
                .HasForeignKey(e=>e.DepartmentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.Orders)
                .WithMany(o => o.Tags);

            base.OnModelCreating(modelBuilder);
        }

    }
}
