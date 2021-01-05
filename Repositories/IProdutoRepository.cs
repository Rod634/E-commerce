using Ecommerce.Models;
using System.Collections.Generic;

namespace Ecommerce.Repositories
{
    public interface IProdutoRepository
    {
        void SalvarMudancas(List<Livro> livros);
        IList<Produto> GetProdutos();
    }
}