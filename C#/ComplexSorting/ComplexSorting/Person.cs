using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexSorting
{
    class Person
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime Birthday { get; private set; }

        public Person(string name, DateTime birthday)
        {
            // TODO: separate name in first name and last name
            Birthday = birthday;
        }

        public override string ToString()
        {
            return $"{Firstname,15} {Lastname,15} {Birthday.ToShortDateString()}";
        }
    }
}
