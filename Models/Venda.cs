using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Loja_Sapatos.Models
{
    public class Venda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Modelo")]
        public int id_modelo { get; set;}
        public virtual Modelo Modelo { get; set; }
        [ForeignKey("Cliente")]
        public int id_cliente { get; set;}
        public virtual Cliente Cliente { get; set; }
        public int quantidade { get; set; }
        public DateTime dtVenda { get; set; }
    }
}
