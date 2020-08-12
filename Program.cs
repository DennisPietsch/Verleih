using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace AutoKauf
{
    public class Program
    {
        const string speicherdatei = "jsonliste";
        const string speicherdateikunde = "jsonlistekunde";

        public static void Main(string[] args)
        {
            FahrzeugVerleih verleih = new FahrzeugVerleih();
            Kunde kunde = new Kunde();

            ConsoleKeyInfo cki;

            if (File.Exists(speicherdatei))
            {
                verleih.AutoAusJSONListeLaden();
            }

            else
            {
                verleih.FahrzeugListe.AddRange(DemoDatenSaetze.Fahrzeuge());
            }

            if (File.Exists(speicherdateikunde))
            {
                verleih.KundeAusJSONListeLaden();
            }

            else
            {
                verleih.kundenliste.AddRange(DemoDatenSaetze.Kunden());
            }

            //verleih.kundenliste.AddRange(DatenSpeichern.KundenListeSpeichern());

            do
            {
                Console.WriteLine("Was möchten sie machen?");
                Console.WriteLine("[1] Fahrzeug ausleihen");
                Console.WriteLine("[2] Fahrzeug hinzufügen");
                Console.WriteLine("[3] Verfügbare Fahrzeuge checken");
                Console.WriteLine("[4] Als Kunde eintragen");
                Console.WriteLine("[5] Kunden auslesen");
                Console.WriteLine("[ESC] EXIT");

                cki = Console.ReadKey();
                Console.Clear();

                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        verleih.FahrzeugLeihen();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        verleih.FahrzeugHinzufuegenAbfrage();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        verleih.FahrzeugeAnzeigen();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        verleih.kundenliste.Add(kunde.NeuenKundenHinzufuegen());
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        kunde.KundenListeAuslesen(verleih.kundenliste);
                        break;

                    case ConsoleKey.Escape:
                        verleih.AutoInJSONListeSpeichern();
                        verleih.KundeInJSONListeSpeichern();
                        Environment.Exit(0);
                        break; 

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fehler");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                }
            } while (true);

        }
    }
}
