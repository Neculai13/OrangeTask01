using System.Linq;
using Domain.Entities;
using Domain.Repository.Interfaces;

namespace Domain.Repository
{
    public class UserRepository:IUserRepository
    {
        public User GetByUserName(string name)
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                var dbUser = dbContext.Users.SingleOrDefault(x => x.UserName == name);
                return dbUser;
            }
        }

        public bool IsValid(string userName, string password)
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                var dbUser = dbContext.Users.SingleOrDefault(x => x.UserName == userName);
                return dbUser != null && dbUser.Password == password;
            }
        }
    }
}