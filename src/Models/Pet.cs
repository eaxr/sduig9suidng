using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sduig9suidng.Models
{
    public interface IPet
    {
        Task<IEnumerable<Pet>> GetAll();
        Task<Pet> Get(int Id);
        Task<Pet> Create(Pet pet);
        Task<Pet> Save(Pet pet);
        Task<Pet> Delete(Pet pet);
    }

    public class Pet
    {
        public int PetID { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }
    }
}