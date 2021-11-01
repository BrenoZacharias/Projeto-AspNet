using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Loja_Sapatos.Models
{
    public class ModeloViewModel
    {
        public int id { get; set; }
        public int id_fornecedor { get; set; }
        public string nome_fornecedor { get; set; }
        public int id_categoria { get; set; }
        public string nome_categoria { get; set; }
        public string nome { get; set; }
        public string codigoRef { get; set; }
        public string cor { get; set; }
        public int tamanho { get; set; }
        public double valor { get; set; }
    }
}
