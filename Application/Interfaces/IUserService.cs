using Domain.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public User GetUser(string email, string password);
        public User GetUser(string email);
        public User GetUserByUserName(string username);
        public User GetUser(int userID);
        public List<User> GetUsers(int status);
        public User SaveUser(User user);
    }
}
