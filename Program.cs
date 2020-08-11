using System;
using System.Threading;

namespace AutoKauf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FahrzeugVerleih verleih = new FahrzeugVerleih();
            Kunde kunde = new Kunde();
            ConsoleKeyInfo cki;
            verleih.speichern();
            kunde.speichern();
            

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
                        verleih.Fahrzeughinzufuegen();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        verleih.FahrzeugeAnzeigen();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        kunde.hinzufuegen();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        kunde.auslesen();
                        break;

                    case ConsoleKey.Escape:
                        verleih.JsonSpeichern();
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
