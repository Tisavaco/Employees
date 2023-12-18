using Employees.Entity;
using Employees.Repositories.OdjectClass;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Repositories.MyConverters
{
    public static class ConvertEmployesCSV
    {
        public static List<EmployesCSV> Convert(List<Employees.Entity.Employees> employees)
        {
            var appDbContext = DependencyInjection.ServiceProvider.GetRequiredService<AppDbContext>();
            var employesCSV = new List<EmployesCSV>();
            foreach (var item in employees) 
            {
                var organization = appDbContext.Organizations.Single(p => p.Id == item.OrganizationId);
                var employes = new EmployesCSV()
                {
                    Surname = item.Surname,
                    Name = item.Name,
                    MiddleName = item.MiddleName,
                    BirthDate = item.BirthDate.Date,
                    PassportSeries = item.PassportSeries,
                    PassportNumber = item.PassportNumber,
                    OrganizationName = organization.Name,
                    INN = organization.INN,
                    LegalAddress = organization.LegalAddress,
                    ActualAddress = organization.ActualAddress
                };
                employesCSV.Add(employes);
            }
            return employesCSV;
        }
        public static void ConvertTo(IEnumerable<EmployesCSV> employesCSVs)
        {
            var appDbContext = DependencyInjection.ServiceProvider.GetRequiredService<AppDbContext>();
            foreach (var item in employesCSVs)
            {
                var organization = new Entity.Organization()
                {
                    Name = item.OrganizationName,
                    INN = item.INN,
                    LegalAddress = item.LegalAddress,
                    ActualAddress = item.ActualAddress
                };
                if (!appDbContext.Organizations.Any(p => p.INN == item.INN))
                {  
                    appDbContext.Organizations.Add(organization);
                    appDbContext.SaveChanges();
                }
                if (appDbContext.Employe.Where(e => e.PassportSeries == item.PassportSeries && e.PassportNumber == item.PassportNumber).ToList().Count > 0)
                {
                    continue;
                }
                Employees.Entity.Employees employees = new Employees.Entity.Employees()
                {
                    Organization = organization,
                    Surname = item.Surname,
                    Name = item.Name,
                    MiddleName = item.MiddleName,
                    BirthDate = item.BirthDate.Date,
                    PassportSeries = item.PassportSeries,
                    PassportNumber = item.PassportNumber
                };
                appDbContext.Employe.Add(employees);
                appDbContext.SaveChanges();
            }
        }
    }
}
