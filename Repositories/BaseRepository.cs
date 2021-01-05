using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly AplicationContext contexto;
        protected readonly DbSet<T> dbset;

        public BaseRepository(AplicationContext contexto)
        {
            this.contexto = contexto;
            dbset = contexto.Set<T>();
        }
    }
}
