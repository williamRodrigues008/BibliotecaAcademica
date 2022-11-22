using BibliotecaAcademica.Data;
using BibliotecaAcademica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BibliotecaAcademica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto _contexto;

        public HomeController(ILogger<HomeController> logger, Contexto contexto)
        {
            _logger = logger;
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var livros = _contexto.Livros.ToList();
            foreach (var livro in livros)
            {
                if (string.IsNullOrEmpty(livro.Capa))
                {
                    livro.Capa = "semCapa";
                }
            }
            return View(livros.ToList());
        }

        [HttpPost]
        public IActionResult DetalhesDoLivro(int id)
        {
            return PartialView(_contexto.Livros.ToList().Where(x =>x.IdLivro == id));
        }

        public IActionResult AdicionarLivro()
        {
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}