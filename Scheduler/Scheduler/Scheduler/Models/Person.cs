namespace Scheduler.Models
{
    abstract class Person
    {
        public Person(int id, string firstName, string lastName, string gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string FullName { get => FirstName + " " + LastName; }

        public abstract void PrintInfo();
    }
}
