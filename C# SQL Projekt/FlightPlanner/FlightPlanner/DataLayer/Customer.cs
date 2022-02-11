using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.DataLayer
{
    class Customer
    {
        /*Id int primary key,
	    LastName nvarchar(40) NOT NULL,
	    Birthday date NOT NULL,
	    City nvarchar(40) NOT NULL,*/
        public int Id { get; private set; }
        public string LastName{ get; private set; }
        public DateTime Birthday{ get; private set; }
        public string City{ get; private set; }

        public Customer(int id, string lastName, DateTime birthday, string city)
        {
            Id = id;
            LastName = lastName;
            Birthday = birthday;
            City = city;
        }

        public Customer() { }
        public override string ToString()
        {
            return $"Id: {Id}, LastName: {LastName}, Birthday: {Birthday.ToShortDateString()}, City: {City}";
        }
    }
}