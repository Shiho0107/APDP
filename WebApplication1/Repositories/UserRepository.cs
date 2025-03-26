using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DemoContext demoContext) : base(demoContext)
        {
        }

        public User GetUserByUsername(string username)
        {
            return _dbset.FirstOrDefault(u => u.Username == username);
        }

        public User getUserByUsernameAndPassword(string username, string password)
        {
            return _dbset.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
