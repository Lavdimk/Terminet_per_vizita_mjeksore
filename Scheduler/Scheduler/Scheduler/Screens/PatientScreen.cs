using Scheduler.Models;
using Scheduler.Services;
using System;

namespace Scheduler.Screens
{
    class PatientScreen
    {
        public Patient CurrentUser { get; set; }

        public void Show(Patient patient)
        {
            CurrentUser = patient;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Mire se vini, " + CurrentUser.FullName + ".");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nListo te gjithe doktoret e klinikes [doktoret]");
                Console.WriteLine("Listo te gjitha kerkesat e mia [kerkesat]");
                Console.WriteLine("Listo te gjitha terminet e mia [terminet]");
                Console.WriteLine("Cakto nje termin [cakto]");
                Console.WriteLine("Ma trego diagnozen [diagnoza]");
                Console.WriteLine("Shfaq te dhenat personale [info]");
                Console.WriteLine("Ckyqu [ckyqu]\n");
                Console.ResetColor();
                Console.Write("> ");

                var command = Console.ReadLine().Trim().ToLower();

                switch (command)
                {
                    case "doktoret":
                        ListAllDoctors();
                        break;
                    case "cakto":
                        ScheduleAppointment();
                        break;
                    case "kerkesat":
                        ListAllAppointmentRequests();
                        break;
                    case "terminet":
                        ListAllAppointments();
                        break;
                    case "diagnoza":
                        ShowDiagnosis();
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

        void ListAllAppointmentRequests()
        {
            Console.WriteLine("\nKERKESAT E MIA PER TERMINE");
            Console.WriteLine("\n{0}{1}{2}{3}", "Id".PadRight(3), "Pacienti".PadRight(20), "Doktori".PadRight(20), "Data");
            Console.WriteLine("----------------------------------------------------");

            foreach (var appointment in AppointmentService.GetAppointmentsByPatient(CurrentUser, false))
            {
                Console.WriteLine("{0}{1}{2}{3}",
                    appointment.Id.ToString().PadRight(3),
                    appointment.Patient.FullName.PadRight(20),
                    appointment.Doctor.FullName.PadRight(20),
                    appointment.Date.ToShortDateString());
            }
        }

        void ListAllAppointments()
        {
            Console.WriteLine("\nTERMINET E MIA\n");
            Console.WriteLine("{0}{1}{2}{3}", "Id".PadRight(3), "Pacienti".PadRight(20), "Doktori".PadRight(20), "Data");
            Console.WriteLine("----------------------------------------------------");

            foreach (var appointment in AppointmentService.GetAppointmentsByPatient(CurrentUser, true))
            {
                Console.WriteLine("{0}{1}{2}{3}",
                    appointment.Id.ToString().PadRight(3),
                    appointment.Patient.FullName.PadRight(20),
                    appointment.Doctor.FullName.PadRight(20),
                    appointment.Date.ToShortDateString());
            }
        }

        void ListAllDoctors()
        {
            Console.WriteLine("\nDOKTORET E KLINIKES\n");
            Console.WriteLine("{0}{1}{2}", "Id".PadRight(3), "Emri".PadRight(20), "Specializimi");
            Console.WriteLine("-----------------------------------");

            foreach (var doctor in DoctorService.GetAllDoctors())
            {
                Console.WriteLine("{0}{1}{2}",
                    doctor.Id.ToString().PadRight(3),
                    doctor.FullName.PadRight(20),
                    doctor.Specialization);
            }
        }

        void ScheduleAppointment()
        {
            Console.Write("  ID i doktorit: ");
            int.TryParse(Console.ReadLine().Trim(), out int id);

            var doctor = DoctorService.GetDoctorById(id);

            if (doctor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ju lutem shkruani nje ID te sakte!");
                Console.ResetColor();
                return;
            }

            Console.Write("  Data: ");
            try
            {
                var date = Convert.ToDateTime(Console.ReadLine());

                AppointmentService.AddAppointment(new Appointment()
                {
                    Patient = CurrentUser,
                    Doctor = doctor,
                    Date = date
                });

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nKerkesa u dergua me sukses.");
                Console.ResetColor();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nData nuk eshte ne formatin e duhur!");
                Console.ResetColor();
            }
        }

        void ShowDiagnosis()
        {
            Console.WriteLine("\nDIAGNOZA\n");
            Console.WriteLine(CurrentUser.Diagnosis);
        }
    }
}
