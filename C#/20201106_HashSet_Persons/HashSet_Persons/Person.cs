using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet_Persons
{
    class Person
    {
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }

        public Person(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public static bool operator==(Person p1, Person p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator!=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            if ( obj is Person other )
            {
                return Name == other.Name && Birthday == other.Birthday;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Name.GetHashCode();
            hash = hash * 23 + Birthday.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"{Name} born at {Birthday.ToShortDateString()}";
        }
    }
}
