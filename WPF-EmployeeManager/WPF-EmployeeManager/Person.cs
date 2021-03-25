using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_EmployeeManager
{
    class Person
    {
        string Name { get; set; }
        string Surname { get; set; }
        int BirthYear { get; set; }

        public Person(string name, string surname, int birthYear)
        {
            Name = name;
            Surname = surname;
            BirthYear = birthYear;
        }

        public Person()
        {
            Name = "Unknown";
            Surname = "Unknown";
            BirthYear = 1991;
        }
    }
}
