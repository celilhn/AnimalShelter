using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private readonly AnimalShelterDbContext context;
        public PetTypeRepository(AnimalShelterDbContext context)
        {
            this.context = context;
        }

        public PetType AddPetType(PetType petType)
        {
            context.PetTypes.Add(petType);
            context.SaveChanges();
            return petType;
        }

        public PetType GetPetType(int ID)
        {
            return context.PetTypes.Where(x => x.ID == ID).FirstOrDefault();
        }

        public List<PetType> GetPetTypes(int status)
        {
            return context.PetTypes.Where(x => x.Status == status || status == -1).ToList();
        }

        public PetType UpdatePetType(PetType petType)
        {
            context.Entry(petType).State = EntityState.Modified;
            context.SaveChanges();
            return petType;
        }
    }
}
