using ProjetoModeloDDD.Data.Context;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Data.Repositories
{
    class ProdutoRepository : RepositoryBase<Produto> , IProdutoRepository
    {
       
        public IEnumerable<Produto> GeyByName(string name)
        {
           return db.Produtos.Where(p => p.Nome.Equals(name));
        }
    }
}
