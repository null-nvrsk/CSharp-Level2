using System.Windows;

namespace WpfLesson_5_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Departments departments = new Departments();
        private static Employees employees = new Employees();

        public MainWindow()
        {
            InitializeComponent();
            lvDepartments.ItemsSource = departments.collection;
            departments.GenerateRandom(20);

            lvEmployees.ItemsSource = employees.collection;
            employees.GenerateRandom(100);
        }

        private void btnDeptAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Отдел типа добавлен");
        }

        private void btnDeptDel_Click(object sender, RoutedEventArgs e)
        {
            Department selDepartment = (Department)lvDepartments.SelectedItem;
            if (selDepartment != null)
            {
                departments.collection.Remove(selDepartment);
                MessageBox.Show($"Отдел \"{selDepartment.Name}\" удален");
            }
        }

        private void btnEmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.ShowDialog();
        }

        private void btnEmployeeDel_Click(object sender, RoutedEventArgs e)
        {
            Employee selEmployee = (Employee)lvEmployees.SelectedItem;
            if(selEmployee != null)
            {
                employees.collection.Remove(selEmployee);
                MessageBox.Show($"Сотрудник {selEmployee.FirstName} {selEmployee.Surname} удален");
            }
        }

        private void btnEmployeeEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Типа открылось окно просмотра информации о сотруднике");
        }
    }
}
