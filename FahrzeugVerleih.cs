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
        const string speicherdateistandorte = "jsonlistestandorte";
        public List<Fahrzeug> FahrzeugListe = new List<Fahrzeug>();
        public List<Kunde> kundenliste = new List<Kunde>();
        public List<Standort> standortListe = new List<Standort>();

        public void FahrzeugAuswaehlen()
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

            Console.WriteLine("Wollen sie ein Fahrzeug leihen? [j] [n]");
            cki = Console.ReadKey();
            Console.Clear();
            if (cki.KeyChar == 'j')
            {
                Console.Write("Bitte geben sie die FahrzeugID ein: ");
                string ID = Console.ReadLine();

                foreach (var item in FahrzeugListe)
                {
                    if (item.FahrzeugID == ID)
                    {
                        if (item.Verfuegbar == true)
                        {
                            Console.Write("Wie lang möchten sie den Wagen ausleihen ");
                            int zeit = Convert.ToInt32(Console.ReadLine());

                            KundenListeUeberpruefen(item);

                            Console.WriteLine("Ihr Auto ist gemietet und bereit zur Abholung");
                            item.Verfuegbar = false;
                            item.AusgeliehenBIS = zeit;
                            item.AusgeliehenUM = DateTime.Now;

                            Thread.Sleep(5000);
                            Console.Clear();

                        }

                        else
                        {
                            Console.WriteLine("Fahrzeug ist nich Verfügabr ");
                            Thread.Sleep(3000);
                            FahrzeugLeihen();
                        }
                    }
                }
            }

            else
            {
                Console.Clear();
                return;
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

                    do
                    {
                        Console.Write("\n\nMöchten sie ein Auto genauer anschauen [j] [n] ");
                        cki = Console.ReadKey();
                        if (cki.KeyChar == 'j')
                        {
                            Console.Clear();
                            Console.Write("Geben sie die FahrzeugID ein: ");
                            string ID = Console.ReadLine();

                            foreach (var item in FahrzeugListe)
                            {
                                if (item.FahrzeugID == ID)
                                {
                                    item.DetailsAnschauen();
                                    Console.ReadKey();
                                    fahrzeuge.Clear();
                                    return;
                                }
                            }

                            Console.WriteLine("Diese FahrzeugID ist nich vorhanden");
                            Thread.Sleep(3000);
                        }

                        else
                        {
                            fahrzeuge.Clear();
                            Console.Clear();
                            return;
                        }

                    } while (true);

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

                    do
                    {
                        Console.Write("\n\nMöchten sie ein LKW genauer anschauen [j] [n] ");
                        cki = Console.ReadKey();
                        if (cki.KeyChar == 'j')
                        {
                            Console.Clear();
                            Console.Write("Geben sie die FahrzeugID ein: ");
                            string ID = Console.ReadLine();

                            foreach (var item in FahrzeugListe)
                            {
                                if (item.FahrzeugID == ID)
                                {
                                    item.DetailsAnschauen();
                                    Console.ReadKey();
                                    fahrzeuge.Clear();
                                    return;
                                }
                            }

                            Console.WriteLine("Diese FahrzeugID ist nich vorhanden");
                            Thread.Sleep(3000);
                        }

                        else
                        {
                            fahrzeuge.Clear();
                            Console.Clear();
                            return;
                        }

                    } while (true);

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

                    do
                    {
                        Console.Write("\n\nMöchten sie ein Motorrad genauer anschauen [j] [n] ");
                        cki = Console.ReadKey();
                        if (cki.KeyChar == 'j')
                        {
                            Console.Clear();
                            Console.Write("Geben sie die FahrzeugID ein: ");
                            string ID = Console.ReadLine();

                            foreach (var item in FahrzeugListe)
                            {
                                if (item.FahrzeugID == ID)
                                {
                                    item.DetailsAnschauen();
                                    Console.ReadKey();
                                    fahrzeuge.Clear();
                                    return;
                                }
                            }

                            Console.WriteLine("Diese FahrzeugID ist nich vorhanden");
                            Thread.Sleep(3000);
                        }

                        else
                        {
                            fahrzeuge.Clear();
                            Console.Clear();
                            return;
                        }

                    } while (true);

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

        public void FahrzeugHinzufuegenAbfrage()
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
                FahrzeugListe.Add(NeuesAUTOHinzufuegen());
            }
            else if (cki.KeyChar == '2')
            {
                Console.Clear();
                FahrzeugListe.Add(NeuenLKWHinzufuegen());
            }
            else if (cki.KeyChar == '3')
            {
                Console.Clear();
                FahrzeugListe.Add(NeuesMOTORRADHinzufuegen());
            }
        }

        public Fahrzeug NeuesAUTOHinzufuegen()
        {
            ConsoleKeyInfo cki;
            Auto fahrzeug = new Auto();

            Console.WriteLine("Wollen sie eine eigene FahrzeugID eingeben [e] oder eine ID generieren [g] lassen?");
            cki = Console.ReadKey();

            switch (cki.KeyChar)
            {
                case 'e':
                    Console.Clear();
                    Console.Write("Bitte geben sie eine FahrzeugID an: ");
                    string ID = Console.ReadLine();

                    if (ID.Length == 4)
                    {
                        Console.Clear();

                        foreach (var item in FahrzeugListe)
                        {
                            if (item.FahrzeugID == ID)
                            {
                                Console.WriteLine("Diese ID ist schon vergeben");
                                Thread.Sleep(3000);
                                Console.Clear();
                                NeuesAUTOHinzufuegen();
                            }
                        }

                        fahrzeug.FahrzeugID = ID;
                    }

                    else
                    {
                        Console.WriteLine("ID ist zu lang oder zu kurz");
                        Thread.Sleep(3000);
                        NeuesAUTOHinzufuegen();
                    }
                    break;

                case 'g':
                    fahrzeug.FahrzeugID = RandomString();
                    break;

                default:
                    Console.WriteLine("Keine gültige Eingabe");
                    Thread.Sleep(3000);
                    Console.Clear();
                    NeuesAUTOHinzufuegen();
                    break;
            }

            fahrzeug.standort = Standort.NeuenStandortHinzufuegen(standortListe);
            Console.Clear();

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
            switch (cki.KeyChar)
            {
                case '1':
                    fahrzeug.Kraftstoff = Energie.Benzin;
                    break;

                case '2':
                    fahrzeug.Kraftstoff = Energie.Diesel;
                    break;

                case '3':
                    fahrzeug.Kraftstoff = Energie.Wasserstoff;
                    break;

                case '4':
                    fahrzeug.Kraftstoff = Energie.Erdgas;
                    break;

                case '5':
                    fahrzeug.Kraftstoff = Energie.Strom;
                    break;

                default:
                    break;
            }

            fahrzeug.Verfuegbar = true;

            Console.Clear();
            Console.WriteLine("Ihr Fahrzeug wurde gespeichert  ");
            Thread.Sleep(3000);
            Console.Clear();
            return fahrzeug;
        }

        public Fahrzeug NeuesMOTORRADHinzufuegen()
        {
            ConsoleKeyInfo cki;
            Motorrad fahrzeug = new Motorrad();

            Console.WriteLine("Wollen sie eine eigene FahrzeugID eingeben [e] oder eine ID generieren [g] lassen?");
            cki = Console.ReadKey();

            switch (cki.KeyChar)
            {
                case 'e':
                    Console.Clear();
                    Console.Write("Bitte geben sie eine FahrzeugID an: ");
                    string ID = Console.ReadLine();

                    if (ID.Length == 4)
                    {
                        Console.Clear();

                        foreach (var item in FahrzeugListe)
                        {
                            if (item.FahrzeugID == ID)
                            {
                                Console.WriteLine("Diese ID ist schon vergeben");
                                Thread.Sleep(3000);
                                Console.Clear();
                                NeuesMOTORRADHinzufuegen();
                            }
                        }
                        fahrzeug.FahrzeugID = ID;
                    }

                    else
                    {
                        Console.WriteLine("ID ist zu lang oder zu kurz");
                        Thread.Sleep(3000);
                        NeuesMOTORRADHinzufuegen();
                    }
                    break;

                case 'g':
                    fahrzeug.FahrzeugID = RandomString();
                    break;

                default:
                    Console.WriteLine("Keine gültige Eingabe");
                    Thread.Sleep(3000);
                    Console.Clear();
                    NeuesMOTORRADHinzufuegen();
                    break;
            }

            fahrzeug.standort = Standort.NeuenStandortHinzufuegen(standortListe);
            Console.Clear();

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

            switch (cki.KeyChar)
            {
                case '1':
                    fahrzeug.Kraftstoff = Energie.Benzin;
                    break;

                case '2':
                    fahrzeug.Kraftstoff = Energie.Diesel;
                    break;

                case '3':
                    fahrzeug.Kraftstoff = Energie.Wasserstoff;
                    break;

                case '4':
                    fahrzeug.Kraftstoff = Energie.Erdgas;
                    break;

                case '5':
                    fahrzeug.Kraftstoff = Energie.Strom;
                    break;

                default:
                    break;
            }

            fahrzeug.Verfuegbar = true;

            Console.Clear();
            Console.WriteLine("Ihr Fahrzeug wurde gespeichert  ");
            Thread.Sleep(3000);
            Console.Clear();
            return fahrzeug;
        }

        public Fahrzeug NeuenLKWHinzufuegen()
        {
            ConsoleKeyInfo cki;
            LKW fahrzeug = new LKW();

            Console.WriteLine("Wollen sie eine eigene FahrzeugID eingeben [e] oder eine ID generieren [g] lassen?");
            cki = Console.ReadKey();

            switch (cki.KeyChar)
            {
                case 'e':
                    Console.Clear();
                    Console.Write("Bitte geben sie eine FahrzeugID an: ");
                    string ID = Console.ReadLine();

                    if (ID.Length == 4)
                    {
                        Console.Clear();

                        foreach (var item in FahrzeugListe)
                        {
                            if (item.FahrzeugID == ID)
                            {
                                Console.WriteLine("Diese ID ist schon vergeben");
                                Thread.Sleep(3000);
                                Console.Clear();
                                NeuenLKWHinzufuegen();
                            }
                        }
                        fahrzeug.FahrzeugID = ID;
                    }

                    else
                    {
                        Console.WriteLine("ID ist zu lang oder zu kurz");
                        Thread.Sleep(3000);
                        NeuenLKWHinzufuegen();
                    }
                    break;

                case 'g':
                    fahrzeug.FahrzeugID = RandomString();
                    break;

                default:
                    Console.WriteLine("Keine gültige Eingabe");
                    Thread.Sleep(3000);
                    Console.Clear();
                    NeuenLKWHinzufuegen();
                    break;
            }

            fahrzeug.standort = Standort.NeuenStandortHinzufuegen(standortListe);
            Console.Clear();

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
            switch (cki.KeyChar)
            {
                case '1':
                    fahrzeug.Kraftstoff = Energie.Benzin;
                    break;

                case '2':
                    fahrzeug.Kraftstoff = Energie.Diesel;
                    break;

                case '3':
                    fahrzeug.Kraftstoff = Energie.Wasserstoff;
                    break;

                case '4':
                    fahrzeug.Kraftstoff = Energie.Erdgas;
                    break;

                case '5':
                    fahrzeug.Kraftstoff = Energie.Strom;
                    break;

                default:
                    break;
            }

            fahrzeug.Verfuegbar = true;

            Console.Clear();
            Console.WriteLine("Ihr Fahrzeug wurde gespeichert  ");
            Thread.Sleep(3000);
            Console.Clear();
            return fahrzeug;
        }

        public void KundenListeUeberpruefen(Fahrzeug fahrzeug)
        {
            ConsoleKeyInfo cki;
            Kunde kunde = new Kunde();

            Console.WriteLine("haben sie bereits ein KundenKonto? [j] [n]");
            cki = Console.ReadKey();
            Console.Clear();

            if (cki.KeyChar == 'j')
            {
                Console.WriteLine("Bitte geben sie ihre EMail Addresse ein ");
                string email = Console.ReadLine();
                Console.Clear();

                foreach (var item in kundenliste)
                {
                    if (email == item.EMail)
                    {
                        Console.WriteLine("Ihre Email-Addresse ist in unserem System ");
                        fahrzeug.Kundenname = item.Name;
                        fahrzeug.Verfuegbar = false;

                        if (item.Guthaben - fahrzeug.Preis < 10)
                        {
                            GuthabenAufladen(item, fahrzeug);
                        }

                        else
                        {
                            item.Guthaben = item.Guthaben - (fahrzeug.Preis * fahrzeug.AusgeliehenBIS);
                        }

                        item.VermietetesAuto = fahrzeug;
                        return;
                    }
                }
                Console.Clear();
                Console.WriteLine("Ihre Email-Addresse ist nicht in unserem System");
                Console.WriteLine("Möchten sie sich ein Kundenkonto erstellen? [j] [n]");

                cki = Console.ReadKey();

                Console.Clear();

                if (cki.KeyChar == 'j')
                {
                    kundenliste.Add(kunde.NeuenKundenHinzufuegen(standortListe, kundenliste));
                    fahrzeug.Kundenname = kunde.Name;
                    fahrzeug.Verfuegbar = false;
                }
                else
                {
                    Console.WriteLine("Sie können kein Auto ohne Konto leihen ");
                    Thread.Sleep(3000);
                    KundenListeUeberpruefen(fahrzeug);
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Möchten sie sich ein Kundenkonto erstellen? [j] [n]");
                cki = Console.ReadKey();
                Console.Clear();
                if (cki.KeyChar == 'j')
                {
                    kundenliste.Add(kunde.NeuenKundenHinzufuegen(standortListe, kundenliste));

                    kunde.Guthaben = kunde.Guthaben - (fahrzeug.Preis * fahrzeug.AusgeliehenBIS);

                    fahrzeug.Kundenname = kunde.Name;
                    fahrzeug.Verfuegbar = false;
                }
                else
                {
                    Console.WriteLine("Sie können kein Auto ohne Konto leihen ");
                    Thread.Sleep(3000);
                    KundenListeUeberpruefen(fahrzeug);
                }
            }
        }

        public void AutoInJSONListeSpeichern()
        {
            string jsonstring;
            jsonstring = JsonConvert.SerializeObject(FahrzeugListe, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            File.WriteAllText(speicherdatei, jsonstring);
        }

        public void AutoAusJSONListeLaden()
        {
            string jsonstring;
            jsonstring = File.ReadAllText(speicherdatei);
            FahrzeugListe.AddRange(JsonConvert.DeserializeObject<List<Fahrzeug>>(jsonstring, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            }));
        }

        public void KundeInJSONListeSpeichern()
        {
            string jsonstring;
            jsonstring = JsonConvert.SerializeObject(kundenliste, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            File.WriteAllText(speicherdateikunde, jsonstring);
        }

        public void KundeAusJSONListeLaden()
        {
            string jsonstring;
            jsonstring = File.ReadAllText(speicherdateikunde);
            kundenliste.AddRange(JsonConvert.DeserializeObject<List<Kunde>>(jsonstring, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            }));
        }

        public void StandorteInJSONListeSpeichern()
        {
            string jsonstring;
            jsonstring = JsonConvert.SerializeObject(standortListe, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            File.WriteAllText(speicherdateistandorte, jsonstring);
        }

        public void StandorteAusJSONListeLaden()
        {
            string jsonstring;
            jsonstring = File.ReadAllText(speicherdateistandorte);
            standortListe.AddRange(JsonConvert.DeserializeObject<List<Standort>>(jsonstring, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            }));
        }

        public string RandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var stringChars = new char[4 ];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);

            return finalString;
        }

        public void GuthabenAufladen(Kunde kunde, Fahrzeug fahrzeug)
        {
            ConsoleKeyInfo cki;

            kunde.Guthaben = kunde.Guthaben - (fahrzeug.Preis * fahrzeug.AusgeliehenBIS);

            if (kunde.Guthaben < 0)
            {
                Console.Clear();
                Console.WriteLine("Ihr Guthaben ist aufgebraucht: ");
                Console.WriteLine("Sie müssen Geld aufladen ");
                Console.WriteLine("\nGeld aufladen? [j] [n]");
                cki = Console.ReadKey();
                Console.Clear();

                switch (cki.KeyChar)
                {
                    case 'j':
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Aktuelles Guthaben: " + kunde.Guthaben);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Betrag eingeben: ");

                        double aufladen = Convert.ToDouble(Console.ReadLine());
                        Console.Clear();

                        if (kunde.Guthaben + aufladen >= 0)
                        {
                            kunde.Guthaben = kunde.Guthaben + aufladen;
                            return;
                        }

                        else
                        {
                            Console.WriteLine("Guthaben ist zu niedrig... neu eingeben");
                            Thread.Sleep(3000);

                            GuthabenAufladen(kunde, fahrzeug);
                        }
                        break;

                    case 'n':
                        Console.WriteLine("Vorgang wird abgebrochen: ");
                        Thread.Sleep(3000);
                        Console.Clear();
                        KundenListeUeberpruefen(fahrzeug);
                        break;

                    default:
                        Console.WriteLine("Keine Mögliche Auswahl ");
                        Thread.Sleep(3000);
                        GuthabenAufladen(kunde, fahrzeug);
                        break;
                }
            }
        }
    }
}