using System.Collections.Generic;

namespace WpfLesson_5_8
{
    class Department
    {
        public string Name { get; set; }
    }

    class Departments : List<Department>
    {
        public void GenerateRandom(int count = 10)
        {
            for (int i = 1; i <= count; i++)
            {
                Add(new Department() { Name = $"Отдел {i}" });
            }
        }
    }
}
