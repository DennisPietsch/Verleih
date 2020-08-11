using System;
using System.Collections.Generic;
using System.Text;

namespace AutoKauf
{
    public class LKW : Fahrzeug
    {
        private int ladevolumen;

        public int Ladevolumen
        {
            get { return ladevolumen; }
            set { ladevolumen = value; }
        }

        public override void Anzeigen(int counter)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nLKW ");
            Console.ForegroundColor = ConsoleColor.Gray;
            base.Anzeigen(counter);
            Console.WriteLine("Ladevolumen in cbm " + Ladevolumen);
        }
    }
}
