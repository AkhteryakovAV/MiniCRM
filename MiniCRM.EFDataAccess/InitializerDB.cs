using MiniCRM.Domain.Enums;
using MiniCRM.Domain.Models;
using System;
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
                Surname = "Иванова",
                Name = "Елена",
                MiddleName = "Владимировна",
                Birthday = new DateTime(2000, 3, 15),
                Gender = Gender.Female,
                DepartmentId = departmentId
            };

            Tag tag1 = new Tag()
            {
                Id = Guid.NewGuid(),
                Name = "Рубашки",
            };
            Tag tag2 = new Tag()
            {
                Id = Guid.NewGuid(),
                Name = "Одежда",
            };
            Tag tag3 = new Tag()
            {
                Id = Guid.NewGuid(),
                Name = "Обувь",
            };
            Tag tag4 = new Tag()
            {
                Id = Guid.NewGuid(),
                Name = "Шапки",
            };


            _db.Departments.Add(department);
            _db.SaveChanges();
            _db.Employees.AddRange(new Employee[] { chief, employee1 });
            _db.SaveChanges();
            department.ChiefId = chiefId;
            _db.SaveChanges();
            _db.Tags.AddRange(new Tag[] { tag1, tag2, tag3, tag4 });
            _db.SaveChanges();

        }

    }
}
