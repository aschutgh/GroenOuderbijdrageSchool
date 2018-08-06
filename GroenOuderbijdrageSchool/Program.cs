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
            if (DateTime.Compare(gebdat.AddYears(10), peildat) < 0)
            {
                Jongertien = true;
            }
            else
            {
                Jongertien = false;
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
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
