using PushAPI.DAL.Entities;

namespace PushAPI.ServiceLayer.Services
{
    public interface IUserService : IEntityService<User>
    {
        string HashPassword(string password);
        bool VerifyHashedPassword(string hashedPassword, string password);
    }
}