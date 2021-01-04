using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Ecommerce
{
    class DatabaseContext : IDatabaseContext
    {
        private readonly AplicationContext contexto;

        public DatabaseContext(AplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public void iniciarDb()
        {
            contexto
                .Database
                .Migrate();

            var file = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(file);

        }
    }
}
