using Scheduler.Models;
using Scheduler.Services;
using System;

namespace Scheduler.Screens
{
    class ReceptionistScreen
    {
        Receptionist CurrentUser { get; set; }

        public void Show(Receptionist receptionist)
        {
            CurrentUser = receptionist;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Mire se vini, " + CurrentUser.FullName + ".");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nListo te gjitha kerkesat per termine [kerkesat]");
                Console.WriteLine("Listo te gjitha terminet aktuale [terminet]");
                Console.WriteLine("Aprovo nje termin [aprovo]");
                Console.WriteLine("Shfaq te dhenat personale [info]");
                Console.WriteLine("Ckyqu [ckyqu]\n");
                Console.ResetColor();
                Console.Write("> ");

                var command = Console.ReadLine().Trim().ToLower();

                switch (command)
                {
                    case "kerkesat":
                        ListAllAppointmentRequests();
                        break;
                    case "terminet":
                        ListAllAppointments();
                        break;
                    case "aprovo":
                        ApproveAppointment();
                        break;
                    case "info":
                        CurrentUser.PrintInfo();
                        break;
                    case "ckyqu":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nKomande e panjohur!\n");
                        Console.ResetColor();
                        break;
                }
            }
        }

        static void ListAllAppointmentRequests()
        {
            Console.WriteLine("\nKERKESAT PER TERMINE");
            Console.WriteLine("\n{0}{1}{2}{3}", "Id".PadRight(3), "Pacienti".PadRight(20), "Doktori".PadRight(20), "Data");
            Console.WriteLine("----------------------------------------------------");

            foreach (var a in AppointmentService.GetAppointments(false))
            {
                Console.WriteLine("{0}{1}{2}{3}",
                    a.Id.ToString().PadRight(3),
                    a.Patient.FullName.PadRight(20),
                    a.Doctor.FullName.PadRight(20),
                    a.Date.ToShortDateString());
            }
        }

        void ListAllAppointments()
        {
            Console.WriteLine("\nTERMINET\n");
            Console.WriteLine("{0}{1}{2}{3}", "Id".PadRight(3), "Pacienti".PadRight(20), "Doktori".PadRight(20), "Data");
            Console.WriteLine("----------------------------------------------------");

            foreach (var appointment in AppointmentService.GetAppointments(true))
            {
                Console.WriteLine("{0}{1}{2}{3}",
                    appointment.Id.ToString().PadRight(3),
                    appointment.Patient.FullName.PadRight(20),
                    appointment.Doctor.FullName.PadRight(20),
                    appointment.Date.ToShortDateString());
            }
        }

        static void ApproveAppointment()
        {
            Console.Write("  ID i kerkeses: ");
            int.TryParse(Console.ReadLine().Trim(), out int id);

            var appointment = AppointmentService.GetAppointmentRequestById(id);

            if (appointment != null)
            {
                appointment.Doctor.Patients.Add(appointment.Patient);
                appointment.Approved = true;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTermini u aprovua me sukses.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nKerkesa nuk ekziston!");
                Console.ResetColor();
            }
        }
    }
}
