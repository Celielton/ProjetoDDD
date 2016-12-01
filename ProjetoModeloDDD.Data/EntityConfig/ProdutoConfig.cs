using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Data.EntityConfig
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(i => i.ProdutoId);

            Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(i => i.Valor)
                .IsRequired();

            HasRequired(p => p.Cliente) // requirida para FK
                .WithMany() // 1:N
                .HasForeignKey(p => p.ClienteId); //Referencia

        }
    }
}
