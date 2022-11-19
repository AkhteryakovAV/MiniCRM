using MiniCRM.Domain.Enums;
using MiniCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MiniCRM.EFDataAccess
{
    public class InitializerDB : DropCreateDatabaseIfModelChanges<MainContext>
    {
        protected override void Seed(MainContext _db)
        {
            Guid departmentId = Guid.NewGuid();
            Guid chiefId = Guid.NewGuid();

            Department department = new Department()
            {
                Id = departmentId,
                Name = "Центральный офис"
            };

            Employee chief = new Employee()
            {
                Id = chiefId,
                Surname = "Иванов",
                Name = "Иван",
                MiddleName = "Иванович",
                Birthday = new DateTime(1991, 7, 3),
                Gender = Gender.Male,
                DepartmentId = departmentId
            };

            Employee employee1 = new Employee()
            {
                Id = Guid.NewGuid(),
                Surname = "Сидорова",
                Name = "Елена",
                MiddleName = "Владимировна",
                Birthday = new DateTime(2000, 3, 15),
                Gender = Gender.Female,
                DepartmentId = departmentId
            };

            Tag tag1 = new Tag()
            {
                Id = Guid.NewGuid(),
                Name = "Тег 1",
            };
            Tag tag2 = new Tag()
            {
                Id = Guid.NewGuid(),
                Name = "Тег 2",
            };
            Tag tag3 = new Tag()
            {
                Id = Guid.NewGuid(),
                Name = "Тег 3",
            };
            Tag tag4 = new Tag()
            {
                Id = Guid.NewGuid(),
                Name = "Тег 4",
            };

            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee1.Id,
                Product = "Заказ 1",
                Tags = new List<Tag>() { tag1, tag2 }
            };
            Order order1 = new Order()
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee1.Id,
                Product = "Заказ 2",
                Tags = new List<Tag>() { tag3, tag2, tag4 }
            };
            Order order2 = new Order()
            {
                Id = Guid.NewGuid(),
                EmployeeId = chiefId,
                Product = "Заказ 3",
                Tags = new List<Tag>() { tag3, tag4 }
            };

            _db.Departments.Add(department);
            _db.SaveChanges();
            _db.Employees.AddRange(new Employee[] { chief, employee1 });
            _db.SaveChanges();
            department.ChiefId = chiefId;
            _db.SaveChanges();
            _db.Tags.AddRange(new Tag[] { tag1, tag2, tag3, tag4 });
            _db.SaveChanges();
            _db.Orders.AddRange(new Order[] { order, order1, order2 });
            _db.SaveChanges();
        }

    }
}
