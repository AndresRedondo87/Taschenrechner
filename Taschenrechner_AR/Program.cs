//using System;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Taschenrechner_AR
{
    /// <summary>
    /// Taschenrechner: zwei Zahlen eingeben, um deren Summe/Differenz/Multiplikation/Division berechnen zu lassen
    /// </summary>
    class Program
    {
        static void Main()
        {
            RechnerModel model = new RechnerModel();
            ConsoleView view = new ConsoleView(model); //diese Konstruktor wird auch initialisiert deswegen brauchen wir den model rein.
            AnwendungsController controller = new AnwendungsController(view, model);//diese braucht die anderen 2 Objekte zum Initialisierung

            controller.Ausfuehren();
        }


        /// Video 88 Refactoring:  ein Kernaktivitaet bei der Implementierung
        /// taktik anwenden/suchen um die Probleme aufzuloesen.
        /// Das haben wir in die letzte Iteration (und auch etwas in die vorigen) wo wir den code aendern um 
        /// die Fehler zu korrigieren oder funktionen implementieren oder die evolvierbarkeit zu verbessern:
        /// Methode und Properties aneders zu definieren/lagern/ methode anders zu behandeln...
        
        /// <summary>
        /// Methoden Definieren in 7 Schritten
        /// -(Optional)Modifizierer definieren (Zugriffsmodifizierer)
        /// -Datentyp des Rueckgabewertes definieren
        /// -Methodennamen definieren
        /// -Rundeklammern an den Methodennamen anfügen
        /// -Ueberlegen welche Parameter benoetigt werden (Optional diese zu definieren)
        /// -Geschweifte Klammern einfuegen
        /// -Methode implementieren (Anweisungen in den Methodenrumpf schreiben)
        /// </summary>


        //BEISPIEL TEXT BZW HAUPT INFOS
        /*namespace Methoden
        {
            /// <summary>
            /// Zeigt dir die wichtigsten Grundlagen (insbesondere Begriffe) rund um das
            /// Thema Methoden. Außerdem werden von hier alle Beispiele zum Thema Methoden
            /// aufgerufen.
            /// </summary>
            class Einfuehrung
            {
                // Bei der Definition einer Methode (auch Methodendefinition genannt) geht es darum,
                // das du den Quellcode schreibst der sagt was zutun ist, wenn diese Methode ausgeführt
                // wird. Im folgenden ein kurzer Überblick über die Bestandteile einer Methode:

                // ZUGRIFFSMODIFIZIERER (access modifier): Definiert von wo die Methode erreichbar ist.
                // Häufig verwendet sind private - Methode kann nur innerhalb der Klasse verwendet werden
                // und public - Methode kann von jeglicher Klasse verwendet werden.
                // Mögliche Werte sind: public, private, protected und internal für Details siehe MSDN
                // https://msdn.microsoft.com/de-de/library/ms173121.aspx

                // PARAMETER: Jeder Methode kann optional ein oder mehrere Parameter übergeben werden.
                // Jeder Parameter besteht aus einem Datentypen und einem Namen. Wenn eine Methode mehrere
                // Parameter hat, dann werden diese mit Komma getrennt.

                // Optional können zwischen Zugrifssmodifizierer und Datentyp des Rückgabewerts noch die
                // Schlüsselwörter STATIC und ASYNC verwendet werden. Dies wird in separaten Projekten
                // besprochen (z.B. SchlüsselwortStatic)

                // Aufbau:
                // Zugriffsmodifizierer (engl.: access modifier or method visibility)
                //  |
                //  |   Datentyp des Rückgabewerts (engl.: datatype of return value)
                //  |    |
                //  |    |               Methodenname in CamelCase-Notation
                //  |    |                   |
                //  |    |                   |                            Datentyp vom ersten Parameter
                //  |    |                   |                             |
                //  |    |                   |                             |      Name des ersten Parameters
                //  |    |                   |                             |        |
                public void MethodeOhneRueckgabewertAberMitEinemParameter(int parameterName) // <- Methodenkopf
                {
                    // Dies ist der Methodenrumpf. Er beginnt mit einer geöffneten geschweiften Klammer
                    // und muss mit einer geschlossenen geschweiften Klammer beendet werden.
                    throw new NotImplementedException("Methode ist nur als Beispiel gedacht!");

                    // Nur wenn die Methode keinen Wert zurück gibt (also der Datentyp des Rückgabewertes
                    // void ist), kann auf das "return" am Ende der Methode verzichtet werden.
                }
        */
    }
}
