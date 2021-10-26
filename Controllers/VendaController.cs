using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Loja_Sapatos.Controllers
{
    public class VendaController : Controller
    {
        public IActionResult CadastroVenda()
        {
            return View();
        }

        public IActionResult ListarVendas()
        {
            return View();
        }
    }
}
