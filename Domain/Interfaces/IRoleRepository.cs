using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRoleRepository
    {
        public Role GetRole(int ID);
        public List<Role> GetRoles(int status);
        public Role AddRole(Role role);
        public Role UpdateRole(Role role);
        public int GetRoleID(string name);
    }
}
