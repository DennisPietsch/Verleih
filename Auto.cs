using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AutoKauf
{
    public class Auto : Fahrzeug
    {
        private bool anhängerKupplung;

        public bool AnhängerKupplung
        {
            get { return anhängerKupplung; }
            set { anhängerKupplung = value; }
        }

        public override void Anzeigen(int counter)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nAuto");
            Console.ForegroundColor = ConsoleColor.Gray;
            base.Anzeigen(counter);
            Console.WriteLine("Anhängerkupplung: " + AnhängerKupplung);
        }
    }
}
