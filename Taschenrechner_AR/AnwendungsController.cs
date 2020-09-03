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
        private ConsoleView view;
        private RechnerModel model;
        //wir zugreifen an die anderen klassen und beim ein Objekt erstellen werden die beide auch gebraucht im Konstruktor
        public AnwendungsController(ConsoleView view, RechnerModel model)
        {
            this.view = view;
            this.model = model;
            //das attribut(this.model) hier wird das parameter(model) uebernehmen
        }

        public void Ausfuehren()
        {
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
                view.HoleEingabenFuerFortlaufendeBerechnung(); // hier haben wir die Wiederholung
            }

        }
    }
}
