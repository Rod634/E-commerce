using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Pedido : BaseModel
    {
        public Pedido()
        {
            Cadastro = new Cadastro();
            CadastroId = Cadastro.Id;
        }

        public Pedido(Cadastro cadastro)
        {
            Cadastro = cadastro;
            CadastroId = cadastro.Id;
        }

        public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();
        [Required]
        public virtual Cadastro Cadastro { get; private set; }

        public int CadastroId { get; set; }
    }
}
