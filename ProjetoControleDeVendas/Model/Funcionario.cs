using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleDeVendas.Model {
    internal class Funcionario : Cliente {

        public string Senha { get; set; }
        public string Cargo { get; set; }
        public string Acesso { get; set; }
    }
}
