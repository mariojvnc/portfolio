using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fussballverein
{
    class GoalKeeper : Player
    {
        #region Konstruktor
        public GoalKeeper(string name, DateTime entryDate, decimal salary)
            : base (name, entryDate, salary)
        {
        }
        #endregion
    }
}
