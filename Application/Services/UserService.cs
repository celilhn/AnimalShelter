using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User GetUser(string email, string password)
        {
            return userRepository.GetUser(email, password);
        }

        public User GetUser(string email)
        {
            return userRepository.GetUser(email);
        }

        public User GetUser(int userID)
        {
            return userRepository.GetUser(userID);
        }

        public User GetUserByUserName(string username)
        {
            return userRepository.GetUserByUserName(username);
        }

        public List<User> GetUsers(int status)
        {
            return userRepository.GetUsers(status);
        }

        public User SaveUser(User user)
        {
            if (user.ID > 0)
            {
                user.UpdateDate = DateTime.Now;
                user = userRepository.UpdateUser(user);
            }
            else
            {
                user = userRepository.AddUser(user);
            }
            return user;
        }
    }
}
