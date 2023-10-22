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
        public static string CPF_Funcionario_Logado { get; set; }
        public static string Nome_Funcionario_Logado { get; set; }
        public static string Cargo_Funcionario_Logado { get; set; }

        public HomeController(ILogger<HomeController> logger, Banco_Folha_Pagamento_Ataron_Contexto contexto)
        {
            _logger = logger;
            _contexto = contexto;
        }

        // método para zerar as variáveis estáticas
        public void Resetar_Variaveis()
        {
            CPF_Funcionario_Logado = null;
            Nome_Funcionario_Logado = null;
            Cargo_Funcionario_Logado = null;
        }

        [HttpGet]
        public IActionResult index()
        {
            Resetar_Variaveis();
            Funcionario_Login _funcionario_login = new Funcionario_Login();
            return View(_funcionario_login);
        }

        /* verificar se existe um cpf e senha iguais no banco de dados ao que foi digitado na tela, 
        também vai salvar o nome e o cargo do funcionário para mostrar na tela de menu se o login for bem sucedido */
        [HttpPost]
        public IActionResult index(Funcionario_Login _funcionario_login)
        {
            var login_funcionario = _contexto.Funcionario.Where(funcionario => funcionario.CPF == _funcionario_login.CPF && funcionario.Senha == _funcionario_login.Senha).FirstOrDefault();

            if (login_funcionario == null)
            {
                ViewBag.login_funcionario = 0;
            }

            else
            {
                CPF_Funcionario_Logado = _funcionario_login.CPF;
                Nome_Funcionario_Logado = login_funcionario.Nome;

                var contrato_funcionario = _contexto.Contrato_Empresa.FirstOrDefault(contrato_empresa => contrato_empresa.CPF == CPF_Funcionario_Logado);

                if (contrato_funcionario != null)
                {
                    Cargo_Funcionario_Logado = contrato_funcionario.Cargo;
                }

                return RedirectToAction("Menu", "Home");
            }

            return View(_funcionario_login);
        }

        // exibir o nome e o cargo do funcionário
        public IActionResult Menu()
        {
            ViewBag.nome_funcionario_logado = Nome_Funcionario_Logado;
            ViewBag.cargo_funcionario_logado = Cargo_Funcionario_Logado;
            return View();
        }

        // se clicar no botão de sair da conta, zera as variáveis estáticas e retorna a tela inicial
        public IActionResult Voltar_Inicio()
        {
            Resetar_Variaveis();
            return RedirectToAction("index", "Home");
        }

        // exibir as folhas de pagamento de acordo com o funcionário que fez o login
        public IActionResult Visualizar_Folhas_Pagamento()
        {
            var folhas_de_pagamento_funcionario = _contexto.Folha_Pagamento.Where(folha_pagamento => folha_pagamento.CPF == CPF_Funcionario_Logado).ToList();

            return View(folhas_de_pagamento_funcionario);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}