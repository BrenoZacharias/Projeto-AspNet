using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Loja_Sapatos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Loja_Sapatos.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}

