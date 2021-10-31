using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Loja_Sapatos.Models
{
    public class EstoqueViewModel
    {
        public int Id { get; set; }
        public int Id_Modelo { get; set; }
        public string Nome_modelo { get; set; }
        public int Qtd { get; set; }
    }
}
