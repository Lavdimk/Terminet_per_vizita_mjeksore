using Scheduler.Data;
using Scheduler.Models;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.Services
{
    class DoctorService
    {
        public static IEnumerable<Doctor> GetAllDoctors()
        {
            return DataSource.Users.OfType<Doctor>().ToList();
        }

        public static Doctor GetDoctorById(int id)
        {
            return DataSource.Users.OfType<Doctor>().ToList().FirstOrDefault(d => d.Id == id);
        }
    }
}
