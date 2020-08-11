using System;
using System.Collections.Generic;
using System.Text;

namespace AutoKauf
{
    public class Motorrad : Fahrzeug
    {
        private bool seitenWagen;

        public bool Seitenwagen
        {
            get { return seitenWagen; }
            set { seitenWagen = value; }
        }

        public override void Anzeigen(int counter)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nMotorrad ");
            Console.ForegroundColor = ConsoleColor.Gray;
            base.Anzeigen(counter);
            Console.WriteLine("Seitenwagen: " + Seitenwagen);
        }
    }
}
