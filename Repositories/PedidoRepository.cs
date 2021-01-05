using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>
    {
        public PedidoRepository(AplicationContext contexto) : base(contexto)
        {
        }
    }
}
