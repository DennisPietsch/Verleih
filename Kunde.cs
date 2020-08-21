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
        private double guthaben;

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

        public double Guthaben
        {
            get { return guthaben; }
            set { guthaben = value; }
        }
        
        public Kunde NeuenKundenHinzufuegen(List<Standort> standortliste, List<Kunde> kundenliste)
        {
            Kunde kunde = new Kunde();

            Console.WriteLine("Bitte geben sie ihre E-Mail Addresse ein: ");
            string Email = Console.ReadLine();
            Console.Clear();
            
            Console.Write("Bitte geben sie ihren Namen ein  ");
            string Name = Console.ReadLine();
            Console.Clear();

            Console.Write("Bitte geben sie ihr Alter ein  ");
            int Alter = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.Write("Bitte geben sie ihren Standort ein  ");
            string Stadt = Console.ReadLine();
            Console.Clear();

            foreach (var item in standortliste)
            {
                if (item.Stadt == Stadt)
                {
                    kunde.Standort = item;
                    break;
                }
            }

            if (kunde.Standort == null)
            {
                Console.Write("Bitte geben sie den Breitengrad der Stadt ein ");
                double Breitengrad = Convert.ToDouble(Console.ReadLine());
                Console.Clear();

                Console.Write("Bitte geben sie den Längengrad der Stadt ein ");
                double Laengengrad = Convert.ToDouble(Console.ReadLine());
                Console.Clear();

                kunde.Standort = new Standort(Stadt, Breitengrad, Laengengrad);
            }

            Console.Clear();
            Console.WriteLine("Ihre Daten wurden gespeichert");

            kunde.EMail = Email;
            kunde.Name = Name;
            kunde.Alter = Alter;

            kunde.Guthaben = 100;

            Thread.Sleep(3000);
            Console.Clear();
            return kunde;
        }

        public void DatenHinzufuegen(string name, int alter, Standort standort, List<Kunde> Kunden)
        {
            Kunde kunde = new Kunde();

            kunde.name = name;
            kunde.alter = alter;
            kunde.standort = standort;

            Kunden.Add(kunde);
        }

        public void KundenListeAuslesen(List<Kunde> kundenliste)
        {
            foreach (var item in kundenliste)
            {
                Console.WriteLine("\nName: " + item.name);
                Console.WriteLine("EMail: " + item.email);
                Console.WriteLine("Standort: " + item.standort.Stadt);
                Console.WriteLine("Alter: " + item.alter);
                Console.WriteLine("Guthaben: " + item.guthaben);
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
            }

            Console.ReadKey();
            Console.Clear();
        }

        public Kunde(string email, string name, int alter, Standort standort)
        {
            EMail = email;
            Name = name;
            Alter = alter;
            Standort = standort;
        }

        public Kunde()
        {
        }

        public void wiederverfuegbar()
        {
            double AusgeliehenBIS = VermietetesAuto.AusgeliehenBIS;
            DateTime AusgeliehenUM = VermietetesAuto.AusgeliehenUM;

            if (AusgeliehenUM.AddMinutes(AusgeliehenBIS) <= DateTime.Now)
            {
                vermietetesauto = null;
            }
        }

        public void GuthabenAufladen(List<Standort> standortliste, List<Kunde> kundenliste)
        {
            ConsoleKeyInfo cki;
            Console.Clear();
            Console.Write("Bitte geben sie ihre Email an: ");
            string email = Console.ReadLine();

            foreach (var kunde in kundenliste)
            {
                if (kunde.EMail == email)
                {
                    Console.Write("Wie viel wollen sie aufladen: ");
                    double aufladen = Convert.ToDouble(Console.ReadLine());
                    Console.Clear();

                    kunde.Guthaben = kunde.Guthaben + aufladen;
                }
            }

            do
            {
                Console.WriteLine("EMail ist nich in der Datenbank");
                Console.WriteLine("Möchten sie sich ein Konto erstellen? [j] [n]");

                cki = Console.ReadKey();

                switch (cki.KeyChar)
                {
                    case 'j':
                        NeuenKundenHinzufuegen(standortliste, kundenliste);
                        return;

                    case 'n':
                        return;

                    default:
                        Console.WriteLine("Keine mögliche Auswahl");
                        Thread.Sleep(2000);
                        break;
                }

            } while (true);
        }
    }
}
