using ProjetoModeloDDD.Data.EntityConfig;
using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Data.Context
{
    public class ProjetoModeloContex : DbContext     
    {
        public ProjetoModeloContex()
            :base("CONN")
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Não Pluralizar nomes de Tables
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Não deletar em castata 1 : N
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Não deletar em castata N : N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //Configura Nome + Id como PK
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //configura string como varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //configura string como default 100
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());

            modelBuilder.Configurations.Add(new ProdutoConfig());

            //base.OnModelCreating(modelBuilder); 
        }

        public override int SaveChanges()
        {

            var entries = ChangeTracker.Entries().Where(p => p.Entity.GetType().GetProperty("Data_Cadastro") == null);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                else if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;


            }
            return base.SaveChanges();
        }
    }
}
