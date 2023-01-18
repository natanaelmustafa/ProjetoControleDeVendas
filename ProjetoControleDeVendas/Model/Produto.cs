using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleDeVendas.Model {
    internal class Produto {
        
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Qtd { get; set; }
        public int ForId { get; set; }
    }
}
