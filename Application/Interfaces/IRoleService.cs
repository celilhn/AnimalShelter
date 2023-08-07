using Domain.Models;

namespace Application.Interfaces
{
    public interface IRoleService
    {
        public Role GetRole(int ID);
        public List<Role> GetRoles(int status);
        public Role SaveRole(Role role);
        public int GetRoleID(string name);
    }
}
