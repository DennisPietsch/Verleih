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
            fahrzeugAUTO.standort = new Standort("Stuttgart", 48.778613, 9.180573);
            fahrzeugAUTO.Bauhjahr = 2012;
            fahrzeugAUTO.AnhängerKupplung = true;
            fahrzeugAUTO.Verfuegbar = false;
            fahrzeugAUTO.Kundenname = "Thomas";
            fahrzeugAUTO.FahrzeugID = "AAAA";

            FahrzeugListe.Add(fahrzeugAUTO);

            //Auto2 
            fahrzeugAUTO = new Auto();
            fahrzeugAUTO.Preis = 15000;
            fahrzeugAUTO.Hersteller = "VW";
            fahrzeugAUTO.Raeder = 4;
            fahrzeugAUTO.Kraftstoff = Energie.Strom;
            fahrzeugAUTO.Leistung = 150;
            fahrzeugAUTO.SitzPlaetze = 4;
            fahrzeugAUTO.standort = new Standort("Crailsheim", 49.134012, 10.063753);
            fahrzeugAUTO.Bauhjahr = 2019;
            fahrzeugAUTO.AnhängerKupplung = false;
            fahrzeugAUTO.Verfuegbar = true;
            fahrzeugAUTO.FahrzeugID = "FBH1";

            FahrzeugListe.Add(fahrzeugAUTO);

            //Auto3
            fahrzeugAUTO = new Auto();
            fahrzeugAUTO.Preis = 2350;
            fahrzeugAUTO.Hersteller = "Mazda";
            fahrzeugAUTO.Raeder = 4;
            fahrzeugAUTO.Kraftstoff = Energie.Benzin;
            fahrzeugAUTO.Leistung = 250;
            fahrzeugAUTO.SitzPlaetze = 2;
            fahrzeugAUTO.standort = new Standort("Hamburg", 53.551059, 9.992898);
            fahrzeugAUTO.Bauhjahr = 2008;
            fahrzeugAUTO.AnhängerKupplung = true;
            fahrzeugAUTO.Verfuegbar = true;
            fahrzeugAUTO.FahrzeugID = "KJS2";

            FahrzeugListe.Add(fahrzeugAUTO);

            //Auto4
            fahrzeugAUTO = new Auto();
            fahrzeugAUTO.Preis = 22500;
            fahrzeugAUTO.Hersteller = "Mercedes";
            fahrzeugAUTO.Raeder = 4;
            fahrzeugAUTO.Kraftstoff = Energie.Wasserstoff;
            fahrzeugAUTO.Leistung = 340;
            fahrzeugAUTO.SitzPlaetze = 5;
            fahrzeugAUTO.standort = new Standort("Köln", 50.937651, 6.959924);
            fahrzeugAUTO.Bauhjahr = 2016;
            fahrzeugAUTO.AnhängerKupplung = false;
            fahrzeugAUTO.Verfuegbar = true;
            fahrzeugAUTO.FahrzeugID = "WIEN";

            FahrzeugListe.Add(fahrzeugAUTO);

            //Auto5
            fahrzeugAUTO = new Auto();
            fahrzeugAUTO.Preis = 17800;
            fahrzeugAUTO.Hersteller = "BMW";
            fahrzeugAUTO.Raeder = 4;
            fahrzeugAUTO.Kraftstoff = Energie.Erdgas;
            fahrzeugAUTO.Leistung = 250;
            fahrzeugAUTO.SitzPlaetze = 4;
            fahrzeugAUTO.standort = new Standort("Dortmund", 51.513299, 7.465002);
            fahrzeugAUTO.Bauhjahr = 2019;
            fahrzeugAUTO.AnhängerKupplung = true;
            fahrzeugAUTO.Verfuegbar = true;
            fahrzeugAUTO.FahrzeugID = "2IE9";

            FahrzeugListe.Add(fahrzeugAUTO);

            //LKW1
            fahrzeugLKW = new LKW();
            fahrzeugLKW.Preis = 53000;
            fahrzeugLKW.Hersteller = "Scania";
            fahrzeugLKW.Raeder = 6;
            fahrzeugLKW.Kraftstoff = Energie.Benzin;
            fahrzeugLKW.Leistung = 520;
            fahrzeugLKW.SitzPlaetze = 2;
            fahrzeugLKW.standort = new Standort("Berlin", 52.520069, 13.404778);
            fahrzeugLKW.Bauhjahr = 2018;
            fahrzeugLKW.Ladevolumen = 23;
            fahrzeugLKW.Verfuegbar = true;
            fahrzeugLKW.FahrzeugID = "8UWB";

            FahrzeugListe.Add(fahrzeugLKW);

            //LKW2
            fahrzeugLKW = new LKW();
            fahrzeugLKW.Preis = 43290;
            fahrzeugLKW.Hersteller = "MAN";
            fahrzeugLKW.Raeder = 8;
            fahrzeugLKW.Kraftstoff = Energie.LKWDiesel;
            fahrzeugLKW.Leistung = 430;
            fahrzeugLKW.SitzPlaetze = 2;
            fahrzeugLKW.standort = new Standort("Dresden", 51.050702, 13.737526);
            fahrzeugLKW.Bauhjahr = 2012;
            fahrzeugLKW.Ladevolumen = 16;
            fahrzeugLKW.Verfuegbar = true;
            fahrzeugLKW.FahrzeugID = "BSOW";

            FahrzeugListe.Add(fahrzeugLKW);

            //LKW3
            fahrzeugLKW = new LKW();
            fahrzeugLKW.Preis = 63000;
            fahrzeugLKW.Hersteller = "Mercedes";
            fahrzeugLKW.Raeder = 6;
            fahrzeugLKW.Kraftstoff = Energie.LKWDiesel;
            fahrzeugLKW.Leistung = 600;
            fahrzeugLKW.SitzPlaetze = 2;
            fahrzeugLKW.standort = new Standort("München", 48.136728, 11.579453);
            fahrzeugLKW.Bauhjahr = 2020;
            fahrzeugLKW.Ladevolumen = 34;
            fahrzeugLKW.Verfuegbar = true;
            fahrzeugLKW.FahrzeugID = "92JH";

            FahrzeugListe.Add(fahrzeugLKW);

            //LKW4
            fahrzeugLKW = new LKW();
            fahrzeugLKW.Preis = 32500;
            fahrzeugLKW.Hersteller = "Volvo";
            fahrzeugLKW.Raeder = 6;
            fahrzeugLKW.Kraftstoff = Energie.Erdgas;
            fahrzeugLKW.Leistung = 420;
            fahrzeugLKW.SitzPlaetze = 2;
            fahrzeugLKW.standort = new Standort("Bremen", 53.078816, 8.802276);
            fahrzeugLKW.Bauhjahr = 2018;
            fahrzeugLKW.Ladevolumen = 30;
            fahrzeugLKW.Verfuegbar = true;
            fahrzeugLKW.FahrzeugID = "POWN";

            FahrzeugListe.Add(fahrzeugLKW);

            //Motorrad 1
            fahrzeugMOTORRAD = new Motorrad();
            fahrzeugMOTORRAD.Preis = 30000;
            fahrzeugMOTORRAD.Hersteller = "Ducati";
            fahrzeugMOTORRAD.Raeder = 2;
            fahrzeugMOTORRAD.Kraftstoff = Energie.Benzin;
            fahrzeugMOTORRAD.Leistung = 210;
            fahrzeugMOTORRAD.SitzPlaetze = 2;
            fahrzeugMOTORRAD.standort = new Standort("Stuttgart", 48.778613, 9.180573);
            fahrzeugMOTORRAD.Bauhjahr = 2019;
            fahrzeugMOTORRAD.Seitenwagen = false;
            fahrzeugMOTORRAD.Verfuegbar = true;
            fahrzeugMOTORRAD.FahrzeugID = "6JHS";

            FahrzeugListe.Add(fahrzeugMOTORRAD);

            //Motorrad 2
            fahrzeugMOTORRAD = new Motorrad();
            fahrzeugMOTORRAD.Preis = 12000;
            fahrzeugMOTORRAD.Hersteller = "Kawasaki";
            fahrzeugMOTORRAD.Raeder = 2;
            fahrzeugMOTORRAD.Kraftstoff = Energie.Benzin;
            fahrzeugMOTORRAD.Leistung = 170;
            fahrzeugMOTORRAD.SitzPlaetze = 2;
            fahrzeugMOTORRAD.standort = new Standort("Heidenheim", 48.689539, 10.161213);
            fahrzeugMOTORRAD.Bauhjahr = 2016;
            fahrzeugMOTORRAD.Seitenwagen = false;
            fahrzeugMOTORRAD.Verfuegbar = true;
            fahrzeugMOTORRAD.FahrzeugID = "82JS";

            FahrzeugListe.Add(fahrzeugMOTORRAD);

            //Motorrad 3
            fahrzeugMOTORRAD = new Motorrad();
            fahrzeugMOTORRAD.Preis = 30000;
            fahrzeugMOTORRAD.Hersteller = "Ducati";
            fahrzeugMOTORRAD.Raeder = 2;
            fahrzeugMOTORRAD.Kraftstoff = Energie.Benzin;
            fahrzeugMOTORRAD.Leistung = 210;
            fahrzeugMOTORRAD.SitzPlaetze = 2;
            fahrzeugMOTORRAD.standort = new Standort("Nürnberg", 49.452145, 11.076722);
            fahrzeugMOTORRAD.Bauhjahr = 2019;
            fahrzeugMOTORRAD.Seitenwagen = false;
            fahrzeugMOTORRAD.Verfuegbar = true;
            fahrzeugMOTORRAD.FahrzeugID = "7JSH";

            FahrzeugListe.Add(fahrzeugMOTORRAD);

            //Motorrad 4
            fahrzeugMOTORRAD = new Motorrad();
            fahrzeugMOTORRAD.Preis = 3750;
            fahrzeugMOTORRAD.Hersteller = "KTM";
            fahrzeugMOTORRAD.Raeder = 2;
            fahrzeugMOTORRAD.Kraftstoff = Energie.Benzin;
            fahrzeugMOTORRAD.Leistung = 15;
            fahrzeugMOTORRAD.SitzPlaetze = 2;
            fahrzeugMOTORRAD.standort = new Standort("Frankfurt", 50.110910, 8.681817);
            fahrzeugMOTORRAD.Bauhjahr = 2019;
            fahrzeugMOTORRAD.Seitenwagen = false;
            fahrzeugMOTORRAD.Verfuegbar = true;
            fahrzeugMOTORRAD.FahrzeugID = "4UHG";

            FahrzeugListe.Add(fahrzeugMOTORRAD);

            //Motorrad 5
            fahrzeugMOTORRAD = new Motorrad();
            fahrzeugMOTORRAD.Preis = 14300;
            fahrzeugMOTORRAD.Hersteller = "Ural";
            fahrzeugMOTORRAD.Raeder = 2;
            fahrzeugMOTORRAD.Kraftstoff = Energie.Benzin;
            fahrzeugMOTORRAD.Leistung = 80;
            fahrzeugMOTORRAD.SitzPlaetze = 2;
            fahrzeugMOTORRAD.standort = new Standort("Berlin", 52.520069, 13.404778);
            fahrzeugMOTORRAD.Bauhjahr = 2012;
            fahrzeugMOTORRAD.Seitenwagen = true;
            fahrzeugMOTORRAD.Verfuegbar = true;
            fahrzeugMOTORRAD.FahrzeugID = "8PWN";

            FahrzeugListe.Add(fahrzeugMOTORRAD);

            return FahrzeugListe;
        }

        public static List<Kunde> Kunden()
        {
            List<Kunde> KundenListe = new List<Kunde>(); 

            KundenListe.Add(new Kunde("Stefan.Test@gmail.com", "Stefan", 29, new Standort("Heubach", 48.793244, 9.931780)));
            KundenListe.Add(new Kunde("Max.Mustermann@gmx.de", "Max", 44, new Standort("Düsseldorf", 51.227755, 6.773522)));
            KundenListe.Add(new Kunde("ThomasFriedlich1982@email.com", "Thoams", 32, new Standort("Stuttgart", 48.778613, 9.180573)));

            return KundenListe;
        }

        public static List<Standort> StandorteSpeichern()
        {
            List<Standort> standortListe = new List<Standort>();

            standortListe.Add(new Standort("Aalen", 48.837849, 10.096976));
            standortListe.Add(new Standort("Stuttgart", 48.778613, 9.180573));
            standortListe.Add(new Standort("Crailsheim", 49.134012, 10.063753));
            standortListe.Add(new Standort("Ellwangen", 48.962504, 10.129871));
            standortListe.Add(new Standort("Berlin", 52.520069, 13.404778));
            standortListe.Add(new Standort("Frankfurt", 50.110910, 8.681817));
            standortListe.Add(new Standort("Nürnberg", 49.452145, 11.076722));
            standortListe.Add(new Standort("Heidenheim", 48.689539, 10.161213));

            return standortListe;
        }
    }
}
