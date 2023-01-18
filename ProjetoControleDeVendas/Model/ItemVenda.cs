using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleDeVendas.Model {
    internal class ItemVenda {
        
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Qtd { get; set; }
        public decimal Subtotal { get; set; }
    }
}
