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
        /// Video 80 Zugriffsmodifizierer von static zu public da es extern verwendet wird.
        /// Es ist kein Klassenmethode mehr, da es veroeffentlich sein muss.
        /// Die einzelne Berechnungen duerfen private sein, weil sie nicht extern aufgerufen werden, nur "Berechne" (umbennant um besser zu verstehen)
        public double Berechne(double ersterZahl, double zweiterZahl, string operation)
        {
            double ergebniss = 0;
            switch (operation)
            {
                case "+":
                    {
                        ergebniss = Addiere(ersterZahl, zweiterZahl);
                        break;
                    }
                case "-":
                    {
                        ergebniss = Substrahiere(ersterZahl, zweiterZahl);
                        break;
                    }
                case ".":
                case "*":
                    {
                        ergebniss = Multipliziere(ersterZahl, zweiterZahl);
                        break;
                    }
                case "/":
                    {
                        ergebniss = Teile(ersterZahl, zweiterZahl);
                        break;
                    }

                default:
                    {
                        Console.WriteLine("\nERROR, OPERATOR UNGÜLTIG!!");
                        break;
                    }
            }
            return ergebniss;
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
