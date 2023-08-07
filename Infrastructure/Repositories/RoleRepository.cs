using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AnimalShelterDbContext context;
        public RoleRepository(AnimalShelterDbContext context)
        {
            this.context = context;
        }

        public Role AddRole(Role role)
        {
            context.Roles.Add(role);
            context.SaveChanges();
            return role;
        }

        public Role GetRole(int ID)
        {
            return context.Roles.Where(x => x.ID == ID).FirstOrDefault();
        }

        public int GetRoleID(string name)
        {
            return context.Roles.Where(x => x.Name.Contains(name)).FirstOrDefault().ID;
        }

        public List<Role> GetRoles(int status)
        {
            return context.Roles.Where(x => x.Status == status || status == -1).ToList();
        }

        public Role UpdateRole(Role role)
        {
            context.Entry(role).State = EntityState.Modified;
            context.SaveChanges();
            return role;
        }
    }
}
