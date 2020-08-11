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
    public class FahrzeugVerleih
    {
        const string speicherdatei = "jsonliste";
        const string speicherdateikunde = "jsonlistekunde";
        public List<Fahrzeug> FahrzeugListe = new List<Fahrzeug>();
        public List<Kunde> kundenliste = new List<Kunde>();

        public void FahrzeugWaehlen()
        {
            Console.WriteLine("Hier können sie wählen was sie leihen möchten ");
            Console.WriteLine("[1] Auto");
            Console.WriteLine("[2] LKW");
            Console.WriteLine("[3] Motorrad");
        }

        public void FahrzeugLeihen()
        {
            Console.Clear();
            ConsoleKeyInfo cki;
            Fahrzeug fahrzeug = new Fahrzeug();

            Kunde kunde = new Kunde();

            Console.WriteLine("Wollen sie ein Fahrzeug leihen? [j] [n]");
            cki = Console.ReadKey();
            Console.Clear();
            if (cki.KeyChar == 'j')
            {
                Console.WriteLine("Welches Auto wollen sie leihen ");
                int leihen = Convert.ToInt32(Console.ReadLine());

                if (FahrzeugListe.ElementAt(leihen - 1).Verfuegbar == true)
                {
                    FahrzeugListe.ElementAt(leihen - 1).Anzeigen(leihen);

                    Console.Write("Wie lang möchten sie den Wagen ausleihen ");
                    int zeit = Convert.ToInt32(Console.ReadLine());

                    kundespeicher();

                    Console.WriteLine("Ihr Auto ist gemietet und bereit zur Abholung");
                    FahrzeugListe.ElementAt(leihen - 1).Verfuegbar = false;
                    Thread.Sleep(5000);
                    Console.Clear();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fahrzeug ist nicht verfügbar oder ist nicht vorhanden");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Thread.Sleep(3000);
                    FahrzeugLeihen();
                }
            }

            else
            {
                Console.Clear();
            }
        }

        public void FahrzeugeAnzeigen()
        {
            Console.Clear();
            ConsoleKeyInfo cki;

            int counter = 1;

            Console.WriteLine("Wählen sie was sie anzeigen lassen wollen");
            Console.WriteLine("[1] Auto");
            Console.WriteLine("[2] LKW");
            Console.WriteLine("[3] Motorrad");
            Console.WriteLine("[4] Alle Fahrzeuge anzeigen");

            cki = Console.ReadKey();
            Console.Clear();

            List<Fahrzeug> fahrzeuge = new List<Fahrzeug>();

            switch (cki.KeyChar)
            {
                case '1':

                    foreach (var fahrzeug in FahrzeugListe)
                    {
                        if (fahrzeug.GetType() == typeof(Auto))
                        {
                            Auto auto = fahrzeug as Auto;
                            fahrzeuge.Add(auto);
                            Console.WriteLine("");
                        }
                    }

                    foreach (var item in fahrzeuge)
                    {
                        item.Anzeigen(counter);
                        counter++;
                    }

                    Console.Write("\n\nMöchten sie ein Auto genauer anschauen [j] [n] ");
                    cki = Console.ReadKey();
                    if (cki.KeyChar == 'j')
                    {
                        Console.Write("Welches Auto wollen sie sich genauer anschauen ");
                        int autoAnschauen = Convert.ToInt32(Console.ReadLine());

                        fahrzeuge.ElementAt(autoAnschauen - 1).DetailsAnschauen();
                    }

                    else
                    {
                    }
                    Console.ReadKey();
                    fahrzeuge.Clear();

                    break;

                case '2':

                    foreach (var fahrzeug in FahrzeugListe)
                    {
                        if (fahrzeug.GetType() == typeof(LKW))
                        {
                            LKW lkw = fahrzeug as LKW;
                            fahrzeuge.Add(lkw);
                            Console.WriteLine("");
                        }
                    }

                    foreach (var item in fahrzeuge)
                    {
                        item.Anzeigen(counter);
                        counter++;
                    }

                    Console.Write("\n\nMöchten sie ein LKW genauer anschauen [j] [n] ");
                    cki = Console.ReadKey();
                    if (cki.KeyChar == 'j')
                    {
                        Console.Write("Welches Auto wollen sie sich genauer anschauen ");
                        int autoAnschauen = Convert.ToInt32(Console.ReadLine());

                        fahrzeuge.ElementAt(autoAnschauen - 1).DetailsAnschauen();
                    }

                    else
                    {
                    }
                    Console.ReadKey();
                    fahrzeuge.Clear();

                    break;

                case '3':

                    foreach (var fahrzeug in FahrzeugListe)
                    {
                        if (fahrzeug.GetType() == typeof(Motorrad))
                        {
                            Motorrad moped = fahrzeug as Motorrad;
                            fahrzeuge.Add(moped);
                            Console.WriteLine("");
                        }
                    }

                    foreach (var item in fahrzeuge)
                    {
                        item.Anzeigen(counter);
                        counter++;
                    }

                    Console.Write("\n\nMöchten sie ein Motorrad genauer anschauen [j] [n] ");
                    cki = Console.ReadKey();
                    if (cki.KeyChar == 'j')
                    {
                        Console.Write("Welches Auto wollen sie sich genauer anschauen ");
                        int autoAnschauen = Convert.ToInt32(Console.ReadLine());

                        fahrzeuge.ElementAt(autoAnschauen - 1).DetailsAnschauen();
                    }

                    else
                    {
                    }
                    Console.ReadKey();
                    fahrzeuge.Clear();

                    break;

                case '4':

                    foreach (var fahrzeug in FahrzeugListe)
                    {
                        fahrzeug.Anzeigen(counter);
                        counter++;
                    }

                    break;

                default:
                    Console.Clear();
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void Fahrzeughinzufuegen()
        {
            Console.WriteLine("Hier können sie wählen was sie hinzufügen möchten ");
            Console.WriteLine("[1] Auto");
            Console.WriteLine("[2] LKW");
            Console.WriteLine("[3] Motorrad");

            ConsoleKeyInfo cki;
            cki = Console.ReadKey();

            if (cki.KeyChar == '1')
            {
                Console.Clear();
                FahrzeugListe.Add(hinzufuegenauto());
            }
            else if (cki.KeyChar == '2')
            {
                Console.Clear();
                FahrzeugListe.Add(hinzufuegenLKW());
            }
            else if (cki.KeyChar == '3')
            {
                Console.Clear();
                FahrzeugListe.Add(hinzufuegenmotorrad());
            }
        }

        public Fahrzeug hinzufuegenauto()
        {
            ConsoleKeyInfo cki;
            Auto fahrzeug = new Auto();

            Console.WriteLine("Bitte geben sie den Standort des Fahrzeugs an  ");
            string standort = Console.ReadLine();
            Console.Clear();
            fahrzeug.Standort = standort;

            Console.WriteLine("Bitte geben sie den Hersteller des Fahrzeugs an  ");
            string hersteller = Console.ReadLine();
            Console.Clear();
            fahrzeug.Hersteller = hersteller;

            Console.WriteLine("Bitte geben sie die Leistung des Fahrzeugs an  ");
            int leistung = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Leistung = leistung;

            Console.WriteLine("Bitte geben sie den Preis des Fahrzeugs an  ");
            int preis = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Preis = preis;

            Console.WriteLine("Bitte geben sie das Bauhjahr des Fahrzeugs an  ");
            int bauhjahr = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Bauhjahr = bauhjahr;

            Console.WriteLine("Bitte geben sie die Anzahl der Räder des Fahrzeugs an  ");
            int raeder = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Raeder = raeder;

            Console.WriteLine("Bitte geben sie die Anzahl der SitzPlätze des Fahrzeugs an  ");
            int sitzplaetze = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.SitzPlaetze = sitzplaetze;

            Console.WriteLine("Haben sie eine AnhängerKupplung an ihrem Fahrzeug");
            Console.WriteLine("[1] Ja");
            Console.WriteLine("[2] Nein");
            cki = Console.ReadKey();
            if (cki.KeyChar == '1')
            {
                fahrzeug.AnhängerKupplung = true;
            }
            else
            {
                fahrzeug.AnhängerKupplung = false;
            }
            Console.Clear();

            Console.WriteLine("Bitte geben sie an welchen Kraftstoff ihr Fahrzeug verwendet ");
            Console.WriteLine("[1] Benzin");
            Console.WriteLine("[2] Diesel");
            Console.WriteLine("[3] Wasserstoff");
            Console.WriteLine("[4] Erdgas");
            Console.WriteLine("[5] Strom");

            cki = Console.ReadKey();
            if (cki.KeyChar == '1')
            {
                fahrzeug.Kraftstoff = Energie.Benzin;
            }

            else if (cki.KeyChar == '2')
            {
                fahrzeug.Kraftstoff = Energie.Diesel;
            }

            else if (cki.KeyChar == '3')
            {
                fahrzeug.Kraftstoff = Energie.Wasserstoff;
            }

            else if (cki.KeyChar == '4')
            {
                fahrzeug.Kraftstoff = Energie.Erdgas;
            }

            else if (cki.KeyChar == '5')
            {
                fahrzeug.Kraftstoff = Energie.Strom;
            }

            else
            {
            }

            fahrzeug.Verfuegbar = true;

            Console.Clear();
            Console.WriteLine("Ihr Fahrzeug wurde gespeichert  ");
            Thread.Sleep(3000);
            Console.Clear();
            return fahrzeug;
        }

        public Fahrzeug hinzufuegenmotorrad()
        {
            ConsoleKeyInfo cki;
            LKW fahrzeug = new LKW();

            Console.WriteLine("Bitte geben sie den Standort des Fahrzeugs an  ");
            string standort = Console.ReadLine();
            Console.Clear();
            fahrzeug.Standort = standort;

            Console.WriteLine("Bitte geben sie den Hersteller des Fahrzeugs an  ");
            string hersteller = Console.ReadLine();
            Console.Clear();
            fahrzeug.Hersteller = hersteller;

            Console.WriteLine("Bitte geben sie die Leistung des Fahrzeugs an  ");
            int leistung = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Leistung = leistung;

            Console.WriteLine("Bitte geben sie den Preis des Fahrzeugs an  ");
            int preis = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Preis = preis;

            Console.WriteLine("Bitte geben sie das Bauhjahr des Fahrzeugs an  ");
            int bauhjahr = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Bauhjahr = bauhjahr;

            Console.WriteLine("Bitte geben sie die Anzahl der Räder des Fahrzeugs an  ");
            int raeder = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Raeder = raeder;

            Console.WriteLine("Bitte geben sie die Anzahl der SitzPlätze des Fahrzeugs an  ");
            int sitzplaetze = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.SitzPlaetze = sitzplaetze;

            Console.WriteLine("Bitte geben sie das Ladevolumen in cbm des Fahrzeugs an  ");
            int ladevolumen = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Ladevolumen = ladevolumen;

            Console.WriteLine("Bitte geben sie an welchen Kraftstoff ihr Fahrzeug verwendet ");
            Console.WriteLine("[1] Benzin");
            Console.WriteLine("[2] Diesel");
            Console.WriteLine("[3] Wasserstoff");
            Console.WriteLine("[4] Erdgas");
            Console.WriteLine("[5] Strom");

            cki = Console.ReadKey();
            if (cki.KeyChar == '1')
            {
                fahrzeug.Kraftstoff = Energie.Benzin;

            }

            else if (cki.KeyChar == '2')
            {
                fahrzeug.Kraftstoff = Energie.Diesel;
            }

            else if (cki.KeyChar == '3')
            {
                fahrzeug.Kraftstoff = Energie.Wasserstoff;
            }

            else if (cki.KeyChar == '4')
            {
                fahrzeug.Kraftstoff = Energie.Erdgas;
            }

            else if (cki.KeyChar == '5')
            {
                fahrzeug.Kraftstoff = Energie.Strom;
            }

            else
            {
            }

            fahrzeug.Verfuegbar = true;

            Console.Clear();
            Console.WriteLine("Ihr Fahrzeug wurde gespeichert  ");
            Thread.Sleep(3000);
            Console.Clear();
            return fahrzeug;
        }

        public Fahrzeug hinzufuegenLKW()
        {
            ConsoleKeyInfo cki;
            Motorrad fahrzeug = new Motorrad();

            Console.WriteLine("Bitte geben sie den Standort des Fahrzeugs an  ");
            string standort = Console.ReadLine();
            Console.Clear();
            fahrzeug.Standort = standort;

            Console.WriteLine("Bitte geben sie den Hersteller des Fahrzeugs an  ");
            string hersteller = Console.ReadLine();
            Console.Clear();
            fahrzeug.Hersteller = hersteller;

            Console.WriteLine("Bitte geben sie die Leistung des Fahrzeugs an  ");
            int leistung = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Leistung = leistung;

            Console.WriteLine("Bitte geben sie den Preis des Fahrzeugs an  ");
            int preis = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Preis = preis;

            Console.WriteLine("Bitte geben sie das Bauhjahr des Fahrzeugs an  ");
            int bauhjahr = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Bauhjahr = bauhjahr;

            Console.WriteLine("Bitte geben sie die Anzahl der Räder des Fahrzeugs an  ");
            int raeder = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.Raeder = raeder;

            Console.WriteLine("Bitte geben sie die Anzahl der SitzPlätze des Fahrzeugs an  ");
            int sitzplaetze = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            fahrzeug.SitzPlaetze = sitzplaetze;

            Console.WriteLine("Haben sie einen Seitenwagen an ihrem Fahrzeug? ");
            Console.WriteLine("[1] Ja");
            Console.WriteLine("[2] Nein");
            cki = Console.ReadKey();
            if (cki.KeyChar == '1')
            {
                fahrzeug.Seitenwagen = true;
            }
            else
            {
                fahrzeug.Seitenwagen = false;
            }
            Console.Clear();

            Console.WriteLine("Bitte geben sie an welchen Kraftstoff ihr Fahrzeug verwendet ");
            Console.WriteLine("[1] Benzin");
            Console.WriteLine("[2] Diesel");
            Console.WriteLine("[3] Wasserstoff");
            Console.WriteLine("[4] Erdgas");
            Console.WriteLine("[5] Strom");

            cki = Console.ReadKey();
            if (cki.KeyChar == '1')
            {
                fahrzeug.Kraftstoff = Energie.Benzin;

            }

            else if (cki.KeyChar == '2')
            {
                fahrzeug.Kraftstoff = Energie.Diesel;
            }

            else if (cki.KeyChar == '3')
            {
                fahrzeug.Kraftstoff = Energie.Wasserstoff;
            }

            else if (cki.KeyChar == '4')
            {
                fahrzeug.Kraftstoff = Energie.Erdgas;
            }

            else if (cki.KeyChar == '5')
            {
                fahrzeug.Kraftstoff = Energie.Strom;
            }

            else
            {
            }

            fahrzeug.Verfuegbar = true;

            Console.Clear();
            Console.WriteLine("Ihr Fahrzeug wurde gespeichert  ");
            Thread.Sleep(3000);
            Console.Clear();
            return fahrzeug;
        }

        public void speichern()
        {
            Fahrzeug fahrzeug = new Fahrzeug();
            Auto fahrzeugAUTO = new Auto();
            LKW fahrzeugLKW = new LKW();
            Motorrad fahrzeugMOTORRAD = new Motorrad();
            
            //Auto 1
            fahrzeugAUTO.Preis = 7500;
            fahrzeugAUTO.Hersteller = "Audi";
            fahrzeugAUTO.Raeder = 4;
            fahrzeugAUTO.Kraftstoff = Energie.Benzin;
            fahrzeugAUTO.Leistung = 170;
            fahrzeugAUTO.SitzPlaetze = 5;
            fahrzeugAUTO.Standort = "Stuttgart";
            fahrzeugAUTO.Bauhjahr = 2012;
            fahrzeugAUTO.AnhängerKupplung = true;
            fahrzeugAUTO.Verfuegbar = false;

            FahrzeugListe.Add(fahrzeugAUTO);

            //Auto2 
            fahrzeugAUTO = new Auto();
            fahrzeugAUTO.Preis = 15000;
            fahrzeugAUTO.Hersteller = "VW";
            fahrzeugAUTO.Raeder = 4;
            fahrzeugAUTO.Kraftstoff = Energie.Strom;
            fahrzeugAUTO.Leistung = 150;
            fahrzeugAUTO.SitzPlaetze = 4;
            fahrzeugAUTO.Standort = "Berlin";
            fahrzeugAUTO.Bauhjahr = 2019;
            fahrzeugAUTO.AnhängerKupplung = false;
            fahrzeugAUTO.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugAUTO);

            //Auto3
            fahrzeugAUTO = new Auto();
            fahrzeugAUTO.Preis = 2350;
            fahrzeugAUTO.Hersteller = "Mazda";
            fahrzeugAUTO.Raeder = 4;
            fahrzeugAUTO.Kraftstoff = Energie.Benzin;
            fahrzeugAUTO.Leistung = 250;
            fahrzeugAUTO.SitzPlaetze = 2;
            fahrzeugAUTO.Standort = "Hamburg";
            fahrzeugAUTO.Bauhjahr = 2008;
            fahrzeugAUTO.AnhängerKupplung = true;
            fahrzeugAUTO.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugAUTO);

            //Auto4
            fahrzeugAUTO = new Auto();
            fahrzeugAUTO.Preis = 22500;
            fahrzeugAUTO.Hersteller = "Mercedes";
            fahrzeugAUTO.Raeder = 4;
            fahrzeugAUTO.Kraftstoff = Energie.Wasserstoff;
            fahrzeugAUTO.Leistung = 340;
            fahrzeugAUTO.SitzPlaetze = 5;
            fahrzeugAUTO.Standort = "Köln";
            fahrzeugAUTO.Bauhjahr = 2016;
            fahrzeugAUTO.AnhängerKupplung = false;
            fahrzeugAUTO.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugAUTO);

            //Auto5
            fahrzeugAUTO = new Auto();
            fahrzeugAUTO.Preis = 17800;
            fahrzeugAUTO.Hersteller = "BMW";
            fahrzeugAUTO.Raeder = 4;
            fahrzeugAUTO.Kraftstoff = Energie.Erdgas;
            fahrzeugAUTO.Leistung = 250;
            fahrzeugAUTO.SitzPlaetze = 4;
            fahrzeugAUTO.Standort = "Nürnberg";
            fahrzeugAUTO.Bauhjahr = 2019;
            fahrzeugAUTO.AnhängerKupplung = true;
            fahrzeugAUTO.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugAUTO);

            //LKW1
            fahrzeugLKW = new LKW();
            fahrzeugLKW.Preis = 53000;
            fahrzeugLKW.Hersteller = "Scania";
            fahrzeugLKW.Raeder = 6;
            fahrzeugLKW.Kraftstoff = Energie.Benzin;
            fahrzeugLKW.Leistung = 520;
            fahrzeugLKW.SitzPlaetze = 2;
            fahrzeugLKW.Standort = "Berlin";
            fahrzeugLKW.Bauhjahr = 2018;
            fahrzeugLKW.Ladevolumen = 23;
            fahrzeugLKW.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugLKW);

            //LKW2
            fahrzeugLKW = new LKW();
            fahrzeugLKW.Preis = 43290;
            fahrzeugLKW.Hersteller = "MAN";
            fahrzeugLKW.Raeder = 8;
            fahrzeugLKW.Kraftstoff = Energie.LKWDiesel;
            fahrzeugLKW.Leistung = 430;
            fahrzeugLKW.SitzPlaetze = 2;
            fahrzeugLKW.Standort = "Stuttgart";
            fahrzeugLKW.Bauhjahr = 2012;
            fahrzeugLKW.Ladevolumen = 16;
            fahrzeugLKW.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugLKW);

            //LKW3
            fahrzeugLKW = new LKW();
            fahrzeugLKW.Preis = 63000;
            fahrzeugLKW.Hersteller = "Mercedes";
            fahrzeugLKW.Raeder = 6;
            fahrzeugLKW.Kraftstoff = Energie.LKWDiesel;
            fahrzeugLKW.Leistung = 600;
            fahrzeugLKW.SitzPlaetze = 2;
            fahrzeugLKW.Standort = "München";
            fahrzeugLKW.Bauhjahr = 2020;
            fahrzeugLKW.Ladevolumen = 34;
            fahrzeugLKW.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugLKW);

            //LKW4
            fahrzeugLKW = new LKW();
            fahrzeugLKW.Preis = 32500;
            fahrzeugLKW.Hersteller = "Volvo";
            fahrzeugLKW.Raeder = 6;
            fahrzeugLKW.Kraftstoff = Energie.Erdgas;
            fahrzeugLKW.Leistung = 420;
            fahrzeugLKW.SitzPlaetze = 2;
            fahrzeugLKW.Standort = "Bremen";
            fahrzeugLKW.Bauhjahr = 2018;
            fahrzeugLKW.Ladevolumen = 30;
            fahrzeugLKW.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugLKW);

            //Motorrad 1
            fahrzeugMOTORRAD = new Motorrad();
            fahrzeugMOTORRAD.Preis = 30000;
            fahrzeugMOTORRAD.Hersteller = "Ducati";
            fahrzeugMOTORRAD.Raeder = 2;
            fahrzeugMOTORRAD.Kraftstoff = Energie.Benzin;
            fahrzeugMOTORRAD.Leistung = 210;
            fahrzeugMOTORRAD.SitzPlaetze = 2;
            fahrzeugMOTORRAD.Standort = "Dortmund";
            fahrzeugMOTORRAD.Bauhjahr = 2019;
            fahrzeugMOTORRAD.Seitenwagen = false;
            fahrzeugMOTORRAD.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugMOTORRAD);

            //Motorrad 2
            fahrzeugMOTORRAD = new Motorrad();
            fahrzeugMOTORRAD.Preis = 12000;
            fahrzeugMOTORRAD.Hersteller = "Kawasaki";
            fahrzeugMOTORRAD.Raeder = 2;
            fahrzeugMOTORRAD.Kraftstoff = Energie.Benzin;
            fahrzeugMOTORRAD.Leistung = 170;
            fahrzeugMOTORRAD.SitzPlaetze = 2;
            fahrzeugMOTORRAD.Standort = "Stuttgart";
            fahrzeugMOTORRAD.Bauhjahr = 2016;
            fahrzeugMOTORRAD.Seitenwagen = false;
            fahrzeugMOTORRAD.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugMOTORRAD);

            //Motorrad 3
            fahrzeugMOTORRAD = new Motorrad();
            fahrzeugMOTORRAD.Preis = 30000;
            fahrzeugMOTORRAD.Hersteller = "Ducati";
            fahrzeugMOTORRAD.Raeder = 2;
            fahrzeugMOTORRAD.Kraftstoff = Energie.Benzin;
            fahrzeugMOTORRAD.Leistung = 210;
            fahrzeugMOTORRAD.SitzPlaetze = 2;
            fahrzeugMOTORRAD.Standort = "München";
            fahrzeugMOTORRAD.Bauhjahr = 2019;
            fahrzeugMOTORRAD.Seitenwagen = false;
            fahrzeugMOTORRAD.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugMOTORRAD);

            //Motorrad 4
            fahrzeugMOTORRAD = new Motorrad();
            fahrzeugMOTORRAD.Preis = 3750;
            fahrzeugMOTORRAD.Hersteller = "KTM";
            fahrzeugMOTORRAD.Raeder = 2;
            fahrzeugMOTORRAD.Kraftstoff = Energie.Benzin;
            fahrzeugMOTORRAD.Leistung = 15;
            fahrzeugMOTORRAD.SitzPlaetze = 2;
            fahrzeugMOTORRAD.Standort = "Berlin";
            fahrzeugMOTORRAD.Bauhjahr = 2019;
            fahrzeugMOTORRAD.Seitenwagen = false;
            fahrzeugMOTORRAD.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugMOTORRAD);

            //Motorrad 5
            fahrzeugMOTORRAD = new Motorrad();
            fahrzeugMOTORRAD.Preis = 14300;
            fahrzeugMOTORRAD.Hersteller = "Ural";
            fahrzeugMOTORRAD.Raeder = 2;
            fahrzeugMOTORRAD.Kraftstoff = Energie.Benzin;
            fahrzeugMOTORRAD.Leistung = 80;
            fahrzeugMOTORRAD.SitzPlaetze = 2;
            fahrzeugMOTORRAD.Standort = "Berlin";
            fahrzeugMOTORRAD.Bauhjahr = 2012;
            fahrzeugMOTORRAD.Seitenwagen = true;
            fahrzeugMOTORRAD.Verfuegbar = true;

            FahrzeugListe.Add(fahrzeugMOTORRAD);
        }

        public void kundespeicher()
        {
            ConsoleKeyInfo cki;
            Fahrzeug fahrzeug = new Fahrzeug();

            Kunde kunde = new Kunde();

            Console.WriteLine("haben sie bereits ein KundenKonto? [j] [n]");
            cki = Console.ReadKey();
            Console.Clear();

            if (cki.KeyChar == 'j')
            {
                kunde.Kunden = kundenliste;

                Console.Write("Bitte geben sie ihren Namen ein  ");
                string Name = Console.ReadLine();
                Console.Clear();

                Console.Write("Bitte geben sie ihr Alter ein  ");
                int Alter = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                Console.Write("Bitte geben sie ihren Standort ein  ");
                string Standort = Console.ReadLine();
                Console.Clear();

                if (Standort == kunde.Standort && Name == kunde.Name && Alter == kunde.Alter)
                {
                    Console.WriteLine("Ihre Daten stimmen übereinander. ");
                    fahrzeug.Kundenname = kunde.Name;
                    fahrzeug.Verfuegbar = false;
                }
                else
                {
                    Console.WriteLine("Ihre Daten sind nicht in dem System");
                    Console.WriteLine("Möchten sie sich ein Kundenkonto erstellen mit diesen Daten? [j] [n]");

                    cki = Console.ReadKey();

                    if (cki.KeyChar == 'j')
                    { 
                        kundenliste.Add(new Kunde { Name = Name, Alter = Alter, Standort = Standort});
                        fahrzeug.Kundenname = Name;
                        fahrzeug.Verfuegbar = false;
                    }
                    else
                    {
                        Console.WriteLine("Sie können kein Auto ohne Konto erstellen ");
                        Thread.Sleep(3000);
                        kundespeicher();
                    }
                }
            }

            else
            {
                Console.WriteLine("Möchten sie sich ein Kundenkonto erstellen? [j] [n]");
                cki = Console.ReadKey();

                if (cki.KeyChar == 'j')
                {
                    kunde.hinzufuegen();
                    fahrzeug.Kundenname = kunde.Name;
                    fahrzeug.Verfuegbar = false;
                }
                else
                {
                }
            }
        }

        public void JsonSpeichern()
        {
            string jsonstring;
            jsonstring = JsonConvert.SerializeObject(FahrzeugListe, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            File.WriteAllText(speicherdatei ,jsonstring);
        }

        public void JsonLaden() 
        {
            string jsonstring;
            jsonstring = File.ReadAllText(speicherdatei);
            FahrzeugListe.AddRange(JsonConvert.DeserializeObject<List<Fahrzeug>>(jsonstring, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            }));
        }

        public void JsonSpeichernKunde()
        {
            string jsonstring;
            jsonstring = JsonConvert.SerializeObject(kundenliste, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            File.WriteAllText(speicherdateikunde, jsonstring);
        }

        public void JsonLadenKunde()
        {
            string jsonstring;
            jsonstring = File.ReadAllText(speicherdateikunde);
            kundenliste.AddRange(JsonConvert.DeserializeObject<List<Kunde>>(jsonstring, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            })); 
        }
    }
}
