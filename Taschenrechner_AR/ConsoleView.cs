using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner_AR
{
    /// <summary>
    ///  Klasse ConsoleView
    /// </summary>
    class ConsoleView
    {
        /// Die Klasse ConsoleView muss erst die Klasse RechnerModel kennen.
        /// Dafuer brauchen wir ein attribut von model um den Inhalt zugreifen zu koennen.
        private RechnerModel model;
        
        // Und ein Konstruktor mit model als parameter um deren Inhaelte zugreifen zu koennen
        public ConsoleView(RechnerModel model)
        {
            this.model = model;
            //das attribut(this.model) hier wird das parameter(model) uebernehmen

            BenutzerWillBeenden = false;
        }

        public bool  BenutzerWillBeenden { get;  private set; }

        /// Hier werden die Eigaben in den neue Properties entsprechend gespeichert
        /// While Schleife Verbesserungen 
        public void HoleEingabenFuerErsteBerechnungVomBenutzer()
        {
            model.ErsteZahl = HoleZahlvonBenutzer();
            model.Operation = HoleOperatorVonBenutzer();
            model.ZweiteZahl = HoleZahlvonBenutzer();
        }

        /// Hier wird das fertig eingabe erkannt zum beenden!
        public void HoleEingabenFuerFortlaufendeBerechnung()
        {
            string eingabe = HoleNaechsteAktionVomBenutzer();

            /// Video 92 - Fehler finden, Verwende unzulaessige Werte und Grenzwert
            if (eingabe.ToUpper() == "FERTIG")    // Kleine Verbesserung um alle gross/klein schreiben zu erkennen (Fertig/fertig/FERTIG/FERtig...)
            {
                BenutzerWillBeenden = true;
            }
            else
            {
                model.ErsteZahl = model.Resultat;   // hier nehmen wir das alte Resultat als erste Zahl
                model.ZweiteZahl = Convert.ToDouble(eingabe);//und geben die Zweite Zahl ein.
            }
        }

        private string HoleNaechsteAktionVomBenutzer()
        {
            Console.Write("Bitte gib eine weitere Zahl ein (Fertig zum Beenden): ");
            return Console.ReadLine();
        }

        /// Korrektur fuer die Klasse ConsoleView. 
        /// Die Strings aus Program main muessten raus, dafuer brauchen wir neue Methoden, an unsere Klasse entsprechend angepasst.
        /// Machnmal die Methode die wir so schoen standarisiert hatten, muessen neu angepasst sein auf die neue Klassen
        /// Diese 3 methoden sind die Loesung von Lehrer, meine (HoleGueltigeOperation) istrein integriert in HoleOperatorVonBenutzer
        //-------------------------------------
        private double HoleZahlvonBenutzer()
        {
            Console.Write("\nBitte geben Sie eine Zahl ein : ");
            string eingabe = Console.ReadLine();

            /// Video 92 - Fehler finden, Verwende unzulaessige Werte und Grenzwert
            /// braucht man auch Wertgrenzen fuer zu groesse und zu kleine Werte.
            /// sonst z.B. wird ueberlaufen mit Unendlich ersetzt(als 8 dargestellt).
            return VonStringNachDouble(eingabe);
        }
        private string HoleOperatorVonBenutzer()
        {
            //Console.Write("Jetzt die Operation (+, -, ., *, /): "); 
            //return Console.ReadLine();
            /// Video 87 While Schleife Verbesserungen -Hier mit meine HoleGueltigeOperation ersetzt
            /// Video 92 - Fehler finden, Verwende unzulaessige Werte und Grenzwerte
            /// Ungueltige Operationsymbole muessen vermeiden werden.

            string operationSymbol = "";
            while ((operationSymbol != "+") && (operationSymbol != "-") && (operationSymbol != "*") && (operationSymbol != ".") && (operationSymbol != "/"))
            {
                operationSymbol = HoleBenutzerEingabe("\nJetzt die Operation (+, -, ., *, /): ");
            }
            return operationSymbol;
        }

        // Fuer Operation eingabe nur! nur ein Key bzw. Char!!
        public string HoleBenutzerEingabe(string ausgabeText)
        {
            Console.Write(ausgabeText);
            //string Eingabe = Console.ReadLine();
            string Eingabe = Console.ReadKey().KeyChar.ToString();
            /// Verbesserung nur eich char auslesen,  kein enter noetig, wie in ein Taschenrechner.
            return Eingabe;
        }


        /// <summary>
        /// Ausgabe  in Methode getrennt, nur gueltige Operetionsymbole werden akzeptiert
        /// <summary>
        public void KompletteBerechnungAusgeben()

        {
            //kompletteAusgabe ist der string um die Ausgabe getrennt zu formatieren
            string kompletteAusgabe = "\nDas {4} Resultat ist: \n   {0} \n {3} {1} \n--------\n   {2}";
            //Operation Name auch anpassen
            string operationAlsText = "";
            switch (model.Operation)
            {
                case "+":
                    {
                        operationAlsText = "Addieren";
                        break;
                    }
                case "-":
                    {
                        operationAlsText = "Substrahieren";
                        break;
                    }
                case ".":
                case "*":
                    {
                        operationAlsText = "Multiplikation";
                        break;
                    }
                case "/":
                    {
                        operationAlsText = "Division";
                        break;
                    }

                default:
                    {
                        operationAlsText = ("\nERROR, OPERATION UNGÜLTIG!!\n");
                        break;
                    }
            }
            //Console.WriteLine(kompletteAusgabe, ersterZahl, zweiterZahl, ergebnis, operation, operationAlsText);
            Console.WriteLine(kompletteAusgabe, model.ErsteZahl, model.ZweiteZahl, model.Resultat, model.Operation, operationAlsText);
            /// Korrektur fuer die Klasse ConsoleView: kein Parameter mehr sondern werden aus der model geholt!!
        }

        static double VonStringNachDouble(string eingabe)
        {
            return Convert.ToDouble(eingabe);
            /// Video 92 - Fehler finden, Verwende unzulaessige Werte und Grenzwerte
            /// Zahlen: Nichts eingeben, Buchstaben, Punkt wird einfach ignoriert...
            /// Ungueltige Zahlen muessen vermeiden werden.
            /// Video 94 Ausnahmen(exceptions) Wenn Etwas unerwartetes passiert
            /// Ausnahmen kommen wenn etwas unerwartet kommt. 
            /// Kann man nur hier gesehen, sonst wird das Programm abbrechen oder voellig durcheinander kommen.
            /// Werden vermieden bzw gefangen via TRY und CATCH.
            /// Dies ist nur grundinfo. Erstmal nur wissen das Ausnahmen da sind und koennen passieren.


        }
    }
}
