using System.Linq;
using Scheduler.Models;
using Scheduler.Data;

namespace Scheduler.Services.Auth
{
    class LoginService
    {
        public static IUser Login(string username, string password)
        {
            var user = DataSource.Users.FirstOrDefault(u => u.Username == username);

            if (user != null && user.Password == password)
                return user;
            else
                return null;
        }
    }
}
