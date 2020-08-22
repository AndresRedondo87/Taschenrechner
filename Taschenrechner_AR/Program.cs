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
    /// Taschenrechner: zwei Zahlen eingeben, um deren Summe/Differenz/... berechnen zu lassen
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            /**
            //Kommentary infos: dreimal slash und  summary in xml, wird als info für später verwenden
            // es wird für das nachfolgende Konstrukt unten Dokumentation verwendet. 

            //Kommentare sind generell super hilfreich für die weiterentwicklung. 
            //Kann man sogar web adressen hinzugefügt werden.

            //------------------------------------------------------------------
            //USER STORIES Taschenrechner Anforderungen
            //------------------------------------------ -
            //Erste Beispiel(2x Stories) -Iteration #1:	
            //Titel: Addieren
            //Story:Als Benutzer möchte ich zwei Zahlen eingeben, um deren Summe berechnen zu lassen
            //Akzeptanzkriterien:
            //			-Zahlen zwischen 0 und 10 können addiert werden.
            //			-[erweiterung als Beispiel: Zahlen in HEX eingeben können]

            //Titel: Starten
            //Story: Als Benutzer möchte ich den Taschenrechner schnell aufrufen können, um mein Resultat schnell zu bekommen
            //Akzeptanzkriterien:
            //			-Die Anwendung wird innerhalb von 2 Sekunden auf einem Rechner gestartet
            //			- Die Anwendung läuft auf einem Rechner mit Windows 10
            //------------------------------------------------------------------

            //CONSOLE VERWENDEN: ERST HINWEISE AUSGEBEN UND DANN KAN DER BENUTZER EINGEBEN
            //                      ERST DIE AUSGABEN, DANN DIE EINGABE
            **/

            //User Story "Addieren":
            /// Video 53 Verwenden bzw. verwenden einer Methode
            string ersterSummand = HoleSumanden("Bitte geben Sie den ersten Summanden ein:");
            string zweiterSummand = HoleSumanden("Bitte geben Sie den zweiter Summanden ein:");



            /**
            //hier das gleiche mit andere Variablenname



            //Video 29 Datentypen: Text ist nicht gleich Zahl
            //string ersterText = "Zehn";
            //string zweiterText = "10";
            //string summe1 = ersterText + zweiterText;
            //string summe2 = ersterText +  " + " + zweiterText;   //so sehen wir das verketten besser

            //Console.WriteLine("\n\n");
            //Console.WriteLine("'String-Summe': {0}",summe1);
            //Console.WriteLine("'String-Summe': {0}", summe2);
            //Console.WriteLine("'String-Summe' macht Zeichenketten verketten, bzw. zusammenführen");


            //int ersteZahl = 10;
            //int zweiteZahl = 10;
            //int summeInt = ersteZahl + zweiteZahl;
            //Console.WriteLine("\n'Int-Summe': {0}", summeInt);


            //Video 30 C# Bibliothek: Convert, Text in Ganzzahl konvertieren
            //Wandel Text in Ganzzahlen
            //int ersterSummand //das geht nicht da diese Variablenname ist schon vorhanden.
            //int ersterSummandAlsZahl = Convert.ToInt32(ersterSummand);
            //int zweiterSummandAlsZahl = Convert.ToInt32(zweiterSummand);
            //Nachtraeglich geaendert fuer Video 36 - Jetzt bist du dran, addieren mit Gleitkommazahlen

            // Beim suchen welche convert typ wir brauchen, sehen wir es bei der Rückgabewert von jede Methode in seine Beschreibungen:
            //      short Convert.ToInt16
            //      int Convert.ToInt32
            //      long Convert.ToInt64
            // in diesem Fall passt mit ToInt32. die verschiedene Werte haben mit der Auflösung (und Wertebereich) zu tun.


            //Video 31 Die User Story fertig stelle und testen
            //// schon in vorige commit erledigt, hier verbessert

            //int summeAlsZahl = ersterSummandAlsZahl + zweiterSummandAlsZahl;
            //Console.WriteLine("\nDie Summe ist: \n   {0} \n + {1} \n-----\n   {2}", ersterSummandAlsZahl, zweiterSummandAlsZahl, summeAlsZahl);
            //Nachtraeglich geaendert fuer Video 36 - Jetzt bist du dran, addieren mit Gleitkommazahlen

            // Zum Tests Bestätigen,auch die Ausgabe Fenster sehen, wenn wir es sauber schon geschlossen haben, kommt diese meldung:
            //Das Programm "[24464] Taschenrechner.exe" wurde mit Code 0 (0x0) beendet.

            //Wir bestätigen dass die Anforderungen bzw. Akzeptanzkriterien aus den Stories  richtig implementiert worden sind:
            // in diesem Fall wäre es die zahlen von 0 bis 10 zu summieren....

            //Wenn wir zum Beispiel eine Buchstabe eingeben kommt sowas in die Ausgabefenster:
            //Ausnahme ausgelöst: "System.FormatException" in mscorlib.dll
            //Ein Ausnahmefehler des Typs "System.FormatException" ist in mscorlib.dll aufgetreten.
            //Die Eingabezeichenfolge hat das falsche Format.

            //Video 32 Versionskontrolle (Git) - Das Sicherheitsnetz für deinen Taschenrechner
            // das habe ich schon eigentlich selber erledigt!!!
            // Um die Video-Beschreibung zu folgen habe ich ein anderes Projekt verwendet, der Klassendefinieren. So geht es auch.

            // Video 33  wenn du nicht weiterkommst - Beispielquellcode in Visual Studio importieren
            // wir verwenden Git + Visual Studio
            // jeztz haben wir den in halt von https://github.com/LernMoment/einstieg-csharp-taschenrechner.git
            // auch lokal unter C:\Users\Andres Redondo\source\repos\einstieg-csharp-taschenrechner
            // aber nur als referenz Projekt! nicht immer alles abkopieren, so lernt man nicht.



            // Video35  Datentypen float, double und decimal
            //float pi = 3.14;    // aufpassen, englischer schreibweise, Punkt anstatt komma muss verwendet werden.
            // in C# werden zahlen defaultweise als double annerkannt, sie sind aber groesser als float, deswegen koennen wir probleme haben.
            float pi = 3.14F;   //mit den F flaggen wir diese double als float fest.
            Console.WriteLine("unser Pi hat den wert {0}", pi);
            float pi2 = 0.0314e2F;  // 0,0312 * 10 hoch 2
            Console.WriteLine("unser Pi2 hat den wert {0}", pi2);



            // Video 36 - Jetzt bist du dran, addieren mit Gleitkommazahlen
            //float ersterSummandAlsZahl = Convert.ToInt64(ersterSummand);
            //float zweiterSummandAlsZahl = Convert.ToInt64(zweiterSummand); das hat irgendwie gar nicht funktioniert, exceptions mit . und , genauso

            //Mein Versuch: wird nur PUNKT als Komma annerkannt, float anstatt double als er richtig gemacht hat
            //float ersterSummandAlsZahl = float.Parse(ersterSummand, CultureInfo.InvariantCulture.NumberFormat);
            //float zweiterSummandAlsZahl = float.Parse(zweiterSummand, CultureInfo.InvariantCulture.NumberFormat);
            //float summeAlsZahl = ersterSummandAlsZahl + zweiterSummandAlsZahl;
            //Console.WriteLine("\nDie Summe ist: \n   {0} \n + {1} \n-----\n   {2}", ersterSummandAlsZahl, zweiterSummandAlsZahl, summeAlsZahl);

            ////dies hier nimmt kein
            //float ersterSummandAlsZahl = Convert.ToSingle(ersterSummand);
            //float zweiterSummandAlsZahl = Convert.ToSingle(zweiterSummand); 


            //Korrigiert nach Lehrer Version: double verwenden:
            // wird nur komma als komma annerkannt, englische VS deutsche Einstellungen fuer zahlen sind.
            **/
            //Wandel Text in Gleitkommazahlen
            double ersterSummandAlsZahl = Convert.ToDouble(ersterSummand);
            double zweiterSummandAlsZahl = Convert.ToDouble(zweiterSummand);

            //Berechnung Ausfuehren
            double summeAlsZahl = Addiere(ersterSummandAlsZahl, zweiterSummandAlsZahl);

            //Ausgabe
            Console.WriteLine("\nDie Summe ist: \n   {0} \n + {1} \n-----\n   {2}", ersterSummandAlsZahl, zweiterSummandAlsZahl, summeAlsZahl);
            /**
            //Video 39 Aeltere version wiederherstellen - Fehler Korrigieren ganz einfach.(die Korrektur als double gehoert eigentlich hier.
            //Double sind schon verwendet... und bestätigt. wir wollen aber wieder float verwenden!! wiederherstellen via git moeglich.
            // Rechte maus auf die datei (diesmal Program.cs), dann Git(oder vielleicht die Optionen sind direkt angezeigt), dann 
            // "mit ungeaenderten vergleichen...
            // das zeigt uns die änderungen die wir noch nicht commited haben, rot heisst geloescht, gruen hinzugefuegt. 
            // Leichte farben fuer die ganze Linien und starke fuer den Text ganz genau.

            // Um Aenderungen zurueck zu nehmen, kann mann die so erledigen:
            // Rechte maus auf die datei (diesmal Program.cs), dann Git(oder vielleicht die Optionen sind direkt angezeigt), dann Undo Changes.
            // Damit muss mann sehr VORSICHTIG sein, da diese Aenderungen werden komplett geloescht und nicht mehr nachzuholen.


            // Video 40 Die Versionhistorie mit Visualstudio und Git
            // Rechte maus auf die datei (diesmal Program.cs), dann Git(oder vielleicht die Optionen sind direkt angezeigt), dann View History (oder Verlauf anzeigen)
            // damit sieht man wer und wann die dateien geaendert worden sind, da kann man auch die vergleiche aufrufen.
            // kann man auch zwei versionen darunter auswaehlen und vergleichen.
            // Sehr grafisch wird es beim Team Explorer, anstatt die Aenderungen Menu, der Branches (bzw (Verzweigungen) auszuwaehlen
            // dann rechte maus auf die Master zum beispiel,dann View History und es zeigt uns die ganze Branches und die entsprechenden Kommentare.
            // da kann man auch CommitDetails anzeigen auswaehlen und es zeigt in der Team Explorer alle die Dateien die geaendert worden sind.


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
            WarteAufBenutzerEingabe();
        }

        /// <summary>
        /// Aussagekraeftigen Methoden Abstrahieren
        /// Ab Video 49 Einfuehrung in Methoden - wir haben schon welchen erstellt und verwendet
        /// Damit sollte alles lesbarer.
        /// Methoden sind container für Quellcode um Befehle logischer zu trennen.
        /// Kernidee ist die unnoetige Sachen/Befehle aus der Hauptmethode zu trennen und damit Struktirieren und abstrahieren.
        /// </summary>
        static void WarteAufBenutzerEingabe()
        {
            Console.WriteLine("\n\nDrücken Sie bitte die ENTER Taste zum beenden");
            Console.ReadLine();
        }

        /// <summary>
        /// Video 50 Single Level of Abstraction - eine Separate Methode Aufrufen
        /// Addieren Methode abstrahieren. Aufpassesn auf Variablennamen, VariablenTypen...
        /// </summary>
        static double Addiere(double ersterSummand, double zweiterSummand)
        {
            double summe = ersterSummand + zweiterSummand;
            return summe;
        }

        //Video 51 - Versionsverwaltung nicht vergesen, Immer commit und push!!


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

        /// Video 52 Erstellen einer Methode - Wir verlangen die Eingabe (erster summand)
        /// Merken return ist immer das letzte in einer Methode. Was danach kommt, wird nie ausgefuehrt.
        /// Methoden können oft verbessert werden: von HoleErstenSumanden erst kann man den ausgabeText als Parameter eingeben, so ist es viel flexibler.
        /// Dann kann es auch zu HoleSumanden werden um nich nur fuers erste sondern fuer viele summanden.

        static string HoleSumanden(string ausgabeText)
        {
            Console.Write(ausgabeText);
            string Summand = Console.ReadLine();

            return Summand;
        }


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
