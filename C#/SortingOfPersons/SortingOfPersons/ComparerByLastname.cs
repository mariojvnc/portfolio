using System.Collections.Generic;

namespace SortingOfPersons
{
    class ComparerByLastname : IComparer<Person>
    {
        #region Expl
        /*  xname yname     -> Anweisung was zuerst kommen soll
         * "Musa" "Reinold" -> zuerst "Musa", dann "Reinold" -> +1
         * "Musa" "Musa"    -> 0
         * "Reinold" "Musa" -> zuerst "Musa", dann "Reinold" -> +1
         * 
         * 
         * lexikographische Reihenfolge (=aka alphabetische)
         * "Musa" < "Reinold"
         */
        #endregion

        public int Compare(Person x, Person y)
        {
            #region ...
            //if (x.LastName == y.LastName)
            //{
            //    return x.FirstName.CompareTo(y.FirstName);
            //}
            //else
            //{
            //    return x.LastName.CompareTo(y.LastName);
            //}
            #endregion
            int result = x.LastName.CompareTo(y.LastName);

            if (result == 0) // Both lastnames are equa. 2nd criteria: first names
                result = x.FirstName.CompareTo(y.FirstName);

            return result;
        }
    }
}