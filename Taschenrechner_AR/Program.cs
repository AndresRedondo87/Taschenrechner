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
            /**
            //Kommentary infos: dreimal slash und  summary in xml, wird als info für später verwenden
            // es wird für das nachfolgende Konstrukt unten Dokumentation verwendet. 
            //Kommentare sind generell super hilfreich für die weiterentwicklung. 
            //Kann man sogar web adressen hinzugefügt werden.
            //CONSOLE VERWENDEN: ERST HINWEISE AUSGEBEN UND DANN KAN DER BENUTZER EINGEBEN
            //                   ERST DIE AUSGABEN, DANN DIE EINGABE
            **/

            ///User Story "Addieren":
            /// Video 53 Verwenden bzw. verwenden einer Methode
            string ersteZahlAlsString = HoleBenutzerEingabe("\n\nBitte geben Sie die erste Zahl ein : ");


            /** Video 57  Benutzerinteraktion - eine Methode fuer alles
             *  jetzt wollen wir die HoleSumanden Methode Aendern sodass es auch fuer andere Kalkulationen gilt.
             *  Dafuer rechrtemaus auf Methode und Umbenennen auswählen, dann sollte es automatisch rechts eine Dialog mit Optionen und zeigt ein Zaehler mit
             *  wieviele Verweise werden damit automatisch auch geaendert, in diesem Fall 3.
             *  Danach immer wieder Pruefen und bestaetigen und das altere Name dursuchen lassen.
             *  Das gleiche machen wir mit den Variablen ersterSummand und zweiterSummand. (beide nur zweimal benutzt)
             *  Und auch fuer ersterSummandAlsZahl und zweiterSummandAlsZahl
             */
            /** Video 54 Methoden ausfuehren lerne den Debugger kennen
            // BREAKPOINT Bzw. Haltepunkte verwenden, Fenster Auto und Lokal fuer Variablen und ihre Werte... 
            // Lokal variablen werden in rot markiert wenn sie gerade geandert worden sind. Hilfreich zum Fehlersuche, auch in return.
            // Einzelschritt unter Debuggen / F11 druecken / Button in toolbars oben um ein Schritt bzw. Anweisung nach vorne gehen, dann stoppt es wieder.
            // In Aufrufliste koennen wir sehen, der Breakpoint zeigt wo es ist, gelbe Pfeil zeigt wo der Schritt gerade ist, z.B. HoleSummanden in diesem Fall
            // Prozedurschritte unter Debuggen / F10 druecken / Button in toolbars oben um ein ProzedurSchritt bzw. Anweisungengruppe nach vorne gehen wird hier nicht erklärt.
            */
            /** Video 58 Mini.Uebung - Verwende eine Methode um den Operator einzulesen
             *  string operator = HoleBenutzerEingabe("\n\nBitte geben Sie die gewünschte Operation an (+, -, /, *): "); OPERATOR ist SCHLUSSELWORT, nicht verwendbar hier.
             EXTRA while loop bis gueltige Operator eingegeben wird*/
            string operation = "";
            operation = HoleGueltigeOperation(operation);


            /// Video 64 verbesserung: Erst ein Zahl Eingabe, dann Operation und dann Zweiter Zahl, ich finde es so logischer.
            string zweiteZahlAlsString = HoleBenutzerEingabe("Bitte geben Sie die zweite Zahl ein: ");

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
            ///Wandel Text in Gleitkommazahlen
            /// Video 55 Zwischenschritt -Softwarestruktur User Story abschliessen
            /// TODO: Auslagern in Methode, wenn Struktur umfangreicher geworden ist.
            /// Diese "// TODO:" sind immer in die aufgabenliste zu sehen: in Ansicht/Aufgabenliste. nur so, der "TODO:" direkt am Anfang 
            double ersterZahl = VonStringNachDouble(ersteZahlAlsString);
            double zweiterZahl = VonStringNachDouble(zweiteZahlAlsString);
            /** Video 57  Benutzerinteraktion - eine Methode fuer alles. Variablen Umbenennen
             *  Dafuer rechrtemaus auf Methode und Umbenennen auswählen, dann sollte es automatisch rechts eine Dialog mit Optionen und zeigt ein Zaehler mit
             *  wieviele Verweise werden damit automatisch auch geaendert, in diesem Fall 3.  auch fuer ersterSummandAlsZahl und zweiterSummandAlsZahl */


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
                double ergebniss = BerechnungAusfuehren(ersterZahl, zweiterZahl, operation);
                ///double summeAlsZahl = Addiere(ersterZahl, zweiterZahl);
                ///double differenzAlsZahl = Substrahiere(ersterZahl, zweiterZahl);
                /// Video 56 Mini-Uebung - erstelle eine Methode die Zwei Zahlen Substrahiert
                /// Video 64 Zusatzaufgabe - Aufraeumen in Main - Berechnungbekommt eine eigene Methode.
                /// Eigentlich hatte es schon lange separiert.
                /// die Berechnung und die Ausgabe zu trennen habe ich auch schon getrennt.


                /// Video 64 verbesserung: Ausgabe auch in Methode getrennt
                ///Ausgabe
                ///Console.WriteLine("\nDie Summe ist: \n   {0} \n + {1} \n-----\n   {2}", ersterZahl, zweiterZahl, ergebniss);
                ///Console.WriteLine("\n\nDie Differenz ist: \n   {0} \n - {1} \n-----\n   {2}", ersterZahl, zweiterZahl, ergebniss);
                /// Video 56 Mini-Uebung - erstelle eine Methode die Zwei Zahlen Substrahiert
                /** Video 58-59 Mini.Uebung - Verwende eine Methode um den Operator einzulesen
                 * Ergebniss Darstellen muss auch geändert werden*/
                //Console.WriteLine("\nDas Resultat ist: \n   {0} \n {3} {1} \n-----\n   {2}", ersterZahl, zweiterZahl, ergebniss, operation);
                KompletteBerechnungAusgeben(ersterZahl, zweiterZahl, ergebniss, operation);
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

            }


            /// Video 60 Vergleichoperatoren und der Datentyp bool (boolean)
            /// Addendum um bools zu testen (gleiche und nicht gleiche Zahlen (==, !=)
            /// es gibt auch <,<=,>,>=... kenne ich schon
            ///bool sindGleich = true;
            ///sindGleich = IstGleich(ersterZahl, zweiterZahl);
            ///Console.WriteLine("die Zahlen  {0}  und  {1} sind gleich?:  {2} ", ersterZahl, zweiterZahl, sindGleich);
            ///if (sindGleich)
            ///{
            ///    Console.WriteLine("die Zahlen sind gleich!!");
            ///}
            ///else if (!sindGleich)   //eingentlic unnoetig aber gut
            ///{
            ///    Console.WriteLine("die Zahlen sind NICHT gleich!!");
            ///}


            HoleBenutzerEingabe("\n\nDrücken Sie bitte die ENTER Taste zum beenden");
        }


        /// <summary>
        /// Video 64 verbesserung: Ausgabe auch in Methode getrennt
        /// Nur gueltige Operetionsymbole werden akzeptiert
        /// <summary>
        static void KompletteBerechnungAusgeben(double ersterZahl, double zweiterZahl, double ergebniss, string operation)
        {
            //kompletteAusgabe ist der string um die Ausgabe getrennt zu formatieren
            string kompletteAusgabe = "\nDas {4} Resultat ist: \n   {0} \n {3} {1} \n--------\n   {2}";           
            //Operation Name auch anpassen
            string operationAlsText="";
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
                        operationAlsText= ("\nERROR, OPERATION UNGÜLTIG!!\n");
                        break;
                    }
            }
            Console.WriteLine(kompletteAusgabe, ersterZahl, zweiterZahl, ergebniss, operation, operationAlsText);
        }


        /// <summary>
        /// Video 64 verbesserung: Methode fuer die Operation Eingabe auslagern.
        /// Nur gueltige Operetionsymbole werden akzeptiert
        /// <summary>
        static string HoleGueltigeOperation(string operationSymbol)
        {
            while ((operationSymbol != "+") && (operationSymbol != "-") && (operationSymbol != "*") && (operationSymbol != ".") && (operationSymbol != "/"))
            {
                operationSymbol = HoleBenutzerEingabe("Jetzt die Operation (+, -, ., *, /): ");
            }
            return operationSymbol;
        }
        /// <summary>
        /// Video 64 verbesserung: Methode fuer die Convert.ToDouble auslagern
        /// TODO: vielleicht hier auch falschen Eingaben kontrollieren.
        /// <summary>
        static double VonStringNachDouble(string eingabe)
        {
            return Convert.ToDouble(eingabe);
        }

        /// Video 60 Vergleichoperatoren und der Datentyp bool (boolean)
        ///static bool IstGleich(double a, double b)
        ///{
        ///    return a == b;
        ///}

        /// <summary>
        /// Video 58 Mini.Uebung - Verwende eine Methode um den Operator einzulesen
        /// Video 59 If-Anweisung, der Taschenrechner lernt minus
        ///  sogar mehr erweiters als von der Uebung erwartet war.
        /// <summary>
        static double BerechnungAusfuehren(double ersterZahl, double zweiterZahl, string operation)
        {
            double ergebniss=0;
            /// Video 61 - Switch-Case-Anweisung - Eine alternative zu if.else-Anweisung
            ///case "wert":....
            ///und am Ende immer ein "break".
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
                /// zwei cases direkt nacheinander bedeutet sie machen einfach genau das gleiche.
                ///hier erklaert mit * oder . zur multiplikation(sollte auch in Operatoren Eingabe betrachtet sein!)
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

        /**Video 57  Benutzerinteraktion - eine Methode fuer alles: WarteAufBenutzerEingabe Methode redundant mit HoleBenutzerEingabe,, daher kann es geloescht bzw rauskommentiert werden
        ///// <summary>
        ///// Aussagekraeftigen Methoden Abstrahieren
        ///// Ab Video 49 Einfuehrung in Methoden - wir haben schon welchen erstellt und verwendet
        ///// Damit sollte alles lesbarer.
        ///// Methoden sind container für Quellcode um Befehle logischer zu trennen.
        ///// Kernidee ist die unnoetige Sachen/Befehle aus der Hauptmethode zu trennen und damit Struktirieren und abstrahieren.
        ///// </summary>
        //static void WarteAufBenutzerEingabe()
        //{
        //    Console.WriteLine("\n\nDrücken Sie bitte die ENTER Taste zum beenden");
        //    Console.ReadLine();
        //}   */

        /// <summary>
        /// Video 50 Single Level of Abstraction - eine Separate Methode Aufrufen
        /// Addieren Methode abstrahieren. Aufpassesn auf Variablennamen, VariablenTypen...
        /// </summary>
        static double Addiere(double ersterSummand, double zweiterSummand)
        {
            double summe = ersterSummand + zweiterSummand;
            return summe;
        }

        ///Video 51 - Versionsverwaltung nicht vergesen, Immer commit und push!!

        /// <summary>
        /// Video 56 Mini-Uebung - erstelle eine Methode die Zwei Zahlen Substrahiert
        /// Substrahieren Methode abstrahieren. Aufpassesn auf Variablennamen, VariablenTypen...
        /// </summary>
        static double Substrahiere(double minuend, double substrahent)
        {
            double differenz = minuend - substrahent;
            return differenz;
        }
        /** Video 57  Benutzerinteraktion - eine Methode fuer alles. Variablen Umbenennen
         *  Dafuer rechrtemaus auf Methode und Umbenennen auswählen, dann sollte es automatisch rechts eine Dialog mit Optionen und zeigt ein Zaehler mit
         *  wieviele Verweise werden damit automatisch auch geaendert, in diesem Fall 3.  auch fuer minuend und substrahent */

        /// <summary>
        /// ERWEITERT - erstelle eine Methode die Zwei Zahlen multipliziert
        /// Multiplizieren Methode abstrahieren. Aufpassesn auf Variablennamen, VariablenTypen...
        /// </summary>
        static double Multipliziere(double ersterFaktor, double zweiterFaktor)
        {
            double produkt = ersterFaktor * zweiterFaktor;
            return produkt;
        }

        /// <summary>
        /// ERWEITERT - erstelle eine Methode die Zwei Zahlen teilt
        /// Teilen Methode abstrahieren. Aufpassesn auf Variablennamen, VariablenTypen...
        /// </summary>
        static double Teile(double dividend, double divisor)
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

        static string HoleBenutzerEingabe(string ausgabeText)
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
