using System;

namespace Erdbeben_AlterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Erdbeben erdbeben = new Erdbeben();
            Gebäude rathaus = new Gebäude("Rathaus", 2, 3);
            Gebäude schule = new Gebäude("Schule", 4, 8);
            Gebäude krankenhaus = new Gebäude("Krankenhaus", 7, 5);
            Notruforganisation feuerwehr = new Notruforganisation("Feuerwehr", 1, 5);
            Notruforganisation polizei = new Notruforganisation("Polizei", 5, 5);

            erdbeben.NeuerAusbruch += rathaus.NeuerAusbruchBenachrichtigung;
            erdbeben.NeuerAusbruch += schule.NeuerAusbruchBenachrichtigung;
            erdbeben.NeuerAusbruch += krankenhaus.NeuerAusbruchBenachrichtigung;

            rathaus.Notruf += feuerwehr.NotrufEingegangen;
            rathaus.Notruf += polizei.NotrufEingegangen;

            schule.Notruf += polizei.NotrufEingegangen;
            schule.Notruf += polizei.NotrufEingegangen;

            krankenhaus.Notruf += polizei.NotrufEingegangen;
            krankenhaus.Notruf += polizei.NotrufEingegangen;

            feuerwehr.Einsatzbestätigung += rathaus.NotruforganisationKommt;
            polizei.Einsatzbestätigung += rathaus.NotruforganisationKommt;

            feuerwehr.Einsatzbestätigung += krankenhaus.NotruforganisationKommt;
            polizei.Einsatzbestätigung += krankenhaus.NotruforganisationKommt;

            feuerwehr.Einsatzbestätigung += schule.NotruforganisationKommt;
            polizei.Einsatzbestätigung += schule.NotruforganisationKommt;

            

            erdbeben.Process();
            Console.ReadKey();
        }
    }
}
