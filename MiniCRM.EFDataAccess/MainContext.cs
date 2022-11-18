using MiniCRM.Domain.Models;
using System.Data.Entity;
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
                .HasMany(p => p.Staff)
                .WithOptional(p => p.Department)
                .HasForeignKey(s => s.DepartmentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.Orders)
                .WithMany(o => o.Tags);

            base.OnModelCreating(modelBuilder);
        }
        public bool IsNew<TEntity>(TEntity entity) where TEntity : class
        {
            return !this.Set<TEntity>().Local.Any(e => e == entity);
        }
    }
}
