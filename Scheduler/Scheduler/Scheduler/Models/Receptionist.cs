using System;

namespace Scheduler.Models
{
    class Receptionist : Staff, IUser
    {
        public Receptionist(
            int id,
            string firstName,
            string lastName,
            string gender,
            decimal salary)
            : base(id, firstName, lastName, gender, salary)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"\nEmri: {FirstName}");
            Console.WriteLine($"Mbiemri: {LastName}");
            Console.WriteLine($"Rroga: {Salary} EURO");
        }
    }
}
