using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Loja_Sapatos.Models
{
    public class VendaViewModel
    {
        public int id { get; set; }
        public string codigoRef { get; set; }
        public int quantidade { get; set; }
        public string CPF { get; set; }
        public DateTime dtVenda { get; set; }
        public double total { get; set; }
        
    }
}
