using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrettyHairTest
{
    [TestClass]
    public class AppointmentTest
    {
        private Appointment appointment;

        [TestInitialize]
        public void SetupForTest()
        {
            appointment = new Appointment();
        }

        [TestMethod]
        public void ShouldStartEverySentenceInNotesWithUpperCase()
        {
            appointment.Notes = "black-eyed wolf. medium size tattoo.";
            Assert.AreEqual("Black-eyed wolf. Medium size tattoo.", Appointment.ChangeNotes(appointment.Notes));
        }
    }
}
