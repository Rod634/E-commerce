using System.Collections.Generic;

namespace Ecommerce.Repositories
{
    interface IProdutoRepository
    {
        void SalvarMudancas(List<Livro> livros);
    }
}