using Ecommerce.Models;
using System.Collections.Generic;

namespace Ecommerce.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AplicationContext contexto;

        public ProdutoRepository(AplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public void SalvarMudancas(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                contexto.Set<Produto>().Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
            }

            contexto.SaveChanges();
        }

    }
 
}
