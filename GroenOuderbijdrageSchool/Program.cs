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

        static void vraagKindInfo(ref List<Kind> tkinderen)
        {
            DateTime gebdat = DateTime.Parse(vraagGebdat());
            DateTime peildat = DateTime.Parse(vraagPeildat());

            var nieuwkind = new Kind(gebdat, peildat);
            tkinderen.Add(nieuwkind);
        }

        static void Main(string[] args)
        {
            List<Kind> kinderen = new List<Kind>();

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

            foreach(Kind individu in kinderen)
            {
                Console.WriteLine(individu);
            }

        }
    }
}
