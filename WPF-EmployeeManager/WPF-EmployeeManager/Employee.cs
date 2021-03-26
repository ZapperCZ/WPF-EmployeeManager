using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_EmployeeManager
{
    class Employee : Person
    {
        protected string _education, _workPosition;
        protected int _salary;
        public string Education
        {
            get
            {
                return _education;
            }
            set
            {
                _education = value;
            }
        }
        public string WorkPosition
        {
            get
            {
                return _workPosition;
            }
            set
            {
                _workPosition = value;
            }
        }
        public int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
            }
        }

        public Employee(string name, string surname, int birthYear, string education, string workPosition, int salary) : base (name, surname, birthYear)
        {
            Education = education;
            WorkPosition = workPosition;
            Salary = salary;
        }

        public Employee() : base()
        {
            Education = "Unknown";
            WorkPosition = "Unknown";
            Salary = 0;
        }
    }
}
