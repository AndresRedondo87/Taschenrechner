using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner_AR
{
    /// <summary>
    /// Video 80 Die Kernlogik des Taschenrechners in einer Klasse
    /// </summary>
    class RechnerModel
    {
        public double Resultat { get; private set; }
        public string Operation { get; private set; }
        /// Video 83 neue Operation Property die eigentlich hier gehoert
        /// Video 80-2te Teil- RESULTAT Property und setter privat gestzt sodass den Resultat darf nicht extern geaendert werden.
        /// und auch ein neuer konstruktor mit
        public RechnerModel()
        {
            Resultat = 0;
            Operation = "unbekannt";
            /// Video 83 sicherheit um unbekannte Operation wen die Eingabe irgendwie scheitert... siehe Berechne switch-case
        }

        /// Video 80 Zugriffsmodifizierer von static zu public da es extern verwendet wird.
        /// Es ist kein Klassenmethode mehr, da es veroeffentlich sein muss.
        /// Die einzelne Berechnungen duerfen private sein, weil sie nicht extern aufgerufen werden, nur "Berechne" (umbennant um besser zu verstehen)
        /// Video 80-2te Teil- RESULTAT ist jetzt eine Property, so jetzt Berechne kann VOID weden und den Ergebniss in den Property RESULTAT speichern!!
        public void Berechne(double ersterZahl, double zweiterZahl, string operation)
        {
            /// Video 80-2te Teil-  "double ergebniss = 0;" nicht mehr gebraucht wegen Resultat Property
            /// Video 83 sicherheit  Operation ist jetzt eine Property dieses Klasses
            this.Operation = operation;

            switch (operation)
            {
                case "+":
                    {
                        Resultat = Addiere(ersterZahl, zweiterZahl);
                        break;
                    }
                case "-":
                    {
                        Resultat = Substrahiere(ersterZahl, zweiterZahl);
                        break;
                    }
                case ".":
                case "*":
                    {
                        Resultat = Multipliziere(ersterZahl, zweiterZahl);
                        break;
                    }
                case "/":
                    {
                        Resultat = Teile(ersterZahl, zweiterZahl);
                        break;
                    }
                case "unbekannt": /// Video 83 sicherheit um unbekannte Operation wen die Eingabe irgendwie scheitert... gleich wie default eigentlich. Diese Linie ist voellig unnoetig!(nur erklaerend)
                default:
                    {
                        Console.WriteLine("\nERROR, OPERATOR UNGÜLTIG!!");
                        break;
                    }
            }
            /// return ergebniss; bzw return Resultat
            /// Video 80-2te Teil-  "double ergebniss = 0;" nicht mehr gebraucht wegen Resultat Property
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
                Console.WriteLine("\nERROR, DARF MAN NIE DURCH ZERO TEILEN ERGEBNISS = 0 NICHT REAL!!");
                return 0;
            }
        }
    }
}
