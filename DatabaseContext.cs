using Ecommerce.Models;
using Ecommerce.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Ecommerce
{
    class DatabaseContext : IDatabaseContext
    {
        private readonly AplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        public DatabaseContext(AplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void iniciarDb()
        {
            contexto
                .Database
                .Migrate();

            List<Livro> livros = GetLivros();

            produtoRepository.SalvarMudancas(livros);
        }

        private static List<Livro> GetLivros()
        {
            var file = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(file);
            return livros;
        }
    }
}
