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
            //model.ErsteZahl = HoleZahlvonBenutzer();
            // TODO: Refactoring benötigt - Probleme: unübersichtlich, nicht DRY, nicht SLA!
            // AR ?? REFACTORING??? DRY? SLA?- CHECK TODO
            // Eingabe und Validierung der ersten Zahl
            do
            {
                model.ErsteZahl = HoleZahlVomBenutzer();
                if (model.AktuellerFehler == Fehler.GrenzwertUeberschreitung)
                {
                    Console.WriteLine("\nFEHLER: Zahl muss größer als {0} und kleiner als {1} sein.", RechnerModel.UntererGrenzwert, RechnerModel.ObererGrenzwert);
                }
            }
            while (model.AktuellerFehler == Fehler.GrenzwertUeberschreitung);

            // Eingabe und Validierung des Operators
            model.Operation = HoleOperatorVonBenutzer();
            //model.ZweiteZahl = HoleZahlVomBenutzer();
            // Eingabe und Validierung der zweiten Zahl
            do
            {
                model.ZweiteZahl = HoleZahlVomBenutzer();
                if (model.AktuellerFehler == Fehler.GrenzwertUeberschreitung)
                {
                    Console.WriteLine("\nFEHLER: Zahl muss größer als {0} und kleiner als {1} sein.", RechnerModel.UntererGrenzwert, RechnerModel.ObererGrenzwert);
                }
            }
            while (model.AktuellerFehler == Fehler.GrenzwertUeberschreitung);
        }

        /// Hier wird das fertig eingabe erkannt zum beenden!
        public void HoleEingabenFuerFortlaufendeBerechnung()
        {
            string eingabe = HoleNaechsteAktionVomBenutzer();

            /// Video 92 - Fehler finden, Verwende unzulaessige Werte und Grenzwert
            /// Video 99 -  String.ToUpper - Sichere UEberpruefung durch aendern der GROSS/klein-Geschrieben
            /// (Eigentlich schon implementiert)
            /// Kleine Verbesserung um alle gross/klein schreiben zu erkennen (Fertig/fertig/FERTIG/FERtig...)
            if (eingabe.ToUpper() == "FERTIG")    
            {
                BenutzerWillBeenden = true;
            }
            else
            {
                model.ErsteZahl = model.Resultat;   // hier nehmen wir das alte Resultat als erste Zahl
                model.ZweiteZahl = VonStringNachDouble(eingabe);//und geben die Zweite Zahl ein. 
                /// Video 95 Nochmals Methoden: Rückgabewert als Parameter - Von ToDouble to TryParse. MIT MEINE Methode bzw Umwandlung!
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
        private double HoleZahlVomBenutzer()
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

            //// Video 98 Enums Wir haben Jetzt der Enum fuer Fehler 
            ////string operationSymbol = "";
            ////while ((operationSymbol != "+") && (operationSymbol != "-") && (operationSymbol != "*") && (operationSymbol != ".") && (operationSymbol != "/"))
            ////{
            ////    operationSymbol = HoleBenutzerEingabe("\nJetzt die Operation (+, -, ., *, /): ");
            ////}
            ////return operationSymbol;
            
            string operation;
            do
            {
                //Console.Write("Bitte gib die auszuführende Operation ein (+, -, /, *): ");
                operation =  HoleBenutzerEingabe("\nJetzt die Operation (+, -, ., *, /): ");
                model.Operation = operation;

                if (model.AktuellerFehler == Fehler.UngueltigeOperation)
                {
                    Console.WriteLine("\nFEHLER: Die eingegebene Operation wird nicht unterstützt.");
                }
            }
            while (model.AktuellerFehler == Fehler.UngueltigeOperation);

            return operation;
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
            string operationAlsText;
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

        private double VonStringNachDouble(string eingabe)
        {
            /// return Convert.ToDouble(eingabe);
            /// Video 92 - Fehler finden, Verwende unzulaessige Werte und Grenzwerte
            /// Zahlen: Nichts eingeben, Buchstaben, Punkt wird einfach ignoriert...
            /// Ungueltige Zahlen muessen vermeiden werden.
            /// Video 94 Ausnahmen(exceptions) Wenn Etwas unerwartetes passiert
            /// Ausnahmen kommen wenn etwas unerwartet kommt. 
            /// Kann man nur hier gesehen, sonst wird das Programm abbrechen oder voellig durcheinander kommen.
            /// Werden vermieden bzw gefangen via TRY und CATCH.
            /// Dies ist nur grundinfo. Erstmal nur wissen das Ausnahmen da sind und koennen passieren.

            /// Video 95 Nochmals Methoden: Rückgabewert als Parameter - Von ToDouble to TryParse
            /// TryParse versucht das Umwandeln und gibt zurueck ob es ueberhaupt geht oder nicht.
            /// WIRD ERSTMAL IN HoleZahlVomBenutzer, ich habe es versucht hier anzupassen
            //eingabe = Console.ReadLine(); // hier (in meine Methode) ist schon als Parameter eingegeben worden!
            double zahl;

            /// Video 97 Konditionen erweitert um die Grenzwerte auch zu Beruecksichtigen
            /// Die Pruefung steht aber in RechnerModel, da es dahin gehoert
            while ((!Double.TryParse(eingabe, out zahl)||(!model.PruefeWertebereichZahl(zahl))))
            {
                if (!Double.TryParse(eingabe, out zahl))
                {
                    Console.WriteLine("Du musst eine gültige Gleitkommazahl eingeben!");
                    Console.WriteLine("Neben den Ziffern 0-9 sind lediglich die folgenden Sonderzeichen erlaubt: ,.-");
                    Console.WriteLine("Dabei muss das - als erstes Zeichen vor einer Ziffer gesetzt werden.");
                    Console.WriteLine("Der . fungiert als Trennzeichen an Tausenderstellen.");
                    Console.WriteLine("Das , ist das Trennzeichen für die Nachkommastellen.");
                    Console.WriteLine("Alle drei Sonderzeichen sind optional!");
                }
                else if (!model.PruefeWertebereichZahl(zahl))
                {
                    Console.WriteLine("Du musst ein gültiger WERT eingeben!");
                    Console.WriteLine("Wir akzeptieren nur Werte zwischen -10 und +100");
                }

                Console.WriteLine();
                Console.Write("Bitte gib erneut eine Zahl für die Berechnung ein: ");
                eingabe = Console.ReadLine();
            }
            return zahl;

            /// VIDEO 95 -TRYPARSE INFO 
            /// Die Methode TryParse gibt einen Wert vom Typ bool zurück. Mit diesem Wert zeigt sie an, 
            /// ob die übergebene Zeichenkette erfolgreich in eine Zahl konvertiert werden konnte.
            /// Ich habe den Aufruf hier in eine while Schleife gepackt, damit der Benutzer solange aufgefordert wird eine Eingabe zu machen, 
            /// bis sie konvertiert werden kann.
            /// Wichtig ist hier, dass "nur" geprüft wird ob es sich um eine gültige Zahl handelt. 
            /// Wie du in einer kommenden Lektion sehen wirst, kann es trotzdem sein, 
            /// dass die Zahl nicht den definierten Grenzwerten entspricht und somit zwar eine erfolgreich konvertiert werden konnte, 
            /// jedoch nicht zulässig für die Anwendung ist.
        }
    }
}
