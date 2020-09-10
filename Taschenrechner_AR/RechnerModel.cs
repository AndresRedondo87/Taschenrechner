using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner_AR
{
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
        public double ErsteZahl { get; set; }
        public double ZweiteZahl { get; set; }
        public double Resultat { get; private set; }
        public string Operation { get; set; }

        /// Zahlen, Resultat und Operation sind Properties und gehoeren hier
        /// RESULTAT Property setter privat gestzt sodass den Resultat darf nicht extern geaendert werden.
        /// und auch ein neuer konstruktor mit
        public RechnerModel()
        {
            Resultat = 0;
            Operation = "unbekannt";
            /// Um unbekannte Operation wen die Eingabe irgendwie scheitert... siehe Berechne switch-case
        }

        /// Zugriffsmodifizierer von static zu public da es extern verwendet wird.
        /// Es ist kein Klassenmethode mehr, da es veroeffentlich sein muss.
        /// Die einzelne Berechnungen duerfen private sein, weil sie nicht extern aufgerufen werden, nur "Berechne" (umbennant um besser zu verstehen)
        /// RESULTAT ist eine Property, so jetzt Berechne kann VOID weden und den Ergebniss in den Property RESULTAT speichern!!
        public void Berechne()
        {
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
                        break;
                    }
            }
            /// return ergebniss; wegen Resultat nicht mehr gebraucht 
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
