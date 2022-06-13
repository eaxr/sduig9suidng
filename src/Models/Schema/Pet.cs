using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sduig9suidng.Models;


namespace Sduig9suidng.Schema
{
    public class PetMap
    {
        public PetMap(EntityTypeBuilder<Pet> entityBuilder)
        {
            entityBuilder.HasKey(x => x.PetID);
            entityBuilder.ToTable("clpets");

            entityBuilder.Property(x => x.PetID).HasColumnName("id");
            entityBuilder.Property(x => x.Name).HasColumnName("name");
            entityBuilder.Property(x => x.ClientId).HasColumnName("ClientId");
        }
    }
}