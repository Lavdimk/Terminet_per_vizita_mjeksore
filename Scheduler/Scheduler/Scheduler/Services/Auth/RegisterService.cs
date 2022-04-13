using Scheduler.Models;
using Scheduler.Data;
using System.Linq;

namespace Scheduler.Services.Auth
{
    class RegisterService
    {
        public static void Register(
            string firstName,
            string lastName,
            string gender,
            string username,
            string password)
        {
            var maxId = DataSource.Users.OrderByDescending(u => u.Id).FirstOrDefault().Id;
            var patient = new Patient(maxId + 1, firstName, lastName, gender)
            {
                Username = username,
                Password = password
            };

            DataSource.Users.Add(patient);
        }
    }
}
