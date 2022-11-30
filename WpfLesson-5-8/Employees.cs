using System.Collections.ObjectModel;

namespace WpfLesson_5_8
{
    class Employees
    {
        public ObservableCollection<Employee> collection = new ObservableCollection<Employee>();
        public void GenerateRandom(int count = 20)
        {
            for (int i = 1; i <= count; i++)
            {
                collection.Add(new Employee() { 
                    Surname = $"Фамилия {i}",
                    FirstName = $"Имя  {i}",
                    PatronymicName = $"Очество  {i}"
                });
            }
        }

    }
}
