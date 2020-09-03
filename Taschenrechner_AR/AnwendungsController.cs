using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner_AR
{
    class AnwendungsController
    {
        /// Video 83 Klebstoff zwischen die anderen Klassen ---> AnwendungsController
        /// 
        private ConsoleView view;
        private RechnerModel model;
        //wir zugreifen an die anderen klassen und beim ein Objekt erstellen werden die beide auch gebrauckt im Konstruktor
        public AnwendungsController(ConsoleView view, RechnerModel model)
        {
            this.view = view;
            this.model = model;
            //das attribut(this.model) hier wird das parameter(model) uebernehmen
        }

        public void Ausfuehren()
        {
            /// Video 87 While Schleife - wollen wir noch ne Runde?
            /// Das ganze Hauptteil des Ausfuhrens in ein WHILE kapseln:
            /// 
            /// Video 87 While Schleife Verbesserungen erster while auskommentiert
            ///while (!view.BenutzerWillBeenden)
            ///{
            /// Video 83 alles aus der main rauskopiert erstmal.
            /// Video 82 Korrektur fuer die Klasse ConsoleView. Die Strings aus Program main muessten raus,
            ///string ersteZahlAlsString = view.HoleBenutzerEingabe("\n\nBitte geben Sie die erste Zahl ein : ");
            ///string operation = "";
            ///operation = view.HoleGueltigeOperation(operation);
            ///string zweiteZahlAlsString = view.HoleBenutzerEingabe("Bitte geben Sie die zweite Zahl ein: ");
            ///double ersteZahl = view.HoleZahlvonBenutzer();
            ///string operation = view.HoleOperatorVonBenutzer();
            ///double  zweiteZahl = view.HoleZahlvonBenutzer();
            /// Video 83 ZahlEingaben schon direkt konvertiert

            /// Video 84 MVC Bonus - Mehr Verantwortung fuer den ConsoleView
            //view.HoleEigabenVomBenutzer();
            /// Video 87 While Schleife Verbesserungen
            view.HoleEingabenFuerErsteBerechnungVomBenutzer();


            bool youShallNotDivideByZero = ((model.Operation == "/") && (model.ZweiteZahl == 0));
            if (youShallNotDivideByZero)
            {
                Console.WriteLine("YOU SHALL NOT DIVIDE BY ZERO");
                Console.WriteLine("ALSO NEVER GOOGLE 'google'");
            }
            else
            {
                ///Berechnung Ausfuehren
                model.Berechne();
                ///Ausgabe
                view.KompletteBerechnungAusgeben();
            }

            ///}/// Video 87 While Schleife Verbesserungen
            // Programm Beenden
            //view.HoleBenutzerEingabe("\n\nDrücken Sie bitte die ENTER Taste zum beenden");
            /// Video 87 While Schleife Verbesserungen
            /// view.WarteAufEndeDurchBenutzer();
            view.HoleEingabenFuerFortlaufendeBerechnung();

            while (!view.BenutzerWillBeenden)
            {

                youShallNotDivideByZero = ((model.Operation == "/") && (model.ZweiteZahl == 0));
                if (youShallNotDivideByZero)
                {
                    Console.WriteLine("YOU SHALL NOT DIVIDE BY ZERO");
                    Console.WriteLine("ALSO NEVER GOOGLE 'google'");
                }
                else
                {
                    ///Berechnung Ausfuehren
                    model.Berechne();
                    ///Ausgabe
                    view.KompletteBerechnungAusgeben();
                }
                view.HoleEingabenFuerFortlaufendeBerechnung();
            }

        }
    }
}
