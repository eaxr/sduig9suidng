using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Sduig9suidng.Models;


namespace Sduig9suidng.Models.Crud
{
    public class PetRepo : IPet
    {
        private readonly _DbContext context;

        public PetRepo(_DbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Pet>> GetAll()
        {
            return await context.Pets
                .Where( b => b.PetID > 0 )
                .OrderBy( p => p.PetID )
                .ToListAsync();
        }

        public async Task<Pet> Create(Pet pet)
        {
            await context.Pets.AddAsync(pet);
            await this.Save(pet);
            return pet;
        }

        public async Task<Pet> Get(int id)
        {
            return await context.Pets
                .FirstOrDefaultAsync(b => b.PetID == id);
        }

        public async Task<Pet> Delete(Pet pet)
        {
            context.Pets.Remove(pet);
            await this.Save(pet);
            return pet;
        }

        public async Task<Pet> Save(Pet pet)
        {
            await context.SaveChangesAsync();
            return pet;
        }
    }
}