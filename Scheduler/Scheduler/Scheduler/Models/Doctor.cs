using System;
using System.Collections.Generic;

namespace Scheduler.Models
{
    class Doctor : Staff, IUser
    {
        public Doctor(int id,
            string firstName,
            string lastName,
            string gender,
            decimal salary,
            string specialization)
            : base(id, firstName, lastName, gender, salary)
        {
            Specialization = specialization;
            Patients = new List<Patient>();
        }

        public string Specialization { get; set; }
        public List<Patient> Patients { get; set; }

        public override void PrintInfo()
        {
            Console.WriteLine($"\nEmri: {FirstName}");
            Console.WriteLine($"Mbiemri: {LastName}");
            Console.WriteLine($"Specializimi: {Specialization}");
            Console.WriteLine($"Rroga: {Salary} EURO");
        }
    }
}
