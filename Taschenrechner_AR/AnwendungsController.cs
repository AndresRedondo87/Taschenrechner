using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner_AR
{
    class AnwendungsController
    {
        /// Video 83 Klebstoff zwischen die anderen Klassen ---> AnwendungsController
        /// 
        private ConsoleView view;
        private RechnerModel model;
        //wir zugreifen an die anderen klassen und beim ein Objekt erstellen werden die beide auch gebrauckt im Konstruktor
        public AnwendungsController(ConsoleView view, RechnerModel model)
        {
            this.view = view;
            this.model = model;
            //das attribut(this.model) hier wird das parameter(model) uebernehmen
        }

        public void Ausfuehren()
        {
            /// Video 87 While Schleife - wollen wir noch ne Runde?
            /// Das ganze Hauptteil des Ausfuhrens in ein WHILE kapseln:
            /// 
            while (!view.BenutzerWillBeenden)
            {
                /// Video 83 alles aus der main rauskopiert erstmal.
                /// Video 82 Korrektur fuer die Klasse ConsoleView. Die Strings aus Program main muessten raus,
                ///string ersteZahlAlsString = view.HoleBenutzerEingabe("\n\nBitte geben Sie die erste Zahl ein : ");
                ///string operation = "";
                ///operation = view.HoleGueltigeOperation(operation);
                ///string zweiteZahlAlsString = view.HoleBenutzerEingabe("Bitte geben Sie die zweite Zahl ein: ");
                ///double ersteZahl = view.HoleZahlvonBenutzer();
                ///string operation = view.HoleOperatorVonBenutzer();
                ///double  zweiteZahl = view.HoleZahlvonBenutzer();
                /// Video 83 ZahlEingaben schon direkt konvertiert

                /// Video 84 MVC Bonus - Mehr Verantwortung fuer den ConsoleView
                view.HoleEigabenVomBenutzer();


                /// Video 64 verbesserung: teilen durch zero nicht erlaubt. bool variable eigentlich nicht erforderlich.
                bool youShallNotDivideByZero = ((model.Operation == "/") && (model.ZweiteZahl == 0));
                if (youShallNotDivideByZero)
                {
                    Console.WriteLine("YOU SHALL NOT DIVIDE BY ZERO");
                    Console.WriteLine("ALSO NEVER GOOGLE 'google'");
                }
                else
                {
                    ///Berechnung Ausfuehren
                    /// Video 82 Korrektur fuer die Klasse ConsoleView. diese model wird fuer den view gebraucht, so wir verlagern es zu ganz am Anfang
                    ///RechnerModel model = new RechnerModel();
                    ///double resultat = model.Berechne(ersterZahl, zweiterZahl, operation);
                    ///model.Berechne(ersteZahl, zweiteZahl, operation);
                    /// Video 80-2te Teil- RESULTAT ist jetzt eine Property,so braucht man kein double resultat zu definieren.
                    /// In die Ausgabe wird auch model.Resultat anstatt resultat gebraucht
                    model.Berechne();


                    ///Ausgabe
                    ///  Video 81 Mini-UEbung - erstelle die Klasse ConsoleView
                    /// Video 82 Korrektur fuer die Klasse ConsoleView. die view.xyz hat gut funktioniert.
                    ///view.KompletteBerechnungAusgeben(ersterZahl, zweiterZahl, model.Resultat, operation);
                    ///view.KompletteBerechnungAusgeben(ersteZahl, zweiteZahl, operation);
                    /// Video 82 Korrektur fuer die Klasse ConsoleView. Resultat ist kein Parameter mehr, sondern wird aus model geholt.
                    view.KompletteBerechnungAusgeben();
                    ///Video 83 DRITTE COMMIT: Operation gehoert in RechnerModel
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
            }

            // Programm Beenden
            //view.HoleBenutzerEingabe("\n\nDrücken Sie bitte die ENTER Taste zum beenden");
            view.WarteAufEndeDurchBenutzer();

        }
    }
}
