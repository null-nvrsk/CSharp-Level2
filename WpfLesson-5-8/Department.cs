using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
