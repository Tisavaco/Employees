using Employees.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<AppDbContext>();

            DependencyInjection.ServiceProvider = serviceCollection.BuildServiceProvider();

            var context = DependencyInjection.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }
    }
}
