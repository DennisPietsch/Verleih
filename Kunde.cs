using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.IO.Enumeration;

namespace AutoKauf
{
    public class Kunde
    {
        public string speicherdateikunde = "jsonlistekunde";

        private string name;
        private int alter;
        private string standort;
        private Fahrzeug vermietetesauto;
        private string email;

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

        public Fahrzeug VermietetesAuto
        {
            get { return vermietetesauto; }
            set { vermietetesauto = value; }
        }

        public string EMail
        {
            get { return email; }
            set { email = value; }
        }
        
        public void NeuenKundenHinzufuegen(List<Kunde> Kunden)
        {
            Kunde kunde = new Kunde();

            Console.WriteLine("Bitte geben sie ihre E-Mail Addresse ein: ");
            string Email = Console.ReadLine();
            Console.Clear();
            kunde.email = Email;

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

        public void DatenHinzufuegen(string name, int alter, string standort, List<Kunde> Kunden)
        {
            Kunde kunde = new Kunde();

            kunde.name = name;
            kunde.alter = alter;
            kunde.standort = standort;

            Kunden.Add(kunde);
        }

        public void KundenListeAuslesen(List<Kunde> kundenliste)
        {
            int counter = 1;
            foreach (var item in kundenliste)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Kunde {0}", counter);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n" + item.name);
                Console.WriteLine(item.standort);
                Console.WriteLine(item.alter);
                if (item.vermietetesauto == null)
                {
                    Console.WriteLine("Kunde hat kein ausgeliehenes Auto");
                }
                else
                {
                    Console.WriteLine("Ausgeliehenes Fahrzeug: ");
                    item.VermietetesAuto.DetailsAnschauen();
                }

                counter++;
            }

            Console.ReadKey();
            Console.Clear();
        }

        public Kunde(string email, string name, int alter, string standort)
        {
            EMail = email;
            Name = name;
            Alter = alter;
            Standort = standort;
        }

        public Kunde()
        {
        }
    }
}
