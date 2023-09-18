using DDD.Unimar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.MemoryDb
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "UniversityDb");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
    }
}