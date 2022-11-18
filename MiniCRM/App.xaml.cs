using MiniCRM.Domain;
using MiniCRM.Domain.Models;
using MiniCRM.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MiniCRM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (MainContext mainContext = new MainContext(connectionString))
            {
                IRepository<Employee> repository = new EFRepository<Employee>(mainContext);
                Employee[] employees = repository.GetAll();
            }
        }
    }
}
