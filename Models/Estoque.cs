using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Loja_Sapatos.Models
{
    public class Estoque
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Modelo")]
        public int Id_Modelo { get; set;}
        public virtual Modelo Modelo { get; set; }
        public int Qtd { get; set; }
    }
}
