using System;
using System.Collections.Generic;


namespace GroenOuderbijdrageSchool
{
    public class Kind
    {
        public Kind(DateTime gebdat, DateTime peildat)
        {
            Gebdat = gebdat;
            Peildat = peildat;
            if (DateTime.Compare(Gebdat.AddYears(10), Peildat) < 0)
            {
                Jongertien = false;
            }
            else
            {
                Jongertien = true;
            }
        }

        public DateTime Gebdat { get; set; }
        public DateTime Peildat { get; set; }
        public bool Jongertien { get; set; }

        public override string ToString()
        {
            return Gebdat + " " + Peildat + " " + "Jonger dan tien? " + Jongertien;
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

        static void Main(string[] args)
        {
            Console.WriteLine("Uitrekenen van de ouderbijdrage voor school.");

            DateTime gebdat = DateTime.Parse(vraagGebdat());
            DateTime peildat = DateTime.Parse(vraagPeildat());

            var nieuwkind = new Kind(gebdat, peildat);
            Console.WriteLine("Je hebt zojuist dit kind ingevoerd: {0} ", nieuwkind);
        }
    }
}
