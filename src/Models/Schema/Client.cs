using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sduig9suidng.Models;


namespace Sduig9suidng.Schema
{
    public class ClientMap
    {
        public ClientMap(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ClientId);
            entityBuilder.ToTable("clclients");

            entityBuilder.Property(x => x.ClientId).HasColumnName("id");
            entityBuilder.Property(x => x.FirstName).HasColumnName("firstname");
            entityBuilder.Property(x => x.LastName).HasColumnName("lastname");
        }
    }
}