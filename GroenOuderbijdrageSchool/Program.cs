using System;
using System.Collections.Generic;


namespace GroenOuderbijdrageSchool
{
    public class Kind
    {
        public DateTime Gebdat { get; set; }
        public DateTime Peildat { get; set; }
        public bool Jongertien { get; set; }
        public Kind() { }
        public Kind(DateTime gebdat, DateTime peildat)
        {
            Gebdat = gebdat;
            Peildat = peildat;
            //Jongertien = false;
            if (DateTime.Compare(Gebdat.AddYears(10), Peildat) < 0)
            {
                Jongertien = false;
            }
            else
            {
                Jongertien = true;
            }
        }
        public override string ToString()
        {
            return "Geboren: " + Gebdat + " Peildatum: " + Peildat + " " + "Jonger dan tien? " + Jongertien;
        }
    }


    class Program
    {
        static string vraagGebdat()
        {
            Console.Write("Geef geboortedatum van kind in formaat jjjj/mm/dd: ");
            return Console.ReadLine();
        }

        static string vraagPeildat()
        {
            Console.Write("Geef peildatum in formaat jjjj/mm/dd: ");
            return Console.ReadLine();
        }

        static void vraagKindInfo(ref List<Kind> tkinderen)
        {
            DateTime gebdat = DateTime.Parse(vraagGebdat());
            DateTime peildat = DateTime.Parse(vraagPeildat());

            var nieuwkind = new Kind(gebdat, peildat);
            tkinderen.Add(nieuwkind);
        }

        static Double berekenBijdrage(List<Kind> kinderen, bool eenouder)
        {
            var aantaljdtien = 0; // aantal kinderen jonger dan tien
            var aantalouderdt = 0; // aantal kinderen ouder dan tien
            Double ouderbijdrage = 50.0; // Basisbijdrage is 50 euro.

            foreach(Kind individu in kinderen)
            {
                if (individu.Jongertien == true)
                {
                    aantaljdtien += 1;
                }
                else
                {
                    aantalouderdt += 1;
                }
            }
            // meer dan drie kinderen jonger dan tien, is niet relevant voor berekenen ouderbijdrage
            if (aantaljdtien > 3)
            {
                aantaljdtien = 3;
            }
            // meer dan twee kinderen ouder dan tien jaar, is niet relevant voor berekenen ouderbijdrage
            if (aantalouderdt > 2)
            {
                aantalouderdt = 2;
            }
            ouderbijdrage = ouderbijdrage + (aantaljdtien * 25) + (aantalouderdt * 37);
            // maximale bijdrage van 150 euro
            if (ouderbijdrage > 150)
            {
                ouderbijdrage = 150;
            }
            // eenouder gezin? dan 25 procent korting
            if (eenouder == true)
            {
                ouderbijdrage = 0.75 * ouderbijdrage;
            }
            return ouderbijdrage;
        }

        static void Main(string[] args)
        {
            List<Kind> kinderen = new List<Kind>();
            bool eenouder = false;

            Console.WriteLine("Uitrekenen van de ouderbijdrage voor school.");
            var meerkinderen = true;
            while (meerkinderen == true)
            {
                vraagKindInfo(ref kinderen);
                Console.WriteLine("Wil je meer kinderen invoeren? (ja of nee) ");
                if (Console.ReadLine() == "nee")
                {
                    meerkinderen = false;
                }
            }

            Console.WriteLine("Opgegeven kinderen: ");
            foreach(Kind individu in kinderen)
            {
                Console.WriteLine(individu);
            }

            Console.WriteLine("Is het gezin een eenoudergezin? (ja of nee) ");
            if (Console.ReadLine() == "ja")
            {
                eenouder = true;
            }

            Console.WriteLine("De ouderbijdrage bedraagt: {0}", berekenBijdrage(kinderen, eenouder));
        }
    }
}
