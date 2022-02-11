using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fussballverein
{
    abstract class Member
    // abstract heißt, man kann im Main kein = new Member(...) machen
    {
        #region Properties
        public string Name { get; private set; }
        public DateTime EntryDate { get; private set; }
        public decimal Salary { get; private set; }
        public int GameCount { get; private set; }
        #endregion

        #region Konstruktor
        public Member(string name, DateTime entryDate, decimal salary)
        {
            Name = name;
            EntryDate = entryDate;
            Salary = salary;
        }
        #endregion

        #region ToString()
        public override string ToString()
        {
            return $"Name: {Name}\nEintrittsdatum: {EntryDate.ToShortDateString()}\nJahresgehalt: {Salary:C2}\nAnzahl der Spiele: {GameCount}";
        }
        #endregion

        #region Methoden
        public virtual bool IsFieldPlayer()
        {
            return false;
        }

        public decimal GetMonthlySalary() => Salary / 12;
        //public decimal GetMonthlySalary()
        //{
        //    return Salary / 12;
        //}

        public void ChangeSalary(decimal percent) // e.g. 3,5 %
        {
            Salary += Salary / 100 * percent;
        }
        #endregion
    }
}
