using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class UserApplicationRepository : IUserApplicationRepository
    {
        private readonly AnimalShelterDbContext context;
        public UserApplicationRepository(AnimalShelterDbContext context)
        {
            this.context = context;
        }

        public UserApplication AddUserApplication(UserApplication userApplication)
        {
            context.UserApplications.Add(userApplication);
            context.SaveChanges();
            return userApplication;
        }

        public UserApplication GetUserApplication(int ID)
        {
            return context.UserApplications.Where(x => x.ID == ID).FirstOrDefault();
        }

        public UserApplication GetUserApplication(int ID, int userID)
        {
            return context.UserApplications.Where(x => x.PetID == ID && x.UserID == userID).FirstOrDefault();
        }

        public List<UserApplication> GetUserApplications(ApplicationTypes applicationType, int status)
        {
            return context.UserApplications.Where(x => x.Status == status || status == -1 && x.ApplicationType == applicationType).ToList();
        }

        public List<UserApplication> GetUserApplications(int userID, int status)
        {
            return context.UserApplications.Where(x => (x.Status == status || status == -1) && (x.UserID == userID)).ToList();
        }

        public UserApplication UpdateUserApplication(UserApplication userApplication)
        {
            context.Entry(userApplication).State = EntityState.Modified;
            context.SaveChanges();
            return userApplication;
        }
    }
}
