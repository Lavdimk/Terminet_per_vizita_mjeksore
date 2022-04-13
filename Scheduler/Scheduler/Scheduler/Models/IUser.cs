namespace Scheduler.Models
{
    interface IUser
    {
        int Id { get; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
