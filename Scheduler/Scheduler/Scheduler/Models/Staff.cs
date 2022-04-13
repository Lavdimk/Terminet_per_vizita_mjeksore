namespace Scheduler.Models
{
    abstract class Staff : Person
    {
        public Staff(
            int id,
            string firstName,
            string lastName,
            string gender,
            decimal salary
            )
            : base(id, firstName, lastName, gender)
        {
            Salary = salary;
        }

        public decimal Salary { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
