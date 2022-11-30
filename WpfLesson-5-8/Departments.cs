using System.Collections.ObjectModel;

namespace WpfLesson_5_8
{
    class Departments 
    {
        public ObservableCollection<Department> collection = new ObservableCollection<Department>();
        public void GenerateRandom(int count = 10)
        {
            for (int i = 1; i <= count; i++)
            {
                collection.Add(new Department() { Name = $"Отдел {i}" });
            }
        }
    }
}
