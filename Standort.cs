using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace AutoKauf
{
    public class Standort
    {
        private Fahrzeug fahrzeug;

        public List<Standort> Koordinaten = new List<Standort>();

        public double LaengeLaengenGrad = 71.44;

        public double LaengeBreitenGrad = 111.13;

        public string Stadt { get; set; }
        
        public double XKoord { get; set; }
               
        public double YKoord { get; set; }

        public Fahrzeug Fahrzeuge
        {
            get { return fahrzeug; }
            set { fahrzeug = value; }
        }

        //public double BreitenGrad { get; set; }

        //public double LaengenGrad { get; set; }

        public void StandortAbfrage()
        {
            Console.Clear();
            double Distanz;

            Console.WriteLine("Bitte geben sie ihren Breitengrad ein ");
            double BreitenGrad = Convert.ToDouble(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Bitte geben sie ihren Längengrad ein ");
            double LaengenGrad = Convert.ToDouble(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("In welchem Umkreis möchten sie ein Auto suchen?");
            double Umkreis = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            foreach (var StandortAbfrage in Koordinaten)
            {
                double Breitengradneu = 0, Laengengradneu = 0;

                Breitengradneu = BreitenGrad - StandortAbfrage.XKoord;
                Laengengradneu = LaengenGrad - StandortAbfrage.YKoord;

                Breitengradneu = Breitengradneu * LaengeBreitenGrad;
                Laengengradneu = Laengengradneu * LaengeLaengenGrad;

                Distanz = Math.Sqrt((Laengengradneu * Laengengradneu) + (Breitengradneu * Breitengradneu));

                if (Distanz < Umkreis)
                {
                    Console.WriteLine(StandortAbfrage.Stadt, Distanz);
                }
            }

            /*BreitenGrad = BreitenGrad - StuttgartBreite;
            LaengenGrad = LaengenGrad - StuttgartLaenge;

             && Distanz > Umkreisneg

            BreitenGrad = BreitenGrad * LaengeLaengenGrad;
            LaengenGrad = LaengenGrad * LaengeLaengenGrad;

            Distanz = Math.Sqrt((LaengenGrad * LaengenGrad) + (BreitenGrad * BreitenGrad));

            Console.WriteLine("Distanz zwischen ihrem Standort und dem Wagen betragen {0}KM", Distanz);*/
            Console.ReadKey();
        }

        public Standort(string StandortName, double BreitenGrad, double Laengengrad)
        {
            Stadt = StandortName;
            XKoord = BreitenGrad;
            YKoord = Laengengrad;
        }
        
        public Standort()
        {
        }

        public void TestKoordinatenHinzufuegen()
        {
            Koordinaten.Add(new Standort("Aalen", 48.837849, 10.096976));
            Koordinaten.Add(new Standort("Stuttgart", 48.778613, 9.180573));
            Koordinaten.Add(new Standort("Crailsheim", 49.134012, 10.063753));
            Koordinaten.Add(new Standort("Ellwangen", 48.962504, 10.129871));
            Koordinaten.Add(new Standort("Berlin", 52.520069, 13.404778));
            Koordinaten.Add(new Standort("Frankfurt", 50.110910, 8.681817));
            Koordinaten.Add(new Standort("Nürnberg", 49.452145, 11.076722));
            Koordinaten.Add(new Standort("Heidenheim", 48.689539, 10.161213));
        }

        public static Standort NeuenStandortHinzufuegen(List<Standort> standortListe)
        {
            Console.Write("Bitte geben sie die Stadt ein in der ihr Fahrzeug steht ");
            string city = Console.ReadLine();

            foreach (var item in standortListe)
            {
                if (city == item.Stadt)
                {
                    Console.WriteLine("Der Standort wurde eingetragen");
                    return item;
                }
            }
            
            Console.Write("Bitte geben sie den Breitengrad der Stadt an ");
            double Breitengrad = Convert.ToDouble(Console.ReadLine());
            Console.Clear();

            Console.Write("Bitte geben sie den Längengrad der Stadt an ");
            double Laengengrad = Convert.ToDouble(Console.ReadLine());
            Console.Clear();

            Standort standort = new Standort(city, Breitengrad, Laengengrad);

            return standort;
        }
    }
}
