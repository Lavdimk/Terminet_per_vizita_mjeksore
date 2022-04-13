using Scheduler.Models;
using System.Collections.Generic;

namespace Scheduler.Data
{
    static class DataSource
    {
        public static List<IUser> Users { get; set; } =
        new List<IUser>()
            {
                new Doctor(1, "Doktori", "Pare", "Mashkull", 100, "Pergjithshem")
                {
                    Username = "dok1",
                    Password = "dok1"
                },
                new Doctor(2, "Doktori", "Dyte", "Mashkull", 100, "Pediater")
                {
                    Username = "dok2",
                    Password = "dok2"
                },
                new Doctor(3, "Doktoresha", "Trete", "Femer", 100, "Dermatologe")
                {
                    Username = "dok3",
                    Password = "dok3"
                },
                new Receptionist(4, "Recepcionisti", "Pare", "Mashkull", 100)
                {
                    Username = "rec1",
                    Password = "rec1"
                },
                new Receptionist(5, "Recepcionistja", "Dyte", "Femer", 100)
                {
                    Username = "rec2",
                    Password = "rec2"
                },
                new Patient(6, "Pacienti", "Pare", "Mashkull")
                {
                    Username = "pac1",
                    Password = "pac1"
                },
                new Patient(7, "Pacientja", "Dyte", "Femer")
                {
                    Username = "pac2",
                    Password = "pac2"
                }
            };
        public static List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
