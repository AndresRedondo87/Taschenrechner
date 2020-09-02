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

        public string HoleBenutzerEingabe(string ausgabeText)
        {
            Console.Write(ausgabeText);
            string Eingabe = Console.ReadLine();

            return Eingabe;
        }

        /// <summary>
        /// Video 64 verbesserung: Methode fuer die Operation Eingabe auslagern.
        /// Nur gueltige Operetionsymbole werden akzeptiert
        /// <summary>
        public string HoleGueltigeOperation(string operationSymbol)
        {
            while ((operationSymbol != "+") && (operationSymbol != "-") && (operationSymbol != "*") && (operationSymbol != ".") && (operationSymbol != "/"))
            {
                operationSymbol = HoleBenutzerEingabe("Jetzt die Operation (+, -, ., *, /): ");
            }
            return operationSymbol;
        }

        /// <summary>
        /// Video 64 verbesserung: Ausgabe auch in Methode getrennt
        /// Nur gueltige Operetionsymbole werden akzeptiert
        /// <summary>
        public void KompletteBerechnungAusgeben(double ersterZahl, double zweiterZahl, double ergebniss, string operation)
        {
            //kompletteAusgabe ist der string um die Ausgabe getrennt zu formatieren
            string kompletteAusgabe = "\nDas {4} Resultat ist: \n   {0} \n {3} {1} \n--------\n   {2}";
            //Operation Name auch anpassen
            string operationAlsText = "";
            switch (operation)
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
            Console.WriteLine(kompletteAusgabe, ersterZahl, zweiterZahl, ergebniss, operation, operationAlsText);
        }
    }
}
