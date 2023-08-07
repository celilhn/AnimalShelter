using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Context
{
    public class AnimalShelterDbContext : DbContext
    {
        public AnimalShelterDbContext(DbContextOptions<AnimalShelterDbContext> options) : base(options) { }

        public DbSet<User> Userssss { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<User>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<User>().Property(b => b.Status).HasDefaultValue(1);

            modelBuilder.Entity<UserApplication>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<UserApplication>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<UserApplication>().Property(b => b.Status).HasDefaultValue(1);

            modelBuilder.Entity<Pet>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Pet>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Pet>().Property(b => b.Status).HasDefaultValue(1);
            modelBuilder.Entity<Pet>().Property(b => b.Approved).HasDefaultValue(1);

            modelBuilder.Entity<PetType>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<PetType>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<PetType>().Property(b => b.Status).HasDefaultValue(1);

            modelBuilder.Entity<Role>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Role>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Role>().Property(b => b.Status).HasDefaultValue(1);
        }
    }
}
