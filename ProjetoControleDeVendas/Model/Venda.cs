using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleDeVendas.Model {
    internal class Venda {
        
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal TotalVenda { get; set; }
        public string Obs { get; set; }
    }
}
