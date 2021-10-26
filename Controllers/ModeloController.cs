using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Loja_Sapatos.Controllers
{
    public class ModeloController : Controller
    {
        public IActionResult CadastrarModelo()
        {
            return View();
        }
        public IActionResult ListarModelos()
        {
            return View();
        }
    }
}
