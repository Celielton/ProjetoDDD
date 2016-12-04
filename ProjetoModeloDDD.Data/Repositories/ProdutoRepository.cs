using ProjetoModeloDDD.Data.Context;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;


namespace ProjetoModeloDDD.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto> , IProdutoRepository
    {
       
        public IEnumerable<Produto> GeyByName(string name)
        {
           return db.Produtos.Where(p => p.Nome.Equals(name));
        }
    }
}
