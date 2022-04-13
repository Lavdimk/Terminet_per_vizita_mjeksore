using System;

namespace Scheduler.Models
{
    class Appointment
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public bool Approved { get; set; } = false;
    }
}
