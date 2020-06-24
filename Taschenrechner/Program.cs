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
            int ersterSummandAlsZahl = Convert.ToInt32(ersterSummand);
            int zweiterSummandAlsZahl = Convert.ToInt32(zweiterSummand);
            // Beim suchen welche convert typ wir brauchen, sehen wir es bei der Rückgabewert von jede Methode in seine Beschreibungen:
            //      short Convert.ToInt16
            //      int Convert.ToInt32
            //      long Convert.ToInt64
            // in diesem Fall passt mit ToInt32. die verschiedene Werte haben mit der Auflösung (und Wertebereich) zu tun.

            int summeAlsZahl = ersterSummandAlsZahl + zweiterSummandAlsZahl;
            Console.WriteLine("Die Summe von gewandelter string {0} \nund gewandelter string {1} beide als int32, ist {2}", ersterSummandAlsZahl, zweiterSummandAlsZahl, summeAlsZahl);


            Console.WriteLine("\n\nDrücken Sie eine beliebige Taste zum beenden");
            Console.ReadKey();
        }
    }
}
