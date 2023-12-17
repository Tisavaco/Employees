using Employees.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
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

        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("нажата загрузка");
        }
        private void UpLoad_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("нажата выгрузка");
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
            }
            else
                MessageBox.Show("Введены некорректные данные!");
        }

    }
}
