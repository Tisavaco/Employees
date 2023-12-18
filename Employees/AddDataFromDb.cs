using Employees.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public static class AddDataFromDb
    {
        public static void AddData()
        {
            var appDbContext = DependencyInjection.ServiceProvider.GetRequiredService<AppDbContext>();
            var organization = new Entity.Organization()
            {
                Name = "Динамика",
                INN = "987654321098",
                LegalAddress = "Москва, улица Климашкина, 21",
                ActualAddress = "Москва, улица Климашкина, 21"
            };
            appDbContext.Organizations.Add(organization);
            var employees = new Employees.Entity.Employees()
            {
                Organization = organization,
                Surname = "Иванов",
                Name = "Иван",
                MiddleName = "Иванович",
                BirthDate = DateTime.Parse("01.01.1990").Date,
                PassportSeries = 9010,
                PassportNumber = 348527
            };
            appDbContext.Employe.Add(employees);
            var employees1 = new Employees.Entity.Employees()
            {
                Organization = organization,
                Surname = "Александров",
                Name = "Александ",
                MiddleName = "Александрович",
                BirthDate = DateTime.Parse("01.01.1995").Date,
                PassportSeries = 9515,
                PassportNumber = 753652
            };
            appDbContext.Employe.Add(employees1);
            var organization1 = new Entity.Organization()
            {
                Name = "Рекурсия",
                INN = "935672593472",
                LegalAddress = "Москва, улица Петровка, 18",
                ActualAddress = "Москва, улица Петровка, 18"
            };
            appDbContext.Organizations.Add(organization1);
            var employees2 = new Employees.Entity.Employees()
            {
                Organization = organization1,
                Surname = "Петров",
                Name = "Петр",
                MiddleName = "Петрович",
                BirthDate = DateTime.Parse("01.01.1992").Date,
                PassportSeries = 9212,
                PassportNumber = 317363
            };
            appDbContext.Employe.Add(employees2);
            appDbContext.SaveChanges();
        }
    }
}
