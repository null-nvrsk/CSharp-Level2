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

namespace WpfLesson_5_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Departments departs = new Departments();
            lvDepartments.ItemsSource = departs;
            departs.GenerateRandom(20);

            Employees employees = new Employees();
            lvEmployees.ItemsSource = employees;
            employees.GenerateRandom(100);
        }

        private void btnDeptAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.ShowDialog();
        }
    }
}
