using System;

namespace PrettyHair1
{
    public class Appointment
    {
        public DateTime appointmentDate;
        public string startTime;
        public string endTime;
        public string notes;
        public Appointment ()
        {
            appointmentDate=DateTime.Now ;
           startTime = "13:00";
            endTime = "13:45";
            notes = "the most amazing and unbelievable tattoo 2k16";
        }

    }
}
