using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gerador_de_Folha_de_Pagamento_Web.Banco_Dados;
using Gerador_de_Folha_de_Pagamento_Web.Models;

namespace Gerador_de_Folha_de_Pagamento_Web.Controllers
{
    public class Funcionario_Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Funcionario_Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionario.ToListAsync());
        }
    }
}