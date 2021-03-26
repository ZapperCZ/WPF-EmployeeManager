using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_EmployeeManager
{
    class Person
    {
        protected string _name, _surname;
        protected int _birthYear;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }
        public int BirthYear
        {
            get
            {
                return _birthYear;
            }
            set
            {
                _birthYear = value;
            }
        }

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
