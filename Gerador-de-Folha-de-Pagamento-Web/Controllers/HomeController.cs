using Gerador_de_Folha_de_Pagamento_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gerador_de_Folha_de_Pagamento_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Banco_Folha_Pagamento_Ataron_Contexto _contexto;

        public HomeController(ILogger<HomeController> logger, Banco_Folha_Pagamento_Ataron_Contexto contexto)
        {
            _logger = logger;
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult index()
        {
            Funcionario_Login _funcionario_login = new Funcionario_Login();
            return View(_funcionario_login);
        }

        [HttpPost]
        public IActionResult index(Funcionario_Login _funcionario_login)
        {
            var login = _contexto.Funcionario.Where(funcionario => funcionario.CPF == _funcionario_login.CPF && funcionario.Senha == _funcionario_login.Senha).FirstOrDefault();

            if (login == null)
            {
                ViewBag.LoginStatus = 0;
            }

            else
            {
                return RedirectToAction("Menu", "Home");
            }

            return View(_funcionario_login);
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult Visualizar_Folhas_Pagamento()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}