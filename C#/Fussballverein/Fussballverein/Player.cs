using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fussballverein
{
    class Player : Member
    {
        #region Property
        public int GoalCount { get; private set; }
        #endregion

        #region Konstruktor
        protected Player(string name, DateTime entryDate, decimal salary)
            : base(name, entryDate, salary)
        {
        }
        #endregion

        #region ToString()
        public override string ToString()
        {
            return $"{base.ToString()}\nAnzahl der Tore: {GoalCount}";
        }
        #endregion

        #region Methoden
        public double AverageGoalsPerMatch()
        {
            return (double)GoalCount / GameCount;
        }
        #endregion
    }
}
