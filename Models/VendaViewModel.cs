using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Loja_Sapatos.Models
{
    public class VendaViewModel
    {
        public List<int> codigoRef { get; set; }
        public List<int> id_modelo { get; set; }
        public List<string> nome_modelo { get; set; }
        public List<string> nome_fornecedor { get; set; }
        public List<int> tamanho_modelo { get; set; }
        public List<string> cor_modelo { get; set; }
        public List<float> valorItem { get; set; }
        public List<int> quantidade { get; set; }
        public int id_cliente { get; set; }
        public string nome_cliente { get; set; }
        public DateTime dtVenda { get; set; }
        public float total { get; set; }
        
    }
}
