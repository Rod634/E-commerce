using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;

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
            var pedido = dbset
                .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefault();

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
            contextAccessor.HttpContext.Session.SetInt32("PedidoId", (int)PedidoID);
        }

        public void AddItem(string codigo)
        {
            //Verifica se há produto com o código passado
            var produto = contexto.Set<Produto>()
                .Where(p => p.Codigo == codigo)
                .SingleOrDefault();

            //caso não exista lança uma exceção 
            if(produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            //Pega o pedido da sessão
            var pedido = GetPedido();

            //Verifica se o item está no pedido e se está na mesma sessão
            var itemPedido = contexto.Set<ItemPedido>()
                .Where(p => p.Produto.Codigo == codigo
                && p.Pedido.Id == pedido.Id)
                .SingleOrDefault();

            if(itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                contexto.Set<ItemPedido>().Add(itemPedido);
            }

            contexto.SaveChanges();
        }
    }
}
