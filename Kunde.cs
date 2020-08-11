using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutoKauf
{
    public class Kunde
    {
        private string name;
        private int alter;
        private string standort;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Alter
        {
            get { return alter; }
            set { alter = value; }
        }

        public string Standort
        {
            get { return standort; }
            set { standort = value; }
        }

        public List<Kunde> Kunden = new List<Kunde>();

        public void speichern()
        {
            //Kunde 1 
            Kunde kunde = new Kunde();

            kunde.name = "Stefan";
            kunde.alter = 24;

            Kunden.Add(kunde);

            //Kunde 2 
            kunde = new Kunde();

            kunde.name = "Dennis";
            kunde.alter = 16;

            Kunden.Add(kunde);

            //Kunde 3
            kunde = new Kunde();

            kunde.name = "Max";
            kunde.alter = 46;

            Kunden.Add(kunde);

            //Kunde 4
            kunde = new Kunde();

            kunde.name = "Lukas";
            kunde.alter = 32;

            Kunden.Add(kunde);
        }

        public void hinzufuegen()
        {
            Kunde kunde = new Kunde();

            Console.Write("Bitte geben sie ihren Namen ein  ");
            string Name = Console.ReadLine();
            Console.Clear();
            kunde.name = Name;

            Console.Write("Bitte geben sie ihr Alter ein  ");
            int Alter = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            kunde.alter = Alter;

            Console.Write("Bitte geben sie ihren Standort ein  ");
            string Standort = Console.ReadLine();
            Console.Clear();
            kunde.standort = Standort;

            Kunden.Add(kunde);

            Console.WriteLine("Ihre Daten wurden gespeichert");
            Thread.Sleep(3000);
            Console.Clear();
        }

        public void DatenHinzufuegen(string name, int alter, string standort)
        {
            Kunde kunde = new Kunde();

            kunde.name = name;
            kunde.alter = alter;
            kunde.standort = standort;

            Kunden.Add(kunde);
        }

        public void auslesen()
        {
            int counter = 1;
            foreach (var item in Kunden)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Kunde {0}", counter);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n" + item.name);
                Console.WriteLine(item.standort);
                Console.WriteLine(item.alter);
                Console.WriteLine("");

                counter++;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
