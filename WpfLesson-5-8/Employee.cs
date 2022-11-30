using System;
using System.Collections.Generic;

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
}
