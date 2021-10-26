using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Loja_Sapatos.Controllers
{
    public class FornecedorController : Controller
    {
        public IActionResult CadastrarFornecedor()
        {
            return View();
        }
        public IActionResult ListarFornecedor()
        {
            return View();
        }
    }
}
