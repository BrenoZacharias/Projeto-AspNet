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
        [ForeignKey("Fornecedor")]
        public int id_fornecedor { get; set;}
        public virtual Fornecedor Fornecedor { get; set; }
        [ForeignKey("Categoria")]
        public int id_categoria { get; set;}
        public virtual Categoria Categoria { get; set; }
        public string nome { get; set; }
        public string codigoRef { get; set; }
        public string cor { get; set; }
        public int tamanho { get; set; }
        public double valor { get; set; }
        
    }
}
