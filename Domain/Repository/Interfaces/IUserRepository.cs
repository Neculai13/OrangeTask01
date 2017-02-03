using Domain.Entities;

namespace Domain.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetByUserName(string name);
        bool IsValid(string userName, string password);
    }
}