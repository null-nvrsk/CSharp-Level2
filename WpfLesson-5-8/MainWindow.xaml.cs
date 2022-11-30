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
            departments.GenerateRandom(10);

            lvEmployees.ItemsSource = employees.collection;
            employees.GenerateRandom(30);
        }

        private void btnDeptAdd_Click(object sender, RoutedEventArgs e)
        {

            AddDepartmentWindow departmentWindow = new AddDepartmentWindow();
            departmentWindow.Owner = this;
            departmentWindow.tbName.Text = "";
            departmentWindow.ShowDialog();
        }
        
        private void btnDeptEdit_Click(object sender, RoutedEventArgs e)
        {
            Department selDepartment = (Department)lvDepartments.SelectedItem;
            if (selDepartment != null)
            {
                EditDepartmentWindow editDepartmenWindow = new EditDepartmentWindow();
                editDepartmenWindow.Owner = this;
                editDepartmenWindow.tbName.Text = selDepartment.Name;

                editDepartmenWindow.ShowDialog();
            }
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
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.Owner = this;
            addEmployeeWindow.tbSurname.Text = "";
            addEmployeeWindow.tbFirstName.Text = "";
            addEmployeeWindow.tbPatronymicName.Text = "";
            addEmployeeWindow.cbDepartment.ItemsSource = departments.collection;
            addEmployeeWindow.dpBirthday.Text = "";
            addEmployeeWindow.dpDateOfEmployment.Text = "";
            addEmployeeWindow.cbFired.IsChecked = false;
            addEmployeeWindow.dpDateOfDismissal.Text = "";
            addEmployeeWindow.dpDateOfDismissal.IsEnabled = false;

            addEmployeeWindow.ShowDialog();
        }

        private void btnEmployeeEdit_Click(object sender, RoutedEventArgs e)
        {
            Employee selEmployee = (Employee)lvEmployees.SelectedItem;
            if (selEmployee != null)
            {
                EditEmployeeWindow editEmployeeWindow = new EditEmployeeWindow();
                editEmployeeWindow.Owner = this;
                editEmployeeWindow.tbSurname.Text = selEmployee.Surname;
                editEmployeeWindow.tbFirstName.Text = selEmployee.FirstName;
                editEmployeeWindow.tbPatronymicName.Text = selEmployee.PatronymicName;
                editEmployeeWindow.cbDepartment.ItemsSource = departments.collection;
                editEmployeeWindow.cbDepartment.SelectedItem = selEmployee.Department;
                editEmployeeWindow.dpBirthday.Text = selEmployee.Birthday.ToShortDateString();
                editEmployeeWindow.dpDateOfEmployment.Text = selEmployee.DateOfEmployment.ToShortDateString();
                editEmployeeWindow.cbFired.IsChecked = selEmployee.IsFired;
                editEmployeeWindow.dpDateOfDismissal.Text = selEmployee.DateOfDismissal.ToShortDateString();
                editEmployeeWindow.dpDateOfDismissal.IsEnabled = !selEmployee.IsFired;

                editEmployeeWindow.ShowDialog();
            }
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
    }
}
