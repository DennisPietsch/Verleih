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
        private string standort;
        private string hersteller;
        private Energie kraftstoff;
        private bool verfuegbar;
        private string kundenname;
        private int ausgeliehenBIS;
        private DateTime ausgeliehenUM;
        private int wiederVerfuegbar;

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

        public string Standort
        {
            get { return standort; }
            set { standort = value; }
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

        public virtual void Anzeigen(int counter)
        {  
            Console.WriteLine("\nFahrzeug {0} ", counter);
            Console.WriteLine("Hersteller: " + Hersteller);
            Console.WriteLine("Preis " + Preis + "Euro");
            Console.WriteLine("Standort: " + Standort);
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
            }
        }

        public void DetailsAnschauen()
        {
            Console.WriteLine("Hersteller: " + Hersteller);
            Console.WriteLine("Preis: " + Preis);
            Console.WriteLine("Standort: " + Standort);
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
