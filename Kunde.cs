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
        private Standort standort;
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

        public Standort Standort
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
        
        public Kunde NeuenKundenHinzufuegen()
        {
            Kunde kunde = new Kunde();

            Console.WriteLine("Bitte geben sie ihre E-Mail Addresse ein: ");
            kunde.email = Console.ReadLine();
            Console.Clear();
            
            Console.Write("Bitte geben sie ihren Namen ein  ");
            kunde.name = Console.ReadLine();
            Console.Clear();

            Console.Write("Bitte geben sie ihr Alter ein  ");
            kunde.alter = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.Write("Bitte geben sie ihren Standort ein  ");
            kunde.standort.Stadt = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Ihre Daten wurden gespeichert");
            Thread.Sleep(3000);
            Console.Clear();
            return kunde;
        }

        public void DatenHinzufuegen(string name, int alter, string standort, List<Kunde> Kunden)
        {
            Kunde kunde = new Kunde();

            kunde.name = name;
            kunde.alter = alter;
            kunde.standort.Stadt = standort;

            Kunden.Add(kunde);
        }

        public void KundenListeAuslesen(List<Kunde> kundenliste)
        {
            int counter = 1;
            foreach (var item in kundenliste)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Kunde {0}", counter);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n" + item.name);
                Console.WriteLine(item.standort);
                Console.WriteLine(item.alter);
                if (item.vermietetesauto == null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Kunde hat kein ausgeliehenes Fahrzeug");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ausgeliehenes Fahrzeug: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    item.VermietetesAuto.DetailsAnschauen();
                    item.wiederverfuegbar();
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
            Standort.Stadt = standort;
        }

        public Kunde()
        {
        }

        public void wiederverfuegbar()
        {
            int AusgeliehenBIS = VermietetesAuto.AusgeliehenBIS;
            DateTime AusgeliehenUM = VermietetesAuto.AusgeliehenUM;

            if (AusgeliehenUM.AddMinutes(AusgeliehenBIS) <= DateTime.Now)
            {
                vermietetesauto = null;
            }
        }
    }
}
