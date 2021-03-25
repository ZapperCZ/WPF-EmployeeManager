using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_EmployeeManager
{
    class Employee : Person
    {
        string Education { get; set; }
        string WorkPosition { get; set; }
        int Salary { get; set; }

        public Employee(string name, string surname, int birthYear, string education, string workPosition, int salary) : base (name, surname, birthYear)
        {
            Education = education;
            WorkPosition = workPosition;
            Salary = salary;
        }
    }
}
