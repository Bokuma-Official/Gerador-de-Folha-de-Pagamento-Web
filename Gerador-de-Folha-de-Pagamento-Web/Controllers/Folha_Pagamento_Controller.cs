using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gerador_de_Folha_de_Pagamento_Web.Models;
using Gerador_de_Folha_de_Pagamento_Web.Banco_Dados;

namespace Gerador_de_Folha_de_Pagamento_Web.Controllers
{
    public class Folha_Pagamento_Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Folha_Pagamento_Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Folhas_Pagamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Folha_Pagamento.ToListAsync());
        }
    }
}