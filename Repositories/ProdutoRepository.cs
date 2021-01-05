using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AplicationContext contexto;
        private readonly DbSet<Produto> dbset;

        public ProdutoRepository(AplicationContext contexto)
        {
            this.contexto = contexto;
            dbset = contexto.Set<Produto>();
        }

        public IList<Produto> GetProdutos()
        {
            return dbset.ToList();
        }

        public void SalvarMudancas(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if(!dbset.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    dbset.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }

            contexto.SaveChanges();
        }

    }
 
}
