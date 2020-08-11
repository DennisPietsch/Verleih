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

        public virtual void Anzeigen(int counter)
        {
            Console.WriteLine("Fahrzeug {0} ", counter);
            Console.WriteLine("\nHersteller: " + Hersteller);
            Console.WriteLine("Preis " + Preis + "Euro");
            Console.WriteLine("Standort: " + Standort);
            Console.WriteLine("Verfügbar " + Verfuegbar);
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
        }
    }
}
