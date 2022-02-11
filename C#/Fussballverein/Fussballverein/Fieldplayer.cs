using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fussballverein
{
    enum Position
    {
        Defender,
        Midfielder,
        Striker
    }
    class FieldPlayer : Player
    {
        #region Proprty
        public Position Position { get; private set; }
        #endregion

        #region Konstruktor
        public FieldPlayer(string name, DateTime entryDate, decimal salary, Position position)
            : base (name, entryDate, salary)
        {
            Position = position;
        }
        #endregion
    
        #region ToString()
        public override string ToString()
        {
            return $"\n{base.ToString()}\nPosition: {Position}\n";
        }
        #endregion

        #region Methoden
        public override bool IsFieldPlayer()
        {
            return true;
        }
        #endregion
    }
}
