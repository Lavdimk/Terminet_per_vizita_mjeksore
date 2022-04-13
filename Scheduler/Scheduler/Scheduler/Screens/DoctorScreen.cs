using Scheduler.Models;
using Scheduler.Services;
using System;

namespace Scheduler.Screens
{
    class DoctorScreen
    {
        public Doctor CurrentUser { get; set; }

        public void Show(Doctor doctor)
        {
            CurrentUser = doctor;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Mire se vini, " + CurrentUser.FullName + ".");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nListo te gjithe pacientet e mi [pacientet]");
                Console.WriteLine("Cakto diagnozen e pacientit [diagnoza]");
                Console.WriteLine("Shfaq te dhenat personale [info]");
                Console.WriteLine("Ckyqu [ckyqu]\n");
                Console.ResetColor();
                Console.Write("> ");

                var command = Console.ReadLine().Trim().ToLower();

                switch (command)
                {
                    case "pacientet":
                        ListPatients();
                        break;
                    case "diagnoza":
                        Diagnose();
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

        public void ListPatients()
        {
            Console.WriteLine("\nPACIENTET E MI\n");

            foreach (var p in CurrentUser.Patients)
            {
                Console.WriteLine("Id: " + p.Id);
                Console.WriteLine("Emri: " + p.FirstName);
                Console.WriteLine("Mbiemri: " + p.LastName);
                Console.WriteLine("Gjinia: " + p.Gender);
                Console.WriteLine("Diagnoza: " + p.Diagnosis);
                Console.WriteLine();
            }
        }

        public void Diagnose()
        {
            Console.Write("\n  ID e pacientit: ");
            int.TryParse(Console.ReadLine().Trim(), out int id);

            var patient = PatientService.GetPatientByDoctor(CurrentUser, id);

            if (patient != null)
            {
                Console.Write("  Diagnoza: ");
                patient.Diagnosis = Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nJu nuk keni nje pacient te tille!");
                Console.ResetColor();
            }
        }
    }
}
