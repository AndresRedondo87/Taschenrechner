using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner_AR
{
    /// <summary>
    ///  Video 81 Mini-UEbung - erstelle die Klasse ConsoleView
    ///  die soll die statische Methoden fuer eingaben und ausgaben richtig als normale Methoden machen
    ///  HolebenutzerEingabe und gibresultat aus. In mein fall auch HoleGueltigeOperation
    ///  und verwenden in Main (durch ein Objekt anlegen) richtig aufrufen
    /// </summary>
    class ConsoleView
    {
        /// Video 82 Korrektur fuer die Klasse ConsoleView: Die Methode als public zu setzen war erstmal richtig.
        /// 
        /// Video 82 Korrektur fuer die Klasse ConsoleView. Verbesserungen, die Resultat direkt aus der Model holen koennen.
        /// Die Klasse ConsoleView muss erst die Klasse RechnerModel kennen.
        /// Ein attribut von model um den Inhalt zugreifen zu koennen.
        private RechnerModel model;
        
        // Un ein Konstruktor mit model als parameter um deren Inhaelte zugreifen zu koennen
        public ConsoleView(RechnerModel model)
        {
            this.model = model;
            //das attribut(this.model) hier wird das parameter(model) uebernehmen
            /// Video 87 While Schleife - wollen wir noch ne Runde?
            BenutzerWillBeenden = false;
        }

        /// Video 87 While Schleife - wollen wir noch ne Runde?
        public bool  BenutzerWillBeenden { get;  private set; }

        /// Video 84 MVC Bonus - Mehr Verantwortung fuer den ConsoleView
        /// hier werden die Eigaben in den neue Properties entsprechend gespeichert
        /// /// Video 87 While Schleife Verbesserungen 
        public void HoleEingabenFuerErsteBerechnungVomBenutzer()
        {
            model.ErsteZahl = HoleZahlvonBenutzer();
            model.Operation = HoleOperatorVonBenutzer();
            model.ZweiteZahl = HoleZahlvonBenutzer();
        }
        /// Video 87 While Schleife Verbesserungen  hier wird das fertig eingabe erkannt zum beenden!
        public void HoleEingabenFuerFortlaufendeBerechnung()
        {
            string eingabe = HoleNaechsteAktionVomBenutzer();

            if (eingabe.ToUpper() == "FERTIG")    //kleine verbesserung um alle gross/klein schreiben zu erkennen (Fertig/fertig/FERTIG/FERtig...)
            {
                BenutzerWillBeenden = true;
            }
            else
            {
                model.ErsteZahl = model.Resultat;
                model.ZweiteZahl = Convert.ToDouble(eingabe);
            }
        }

        private string HoleNaechsteAktionVomBenutzer()
        {
            Console.Write("Bitte gib eine weitere Zahl ein (Fertig zum Beenden): ");
            return Console.ReadLine();
        }

        /// Video 82 Korrektur fuer die Klasse ConsoleView. Die Strings aus Program main muessten raus, dafuer brauchen wir neue Methoden, an unsere Klasse entsprechend angepasst.
        /// Machnmal die Methode die wir so schoen standarisiert hatten, muessen neu angepasst sein auf die neue Klassen
        /// Diese 3 methoden sind die Loesung von Lehrer, meine (vor allem  HoleGueltigeOperation) ist unten noch, unbenutzt/auskommentiert
        //-------------------------------------
        private double HoleZahlvonBenutzer()
        {
            Console.Write("\nBitte geben Sie eine Zahl ein : ");
            ///Wandel Text in Gleitkommazahlen
            ///return VonStringNachDouble(Console.ReadLine());
            /// Video 87 While Schleife - wollen wir noch ne Runde? erste version von wiederholen.
            /// Angepasst um eingabe "FERTIG" zum beenden benutzen zu koennen
            string eingabe = Console.ReadLine();
            if(eingabe == "FERTIG")
            {
                BenutzerWillBeenden = true;
                eingabe = "0,0";//sicherheit, sonst ist die konvertierung danach fehlerhaft
            }
            return VonStringNachDouble(eingabe);
        }
        private string HoleOperatorVonBenutzer()
        {
            //Console.Write("Jetzt die Operation (+, -, ., *, /): "); 
            //return Console.ReadLine();
            /// Video 87 While Schleife Verbesserungen 
            string operationSymbol = "";
            while ((operationSymbol != "+") && (operationSymbol != "-") && (operationSymbol != "*") && (operationSymbol != ".") && (operationSymbol != "/"))
            {
                operationSymbol = HoleBenutzerEingabe("\nJetzt die Operation (+, -, ., *, /): ");
            }
            return operationSymbol;
        }
        /// Video 87 While Schleife Verbesserungen nicht mehr gebraucht
        //public string WarteAufEndeDurchBenutzer()
        //{
        //    Console.Write("\n\nDrücken Sie bitte die ENTER Taste zum beenden");
        //    return Console.ReadLine();
        //}
        //-------------------------------------

        public string HoleBenutzerEingabe(string ausgabeText)
        {
            Console.Write(ausgabeText);
            //string Eingabe = Console.ReadLine();
            string Eingabe = Console.ReadKey().KeyChar.ToString();
            /// Video 87 While Schleife Verbesserungen nur eich char auslesen moeglich? so waere kein enter noetig, wie in ein Taschenrechner

            return Eingabe;
        }

        /// Video 87 While Schleife Verbesserungen - Methode Logik verwendet aber unter andere Name HoleOperatorVonBenutzer (wie von Beispiel)
        /// <summary>
        /// Video 64 verbesserung: Methode fuer die Operation Eingabe auslagern.
        /// Nur gueltige Operetionsymbole werden akzeptiert
        /// <summary>
        /// public string HoleGueltigeOperation(string operationSymbol)
        /// {
        ///    while ((operationSymbol != "+") && (operationSymbol != "-") && (operationSymbol != "*") && (operationSymbol != ".") && (operationSymbol != "/"))
        ///    {
        ///        operationSymbol = HoleBenutzerEingabe("Jetzt die Operation (+, -, ., *, /): ");
        ///    }
        ///    return operationSymbol;
        /// }
        /// <summary>
        /// Video 64 verbesserung: Ausgabe auch in Methode getrennt
        /// Nur gueltige Operetionsymbole werden akzeptiert
        /// <summary>
        /// 
        public void KompletteBerechnungAusgeben()

        /// Video 82 Korrektur fuer die Klasse ConsoleView: der Resultat ist kein Parameter mehr sondern wird aus der model geholt, siehe unten in die Ausgabe
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
                /// zwei cases direkt nacheinander bedeutet sie machen einfach genau das gleiche.
                ///hier erklaert mit * oder . zur multiplikation(sollte auch in Operatoren Eingabe betrachtet sein!)
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
            /// Video 82 Korrektur fuer die Klasse ConsoleView: der Resultat(alt ergebnis) ist kein Parameter mehr sondern wird aus der model geholt!!
        }



        /// Video 83 dieses auch aus Program rauskopiert
        static double VonStringNachDouble(string eingabe)
        {
            return Convert.ToDouble(eingabe);
        }

    }
}
