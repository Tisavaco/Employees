using CsvHelper;
using CsvHelper.Configuration;
using Employees.Entity;
using Employees.Repositories.MyConverters;
using Employees.Repositories.OdjectClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppDbContext appDbContext;
        public MainWindow()
        {
            InitializeComponent();
            AddEmployesGrid.Visibility = Visibility.Collapsed;
            AddOrganizationGrid.Visibility = Visibility.Collapsed;
            appDbContext = DependencyInjection.ServiceProvider.GetRequiredService<AppDbContext>();
            AddDataFromDb.AddData();

        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();
            var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };
            using (var fs = new FileStream(dialog.FileName, FileMode.Open))
            using (var csv = new CsvReader(new StreamReader(fs, Encoding.UTF8), config))
            {
                var employesCSVs = csv.GetRecords<EmployesCSV>();
                ConvertEmployesCSV.ConvertTo(employesCSVs);
            }
        }
        private void UpLoad_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new AppDbContext())
            {
                var data = context.Employe.ToList();
                var employesCSV = ConvertEmployesCSV.Convert(data);
                var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };
                using (var fs = new FileStream("Employes.csv", FileMode.Create))
                using (var csv = new CsvWriter(new StreamWriter(fs, Encoding.UTF8), config))
                {
                    csv.WriteHeader<EmployesCSV>();
                    csv.NextRecord();
                    foreach (var item in employesCSV)
                    {
                        csv.WriteRecord(item);
                        csv.NextRecord();
                    }
                }
            }
        }
        private void Organization_Click(object sender, RoutedEventArgs e)
        {
            AddEmployesGrid.Visibility = Visibility.Collapsed;
            AddOrganizationGrid.Visibility = Visibility.Visible;
        }
        private void Employes_Click(object sender, RoutedEventArgs e)
        {
            AddEmployesGrid.Visibility = Visibility.Visible;
            AddOrganizationGrid.Visibility = Visibility.Collapsed;
            var organization = appDbContext.Organizations.Select(x => x.Name);
            organizationComboBox.ItemsSource = organization.ToList();
        }
        private void AddOrganization_Click(object sender, RoutedEventArgs e)
        {
            if (!(organizationNameText.Text == "" || innText.Text == "" || legalAddressText.Text == "" || actualAddressText.Text == ""))
            {
                Organization organization = new Organization()
                {
                    Name = organizationNameText.Text,
                    INN = innText.Text,
                    LegalAddress = legalAddressText.Text,
                    ActualAddress = actualAddressText.Text
                };               
                appDbContext.Organizations.Add(organization);
                appDbContext.SaveChanges();
                AddOrganizationGrid.Visibility = Visibility.Collapsed;
                CleanTextBox();
            }
            else
                MessageBox.Show("Введены некорректные данные!");
        }
        private void AddEmployes_Click(object sender, RoutedEventArgs e)
        {
            if (!(nameText.Text == "" || surnameText.Text == "" || middleNameText.Text == "" || birthDateText.Text == "" || passportSeriesText.Text == "" || passportNumberText.Text == ""))
            {
                var organization = appDbContext.Organizations.Single(p => p.Name == organizationComboBox.Text); 
                Employees.Entity.Employees employees = new Employees.Entity.Employees()
                {
                    Organization = organization,
                    Surname = surnameText.Text,
                    Name = nameText.Text,
                    MiddleName = middleNameText.Text,
                    BirthDate = DateTime.Parse(birthDateText.Text).Date,
                    PassportSeries = int.Parse(passportSeriesText.Text),
                    PassportNumber = int.Parse(passportNumberText.Text)
                };
                appDbContext.Employe.Add(employees);
                appDbContext.SaveChanges();
                AddEmployesGrid.Visibility = Visibility.Collapsed;
                CleanTextBox();
            }
            else
                MessageBox.Show("Введены некорректные данные!");
        }
        /*private bool CheckOrganizationMargin()
        {
            if(innText.Text.Length > 12)
            {
                return false;
            }
            return true;
        }*/
        private void CleanTextBox()
        {
            organizationComboBox.Text = null;
            surnameText.Text = null;
            nameText.Text = null;
            middleNameText.Text = null;
            birthDateText.Text = null;
            passportSeriesText.Text = null;
            passportNumberText.Text = null;
            organizationNameText.Text = null;
            innText.Text = null;
            legalAddressText.Text = null;   
            actualAddressText.Text = null;
        }

    }
}
