using System;

namespace Scheduler.Models
{
    class Patient : Person, IUser
    {
        public Patient(
            int id,
            string firstName,
            string lastName,
            string gender
            )
            : base(id, firstName, lastName, gender)
        {
        }

        public string Diagnosis { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override void PrintInfo()
        {
            Console.WriteLine($"\nEmri: {FirstName}");
            Console.WriteLine($"Mbiemri: {LastName}");
            Console.WriteLine($"Gjinia: {Gender}");
        }
    }
}
