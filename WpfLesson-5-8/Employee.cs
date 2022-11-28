using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLesson_5_8
{
    class Employee
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PatronymicName { get; set; }
        public Department Department { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public bool IsFired { get; set; }
        public DateTime DateOfDismissal { get; set; }
    }

    class Employees : List<Employee>
    {
        public void GenerateRandom(int count = 20)
        {
            for (int i = 1; i <= count; i++)
            {
                Add(new Employee() { 
                    Surname = $"Фамилия {i}",
                    FirstName = $"Имя  {i}",
                    PatronymicName = $"Очество  {i}"
                });
            }
        }

    }
}
