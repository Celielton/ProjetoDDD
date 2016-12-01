
using ProjetoModeloDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoModeloDDD.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(i => i.ClienteId);

            Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(i => i.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);

            Property(i => i.Email)
                .IsRequired();
        }
    }
}
