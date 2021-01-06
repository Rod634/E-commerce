using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository PedidoRepository;
        public StoreController(IProdutoRepository produtoRepository, IPedidoRepository PedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.PedidoRepository = PedidoRepository;
        }

        public IActionResult Index()
        {
            return View(produtoRepository.GetProdutos());
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult BlogDetails()
        {
            return View();
        }
        public IActionResult CheckOut()
        {
            return View();
        }
        public IActionResult Contat()
        {
            return View();
        }
        public IActionResult Faq()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Main()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult ShoppingCart()
        {
            Pedido pedido = PedidoRepository.GetPedido();
            return View(pedido);
        }
        
    }
}
