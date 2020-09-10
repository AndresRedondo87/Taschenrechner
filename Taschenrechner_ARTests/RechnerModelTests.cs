using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taschenrechner_AR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner_AR.Tests
{
    [TestClass()]
    public class RechnerModelTests
    {
        [TestMethod()]  ///Attribute um testmethode zu erstellen
                        ///Die Änderungen an der Datei Taschenrechner.sln zeigen was Visual Studio an der Solution ändert um das neue Projekt für die Unittests 
                        ///(TaschenrechnerTests) hinzuzufügen.
                        ///
                        ///public void Berechne_DivisionDurchNull_ergibtNaN()  // NaN = Not A Number
        public void Berechne_DivisionDurchNull_ergibtUnendlich()
        {
            //als erstes die Klassen und Methoden vorbereiten
            RechnerModel model = new RechnerModel();

            //dann die gebrauchten Parameter, in diesem Fall Zahlen und Operation
            model.Operation = "/";
            model.ErsteZahl = 10;
            model.ZweiteZahl = 0;

            // und das was wir ausfuehren bzw testen wollen
            model.Berechne();

            /// Assert ist ein Objekt die viele Methoden hat um Resultat zu UEberpruefen
            /// oft wird AreEquel benutzt um das erwartete wert mit den Ergebniss von unsere Methode zu vergleichen.
            ///Assert.AreEqual(Double.NaN, model.Resultat);
            Assert.AreEqual(Double.PositiveInfinity, model.Resultat);
            // es ergab error, beim Lehrer Beispiel hat es direkt geklappt (ich hatte schon das durch null vermieden.
            // Assert.AreEqual(0, model.Resultat);

        }

        /// <summary>
        /// Vorlage fuer ein Zweiter test... Unnoetige Test
        /// </summary>
        [TestMethod()]
        public void BerechneTest_DivisionDurchNull_ergibtZero()
        {
            RechnerModel model = new RechnerModel();
            model.Operation = "/";
            model.ErsteZahl = 10;
            model.ZweiteZahl = 0;

            model.Berechne();

            Assert.AreEqual(0, model.Resultat);
        }
    }
}