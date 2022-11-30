using System.Windows;

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
            MessageBox.Show("Отдел типа добавлен");
        }

        private void btnDeptDel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Отдел типа удален");
        }

        private void btnEmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.ShowDialog();
        }

        private void btnEmployeeDel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сотрудник типа удален");
        }

        private void btnEmployeeEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Типа открылось окно просмотра информации о сотруднике");
        }
    }
}
