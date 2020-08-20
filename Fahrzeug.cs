using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AutoKauf
{
    public class Fahrzeug
    {
        private int sitzPlaetze;
        private int raeder;
        private int leistung;
        private int bauhjahr;
        private int preis;
        private Standort standortle;
        private string hersteller;
        private Energie kraftstoff;
        private bool verfuegbar;
        private string kundenname;
        private int ausgeliehenBIS;
        private DateTime ausgeliehenUM;
        private int wiederVerfuegbar;
        private string fahrzeugID;

        public int SitzPlaetze
        {
            get { return sitzPlaetze; }
            set { sitzPlaetze = value; }
        }

        public int Raeder
        {
            get { return raeder; }
            set { raeder = value; }
        }

        public int Leistung
        {
            get { return leistung; }
            set { leistung = value; }
        }

        public int Bauhjahr
        {
            get { return bauhjahr; }
            set { bauhjahr = value; }
        }

        public int Preis
        {
            get { return preis; }
            set { preis = value; }
        }

        public Standort standort
        {
            get { return standortle; }
            set { standortle = value; }
        }

        public string Hersteller
        {
            get { return hersteller; }
            set { hersteller = value; }
        }

        public Energie Kraftstoff
        {
            get { return kraftstoff; }
            set { kraftstoff = value; }
        }

        public bool Verfuegbar
        {
            get { return verfuegbar; }
            set { verfuegbar = value; }
        }

        public string Kundenname
        {
            get { return kundenname; }
            set { kundenname = value; }
        }

        public DateTime AusgeliehenUM
        {
            get { return ausgeliehenUM; }
            set { ausgeliehenUM = value; }
        }

        public int AusgeliehenBIS
        {
            get { return ausgeliehenBIS; }
            set { ausgeliehenBIS = value; }
        }

        public int WiederVerfuegbar
        {
            get { return wiederVerfuegbar; }
            set { wiederVerfuegbar = value; }
        }

        public string FahrzeugID
        {
            get { return fahrzeugID; }
            set { fahrzeugID = value; }
        }

        public virtual void Anzeigen(int counter)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fahrzeug ID: " + FahrzeugID);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Hersteller: " + Hersteller);
            Console.WriteLine("Preis " + Preis + "Euro");
            Console.WriteLine("Standort: " + standort.Stadt);
            if (Verfuegbar == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Verfügbar: " + Verfuegbar);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Verfügbar " + Verfuegbar);
                Console.WriteLine("Verfügbar in " + AusgeliehenBIS);
                Console.ForegroundColor = ConsoleColor.Gray;

                wiederverfuegbar();
            }
        }

        public void DetailsAnschauen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FahrzeugID: " + FahrzeugID);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Hersteller: " + Hersteller);
            Console.WriteLine("Preis: " + Preis);
            Console.WriteLine("Standort: " + standort.Stadt);
            Console.WriteLine("Leistung: " + Leistung + " PS");
            Console.WriteLine("Baujahr: " + Bauhjahr);
            Console.WriteLine("Kraftstoff: " + Kraftstoff);
            Console.WriteLine("SitzPlätze: " + SitzPlaetze);
            Console.WriteLine("Räder: " + Raeder);
            Console.WriteLine("Verfügbar: " + Verfuegbar);

            if (Verfuegbar == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Kunde: " + Kundenname);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void wiederverfuegbar()
        {
            if (AusgeliehenUM.AddMinutes(AusgeliehenBIS) <= DateTime.Now)
            {
                Verfuegbar = true;
                kundenname = null;
            }
        }
    }
}
