using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public User GetUser(string email, string password);
        public User GetUser(string email);
        public User GetUserByUserName(string username);
        public User GetUser(int userID);
        public List<User> GetUsers(int status);
        public User AddUser(User user);
        public User UpdateUser(User user);
    }
}
