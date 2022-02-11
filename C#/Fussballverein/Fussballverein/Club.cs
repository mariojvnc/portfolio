using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fussballverein
{
    class Club : List<Member>
    {
        #region Property
        public string Name { get; private set; }
        #endregion

        #region Konstruktor
        public Club(string name)
            : base(30) // --> Die Liste hat Platz für 30 Mitglieder
        {
            Name = name;
        }
        #endregion

        #region ToString()
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (Member member in this)
            {
                builder.Append(member);
            }

            return $"Verein: {Name}\n{builder.ToString()}";
        }
        #endregion

        #region Methoden
        public List<Player> GetAllFieldPlayers()
        {
            List<Player> result = new List<Player>();

            foreach (Member member in this)
            {
                #region ...
                //if (member.IsFieldPlayer())
                //{
                //    result.Add(member);
                //}
                // Datentyp is Datentyp ==> Abfrage ob ein Datentyp ein anderer ist
                // as Player ==> Casten
                #endregion

                if (member is FieldPlayer)
                    result.Add(member as Player);
            }
            return result;
        }
        #endregion
    }
}
