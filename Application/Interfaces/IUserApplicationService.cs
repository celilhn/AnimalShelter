using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Interfaces
{
    public interface IUserApplicationService
    {
        public UserApplication GetUserApplication(int ID);
        public UserApplication GetUserApplication(int ID, int userID);
        public List<UserApplication> GetUserApplications(ApplicationTypes applicationType, int status);
        public List<UserApplication> GetUserApplications(int userID, int status);
        public UserApplication SaveUserApplication(UserApplication userApplication);
    }
}
