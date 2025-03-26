using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        User getUserByUsernameAndPassword(string username, string password);
    }
}
