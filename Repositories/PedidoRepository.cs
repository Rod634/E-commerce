using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        public PedidoRepository(AplicationContext contexto, IHttpContextAccessor contextAccessor) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Metódo que retorna o ID da sessão
        /// </summary>
        /// <returns>IDsession</returns>
        private int? GetPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("PedidoId");
        }

        public Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();
            //Verifica se esse pedido já existe na sessão
            var pedido = dbset.Where(p => p.Id == pedidoId).SingleOrDefault();

            //Se não existir cria um novo
            if(pedido == null)
            {
                pedido = new Pedido();
                dbset.Add(pedido);
                contexto.SaveChanges();
                SetPedidoId(pedidoId);
            }

            return pedido;
        }

        /// <summary>
        /// Metódo que seta o Id da sessão
        /// </summary>
        /// <param name="PedidoID"></param>
        private void SetPedidoId(int? PedidoID)
        {
            contextAccessor.HttpContext.Session.SetInt32("PedidoId", PedidoID);
        }
    }
}
