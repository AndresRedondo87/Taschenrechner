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
            ///  Video 81 Mini-UEbung - erstelle die Klasse ConsoleView
            ConsoleView view = new ConsoleView();
            string ersteZahlAlsString = view.HoleBenutzerEingabe("\n\nBitte geben Sie die erste Zahl ein : ");
            string operation = "";
            operation = view.HoleGueltigeOperation(operation);
            string zweiteZahlAlsString = view.HoleBenutzerEingabe("Bitte geben Sie die zweite Zahl ein: ");

            ///Wandel Text in Gleitkommazahlen
            double ersterZahl = VonStringNachDouble(ersteZahlAlsString);
            double zweiterZahl = VonStringNachDouble(zweiteZahlAlsString);

            /// Video 64 verbesserung: teilen durch zero nicht erlaubt. bool variable eigentlich nicht erforderlich.
            bool youShallNotDivideByZero = ((operation == "/") && (zweiterZahl == 0));
            if(youShallNotDivideByZero)
            {
                Console.WriteLine("YOU SHALL NOT DIVIDE BY ZERO");
                Console.WriteLine("ALSO NEVER GOOGLE 'google'");
            }
            else
            {
                //Berechnung Ausfuehren
                RechnerModel model = new RechnerModel();
                //double resultat = model.Berechne(ersterZahl, zweiterZahl, operation);
                model.Berechne(ersterZahl, zweiterZahl, operation);
                /// Video 80-2te Teil- RESULTAT ist jetzt eine Property,so braucht man kein double resultat zu definieren.
                /// In die Ausgabe wird auch model.Resultat anstatt resultat gebraucht


                ///Ausgabe
                ///  Video 81 Mini-UEbung - erstelle die Klasse ConsoleView
                view.KompletteBerechnungAusgeben(ersterZahl, zweiterZahl, model.Resultat, operation);
               
                /**
                // Video 42 Verwende keine Versionbezeichnung im Namen
                // Taschenrechner zu Taschenrechner_AR geaendert alst test nur.
                // Projekt umbenennen, dafuer im Projektmappen-Explorer aendern:
                //      Projektmappe
                //      Projektdatei 
                //      Namespace 
                // Auch wichtig ist in die Eigenschaften die ausfuehrbare Datei Name und Standardnamespace auch zu aendern.
                //      Asemblyname
                //      Standardnamespace
                //(der letzte ist wichtig fuer die weiterentwicklung)
                // dannach immer wieder erstellen und pruefen dass alles ok ist.
                // dann auch die Repos ordner und Projekt Ordner name aendern. DAFUR ABER ERST VisualStudio schliessen.
                // Beim erneut oeffnen wird es Visualstudio nicht finden koennen (nicht verfuegbar, 
                // dann muss man das projekt entfernen und erneut laden aus der richtige Ordner bzw richtige Ordnername und das  schon vorhandene .csproj erneut laden


                // Video 43 AssemblyInfo - Versionsinformationen in den Meta-Daten
                // fuer die Info unter der .exe Datei Eigenschaften auch aendern zu koennen.
                // Wir koenen die Dateibeschreibung unten Eigenschaften/Detail anpassen, vor allem sind wichtig die Dateibeschreibung, Produktname, DateiVersion und Produktversion ...
                // dafuer gehen wir unter Projektname/Properties/AssemblyInfo und aendern die 
                //    AssemblyTitle
                //    AssemblyCompany
                //    AssemblyProduct
                //    AssemblyVersion ist etwas anderes und kann problemme erzeugen:
                //Bei diesem Fehler wird auch darauf hingewiesen, dass man Deterministic ändern soll.
                //Das findest du in deiner *.csproj. einfach in der (windows) Suche nach "*.csproj" suchen und mit z.B. Notepad++ ändern von
                //<Deterministic>true</Deterministic> auf <Deterministic>false</Deterministic> Dann geht es auch mit *
                //[assembly: AssemblyVersion("1.0.*")]
                // diese sternchen macht für jedes Erstellen vom Programm eine neue Versionsnummer hinterlegen sodass es immer nachverfolgbar ist
                // damit kann man eine liste selbst schreiben für welche Version  und Status kriegen.

                //Video 44 unser erstes mini-Release
                // Eine Iteration sicher zu stellen und fuer zukunftige nachverfolgungen sauberer gespeichert zu haben.
                // eine Release zu machen ( .exe und Dokumentation getrennt kriegen.
                // um Tags zu haben.
                // Wir machen eine neue  "Meilesteine" Ordner in unsere Projekt mit Unterordner "Iteration 1" (1 fuer dieses Beispiel)
                // da werde wir packen unsere .exe und ein Release Note .txt
                //  da Beschreiben wir was es hat und kann (formell fuer ofizielle Releases und informell fuer internen) aber sollte schnell gehen
                //  TAG     ART     STATUS      FUNKTION
                // dann der .exe holen UND die .exe.config und .pdb (eingentlich alle die Dateien mit den gleiche Name die wir generiert haben...)
                // Manchmal gibtes auch ein setup oder sowas.
                // beispiel unter Meilesteine/Iteration1
                // dann alles komprimieren in zip und dazu zurueck in unsere .exe suchen (projekt/obj/Debug um die generierte Versionesnummer und Datum aufzuschreiben.
                // in diesem Beispielfall: 18.08.2020 15:49 Produktversion 1.0.7535.284878
                // das aufschreiben in der... Versionsverwaltung auftragen.
                // Milesteine und Release Notes könnte man im VisualStudio konnte man die hinzufügen mit Vorhandenes element (wie mit UserStories)
                **/

            }


            // Programm Beenden
            view.HoleBenutzerEingabe("\n\nDrücken Sie bitte die ENTER Taste zum beenden");
        }


        /// <summary>
        /// Video 64 verbesserung: Methode fuer die Convert.ToDouble auslagern
        /// TODO: vielleicht hier auch falschen Eingaben kontrollieren.
        /// <summary>
        static double VonStringNachDouble(string eingabe)
        {
            return Convert.ToDouble(eingabe);
        }

        /// Video 80 Die Kernlogik des Taschenrechners in einer Klasse- Berechnung Methode und einzelne Berechnungen, sind jetzt in eine Klasse getrennt: RechnerModel

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
