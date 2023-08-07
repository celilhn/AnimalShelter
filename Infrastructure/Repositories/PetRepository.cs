using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly AnimalShelterDbContext context;
        public PetRepository(AnimalShelterDbContext context)
        {
            this.context = context;
        }

        public Pet AddPet(Pet pet)
        {
            context.Pets.Add(pet);
            context.SaveChanges();
            return pet;
        }

        public List<Pet> GetApprovedPets()
        {
            return context.Pets.Where(x => x.Approved == 1).ToList();
        }

        public Pet GetPet(int ID)
        {
            return context.Pets.Where(x => x.ID == ID).FirstOrDefault();
        }

        public List<Pet> GetPets(int status)
        {
            return context.Pets.Where(x => x.Status == 1 || status == -1).ToList();
        }

        public Pet UpdatePet(Pet pet)
        {
            context.Entry(pet).State = EntityState.Modified;
            context.SaveChanges();
            return pet;
        }
    }
}
