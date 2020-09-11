using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner_AR
{
    /// <summary>
    /// Video 98 Enums -  Enum Definieren:
    /// immer direkt unter namespace, nicht in der Klasse drinnen
    /// immer public, Schluesselwort enum, Name
    /// Die Bezeichnern bekommen ein Wert automatisch zugewiesen, 
    /// kann man aber selber setzen, die folgenden bekommen einfach +1 sequenziell weiter hochgezaehlt
    /// Ein enum ist mit int Werte gebaut
    /// 
    /// Ein Enum wird üblicherweise ausserhalb einer Klasse im Namespace angelegt. 
    /// Dann ist es immer public und der Name der Enum sollte in Pascal-Case-Notation 
    /// (erster Buchstabe und jeder Buchstabe eines Wortes groß) geschrieben sein.
    /// Die einzelnen Bezeichner(porsche und audi) in dieser Enum sind durch Komma getrennt 
    /// und werden automatisch vom Compiler aufsteigend(beginnend bei 0) nummeriert.
    /// </summary>
    public enum Fehler
    {
        Keiner,
        UngueltigeOperation,
        GrenzwertUeberschreitung
    }
    /// <summary>
    /// Taschenrechner: RechnerModel fuer die Berechnung
    /// Video 96, um Tests zu erstellen, die Klasse muss erstmal public sein.
    /// Dann rechte Mausclick auf die Methode die wir testen wollen und "Komponententests erstellen auswaehlen
    /// Da die Optionen einfach wie sie sind lassen und Ok drucken. es erstellt ein Test-Projekt in unsere Projekt.
    /// 
    /// Wichtig ist, dass du nun die Klasse RechnerModel mit dem Zugriffsmodifizierer public versiehst. 
    /// Wenn du das nicht machst, dann können die Unittests diese Klasse nicht sehen und damit auch nicht testen.
    /// </summary>
    public class RechnerModel
    {
        //public double ErsteZahl { get; set; }
        //public double ZweiteZahl { get; set; }
        public double Resultat { get; private set; }

        //public string Operation { get; set; }
        /// Video 98 Enums Wir haben Jetzt der Enum fuer Fehler 
        /// und eine Property AktuellerFehler
        /// Operation wird auch als Property behandelt.
        /// 
        public Fehler AktuellerFehler { get; private set; }

        private double ersteZahl = 0;
        public double ErsteZahl
        {
            get { return ersteZahl; }
            set
            {
                if (ersteZahl != value)
                {
                    AktuellerFehler = GrenzwertCheck(value);
                    ersteZahl = value;
                }
            }
        }

        private double zweiteZahl = 0;
        public double ZweiteZahl
        {
            get { return zweiteZahl; }
            set
            {
                if (zweiteZahl != value)
                {
                    AktuellerFehler = GrenzwertCheck(value);
                    zweiteZahl = value;
                }
            }
        }


        private string operation = "ungueltig";
        public string Operation
        {
            get
            {
                return operation;
            }

            set
            {
                // Wir ändern den Wert der Eigenschaft nur, wenn ein anderer Wert
                // zugewiesen wird
                if (value != operation)
                {
                    switch (value)
                    {
                        case "+":
                        case "-":
                        case "/":
                        case "*":
                        case ".":
                            // Es wurde eine gültige Operation übergeben. Daher können wir
                            // den Fehler zurücksetzen ...
                            if (AktuellerFehler == Fehler.UngueltigeOperation)
                            {
                                AktuellerFehler = Fehler.Keiner;
                            }
                            // ... und den neuen Operator verwenden
                            operation = value;
                            break;

                        default:
                            // Die übergebene Operation wird nicht unterstützt. Daher wird 
                            // angezeigt, dass ein Fehler anliegt und auch die operation zeigt
                            // an, dass etwas nicht stimmt.
                            operation = "ungueltig";
                            AktuellerFehler = Fehler.UngueltigeOperation;
                            break;
                    }
                }
            }
        }

        public static double ObererGrenzwert { get { return 100.0; } }
        public static double UntererGrenzwert { get { return -10.0; } }

        /// Zahlen, Resultat und Operation sind Properties und gehoeren hier
        /// RESULTAT Property setter privat gestzt sodass den Resultat darf nicht extern geaendert werden.
        /// und auch ein neuer konstruktor mit
        public RechnerModel()
        {
            Resultat = 0;
            Operation = "unbekannt"; 
            AktuellerFehler = Fehler.Keiner;
            /// Video 98 Enums Wir haben Jetzt der Enum fuer Fehler 
        }


        /// <summary>
        ///  Video 97 - Wert Eingaben muessen nur zwischen -10 und +100 akzeptiert werden
        /// </summary>
        /// <param name="zahl"></param>
        /// <returns></returns>
        public bool PruefeWertebereichZahl(double zahl)
        {
            return zahl >= -10 & zahl <= 100; ;
        }

        /// <summary>
        /// Kopoert aus gitHub
        /// </summary>
        /// <param name="zahl"></param>
        /// <returns></returns>
        private Fehler GrenzwertCheck(double zahl)
        {
            Fehler resultat = Fehler.Keiner;

            if ((zahl < UntererGrenzwert) || (zahl > ObererGrenzwert))
            {
                resultat = Fehler.GrenzwertUeberschreitung;
            }
            return resultat;
        }


        /// Zugriffsmodifizierer von static zu public da es extern verwendet wird.
        /// Es ist kein Klassenmethode mehr, da es veroeffentlich sein muss.
        /// Die einzelne Berechnungen duerfen private sein, weil sie nicht extern aufgerufen werden, nur "Berechne" (umbennant um besser zu verstehen)
        /// RESULTAT ist eine Property, so jetzt Berechne kann VOID weden und den Ergebniss in den Property RESULTAT speichern!!
        public void Berechne()
        {
            /// Video 98 Enums Wir haben Jetzt der Enum fuer Fehler 
            /// Es gab einen Fehler und somit ist das RechnerModel in einem inkonsistenten
            /// Zustand. Daher kann hier keine Berechnung ausgeführt werden.
            /// 
            /// KOREKTUR: Zustand. Um Probleme bei der Berechnung zu vermeiden, führen wir sie gar nicht
            /// erst aus - defensive Programmierung!
            if (AktuellerFehler != Fehler.Keiner)
            {
                return;
            }


            switch (this.Operation)
            {
                case "+":
                    {
                        Resultat = Addiere(this.ErsteZahl, this.ZweiteZahl);
                        break;
                    }
                case "-":
                    {
                        Resultat = Substrahiere(this.ErsteZahl, this.ZweiteZahl);
                        break;
                    }
                case ".":
                case "*":
                    {
                        Resultat = Multipliziere(this.ErsteZahl, this.ZweiteZahl);
                        break;
                    }
                case "/":
                    {
                        Resultat = Teile(this.ErsteZahl, this.ZweiteZahl);
                        break;
                    }
                case "unbekannt": /// Video 83 sicherheit um unbekannte Operation wen die Eingabe irgendwie scheitert... 
                                  ///gleich wie default eigentlich. Diese Linie ist voellig unnoetig!(nur erklaerend)
                default:
                    {
                        Console.WriteLine("\nERROR, OPERATOR UNGÜLTIG!!");
                        AktuellerFehler = Fehler.UngueltigeOperation;
                        /// Video 98 Enums Wir haben Jetzt der Enum fuer Fehler 
                        break;
                    }
            }
            /// return ergebniss; wegen Resultat nicht mehr gebraucht 
            /// 
        }

        /// Video 98 Enums Wir haben Jetzt der Enum fuer Fehler 
        public void FehlerZurueckSetzen()
        {
            AktuellerFehler = Fehler.Keiner;
        }


        private double Addiere(double ersterSummand, double zweiterSummand)
        {
            double summe = ersterSummand + zweiterSummand;
            return summe;
        }

        private double Substrahiere(double minuend, double substrahent)
        {
            double differenz = minuend - substrahent;
            return differenz;
        }

        private double Multipliziere(double ersterFaktor, double zweiterFaktor)
        {
            double produkt = ersterFaktor * zweiterFaktor;
            return produkt;
        }

        private double Teile(double dividend, double divisor)
        {
            if (divisor != 0)
            {
                double quotient = dividend / divisor;
                return quotient;
            }
            else
            {
                Console.WriteLine("\nERROR, DARF MAN NIE DURCH ZERO TEILEN ERGEBNISS = UNENDLICH NICHT REAL!!");
                // Video 96, angepasst um die Tests zu Pruefen (return geaendert von 0 to Positive oder Negative Infinity)
                if (Math.Sign(dividend) == Math.Sign(divisor))  /// +/+ und -/- positive
                {
                    return Double.PositiveInfinity;
                }
                else                                            /// +/- oder -/+ negative
                {
                    return Double.NegativeInfinity;
                }
            }
        }
    }
}
