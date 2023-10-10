using Gerador_de_Folha_de_Pagamento_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gerador_de_Folha_de_Pagamento_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Redefinir_Senha()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult Visualizar_Funcionario()
        {
            return View();
        }

        public IActionResult Visualizar_Folhas_de_Pagamento()
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