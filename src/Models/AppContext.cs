using Microsoft.EntityFrameworkCore;

using Sduig9suidng.Models;
using Sduig9suidng.Schema;


namespace Sduig9suidng.Models
{
    public class _DbContext : DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options)
            : base(options)
        {

        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new PetMap(modelBuilder.Entity<Pet>());
            new ClientMap(modelBuilder.Entity<Client>());
        }
    }
}