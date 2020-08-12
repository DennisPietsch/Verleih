using System;
using System.Collections.Generic;
using System.Text;

namespace AutoKauf
{
    class DemoDatenSaetze
    {
        public static List<Fahrzeug> Fahrzeuge()
        {
            Auto fahrzeugAUTO = new Auto();
            LKW fahrzeugLKW = new LKW();
            Motorrad fahrzeugMOTORRAD = new Motorrad();

            List<Fahrzeug> FahrzeugListe = new List<Fahrzeug>();

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
            fahrzeugAUTO.Kundenname = "Thomas";

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

            return FahrzeugListe;
        }

        public static List<Kunde> Kunden()
        {
            List<Kunde> KundenListe = new List<Kunde>(); 

            KundenListe.Add(new Kunde("Stefan.Test@gmail.com", "Stefan", 29, "Heubach"));
            KundenListe.Add(new Kunde("Max.Mustermann@gmx.de", "Max", 44, "Düsseldorf"));
            KundenListe.Add(new Kunde("ThomasFriedlich1982@email.com", "Thoams", 32, "Stuttgart"));

            return KundenListe;
        }
    }
}
