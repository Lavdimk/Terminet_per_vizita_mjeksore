using Scheduler.Data;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.Services
{
    class AppointmentService
    {
        static Random _random = new Random();

        public static IEnumerable<Appointment> GetAppointmentsByPatient(Patient patient, bool approved)
        {
            return DataSource.Appointments.Where(a => a.Patient == patient)
                .Where(a => a.Approved == approved);
        }

        public static void AddAppointment(Appointment appointment)
        {
            appointment.Id = _random.Next(1, 100);
            DataSource.Appointments.Add(appointment);
        }

        public static Appointment GetAppointmentRequestById(int id)
        {
            return DataSource.Appointments.Where(a => a.Approved == false)
                .FirstOrDefault(a => a.Id == id);
        }

        public static IEnumerable<Appointment> GetAppointments(bool approved)
        {
            return DataSource.Appointments.Where(a => a.Approved == approved);
        }
    }
}
