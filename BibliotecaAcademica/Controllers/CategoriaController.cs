using BibliotecaAcademica.Data;
using BibliotecaAcademica.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAcademica.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly Contexto _contexto;

        public CategoriaController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return View(_contexto.Categorias.ToList());
        }

        [HttpPost]
        public IActionResult LivrosPorCategoria(string categoria)
        {
            var livros = _contexto.Livros;
            var lista = new List<Livro>();
            foreach (var livro in livros)
            {
                if (string.IsNullOrEmpty(livro.Capa))
                {
                    livro.Capa = "semCapa";
                }
            }
            var filtro = livros.Where(l => l.Genero == categoria);
            foreach (var item in filtro)
            {
                lista.Add(item);
            }
            return View(lista);
        }

    }
}
