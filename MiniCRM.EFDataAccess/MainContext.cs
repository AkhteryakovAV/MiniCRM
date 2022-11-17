using Microsoft.EntityFrameworkCore;
using MiniCRM.Domain.Enums;
using MiniCRM.Domain.Models;
using System;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(dbPath))
                Directory.CreateDirectory(dbPath);
            dbPath = Path.Combine(dbPath, "DataBase.db");
            optionsBuilder
                .UseSqlite("Data Source=" + dbPath);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid departmentId = Guid.NewGuid();
            Guid chiefId = Guid.NewGuid();

            modelBuilder.Entity<Department>().HasData(
                new Department()
                {
                    Id = departmentId,
                    ChiefId = chiefId,
                    Name = "Центральный офис"
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = chiefId,
                    Surname = "Иванов",
                    Name = "Иван",
                    MiddleName = "Иванович",
                    Birthday = new DateTime(1991, 7, 3),
                    Gender = Gender.Male,
                    DepartmentId = departmentId
                },
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    Surname = "Иванова",
                    Name = "Елена",
                    MiddleName = "Владимировна",
                    Birthday = new DateTime(2000, 3, 15),
                    Gender = Gender.Female,
                    DepartmentId = departmentId
                });

            modelBuilder.Entity<Tag>().HasData(
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = "Рубашки",
                },
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = "Одежда",
                },
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = "Обувь",
                },
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = "Шапки",
                });


            base.OnModelCreating(modelBuilder);
        }

    }
}
