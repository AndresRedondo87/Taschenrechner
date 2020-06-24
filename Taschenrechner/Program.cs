//using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Taschenrechner_Iteration_1
{
    /// <summary>
    /// Taschenrechner: zwei Zahlen eingeben, um deren Summe berechnen zu lassen
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine("****TASCHENRECHNER****");

            Console.WriteLine("Geben Sie bitte ein ersten Summanden ein:");

            string ersterSummand = Console.ReadLine();
            // = is der Zuweisungsoperator
            //nicht mit == verwechseln, das ist genau gleich Vergleichsoperator
            // Datentyp Variablenname IMMER kleingeschrieben =Zuweisungsoperator und dann der Wert der diese Variable zugewiesen sein soll.

            Console.WriteLine("Geben Sie bitte ein zweiten Summanden ein:");
            string zweiterSummand = Console.ReadLine();
            //hier das gleiche mit andere Variablenname

            Console.WriteLine("\n\nDrücken Sie eine beliebige Taste zum beenden");
            Console.ReadKey();
        }
    }
}
