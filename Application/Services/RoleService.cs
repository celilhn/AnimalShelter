using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public Role GetRole(int ID)
        {
            return roleRepository.GetRole(ID);
        }

        public int GetRoleID(string name)
        {
            return roleRepository.GetRoleID(name);
        }

        public List<Role> GetRoles(int status)
        {
            return roleRepository.GetRoles(status);
        }

        public Role SaveRole(Role role)
        {
            if (role.ID > 0)
            {
                role.UpdateDate = DateTime.Now;
                role = roleRepository.UpdateRole(role);
            }
            else
            {
                role = roleRepository.AddRole(role);
            }
            return role;
        }
    }
}
