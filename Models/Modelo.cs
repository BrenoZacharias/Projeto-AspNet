using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Loja_Sapatos.Models
{
    public class Modelo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int id_fornecedor { get; set; }
        public String nome { get; set; }
        public String codigoRef { get; set; }
        public String cor { get; set; }
        public int tamanho { get; set; }
    }
}
