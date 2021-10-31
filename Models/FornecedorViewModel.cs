using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Loja_Sapatos.Models
{
    public class FornecedorViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Endereco { get; set; }
    }
}