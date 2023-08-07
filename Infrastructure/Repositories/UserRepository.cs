using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AnimalShelterDbContext context;
        public UserRepository(AnimalShelterDbContext context)
        {
            this.context = context;
        }

        public User GetUser(string email, string password)
        {
            return context.Userssss.Where(x => x.Email == email && x.Password == password && x.Status == 1).FirstOrDefault();
        }

        public User GetUser(int userID)
        {
            return context.Userssss.FirstOrDefault(x => x.ID == userID);
        }

        public User GetUser(string email)
        {
            return context.Userssss.FirstOrDefault(x => x.Email == email);
        }

        public User GetUserByUserName(string username)
        {
            return context.Userssss.FirstOrDefault(x => x.UserName == username);
        }

        public User AddUser(User user)
        {
            context.Userssss.Add(user);
            context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
            return user;
        }

        public List<User> GetUsers(int status)
        {
            return context.Userssss.Where(x => x.Status == status || status == -1).ToList();
        }
    }
}
