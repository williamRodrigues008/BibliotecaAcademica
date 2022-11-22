using BibliotecaAcademica.Data;
using BibliotecaAcademica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.SqlTypes;
using System.Globalization;

namespace BibliotecaAcademica.Controllers
{
    public class LivrosController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Contexto _contexto;

        private string Caminho { get; set; }

        public LivrosController(IWebHostEnvironment webHostEnvironment, Contexto contexto)
        {
            _webHostEnvironment = webHostEnvironment;
            _contexto = contexto;
            Caminho = webHostEnvironment.WebRootPath;
        }

        [HttpPost]
        public IActionResult AdicionarLivro(IFormFile capa, IFormFile livro,
            string titulo, string autor, string genero, DateTime lancamento)
        {
            try
            {
                if ((livro != null) || (autor != null))
                {
                    var tituloFormatado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(titulo);
                    var nomeCapa = string.Empty;
                    if (capa != null)
                    {
                        nomeCapa = capa.FileName;
                    }
                    var nomeLivro = tituloFormatado.Replace(" ", "_") + ".pdf";
                    var pastaServidor = Caminho + "/Livros/" + tituloFormatado.Replace(" ", "_") + "/";

                    SalvarCapaNoServidor(capa, pastaServidor, nomeCapa);
                    SalvarLivroNoServidor(livro, pastaServidor, nomeLivro);
                    PersistirLivroNoBancoDeDados(pastaServidor, nomeCapa, tituloFormatado, genero, autor, lancamento, nomeLivro);
                }
            }
            catch (SqlNullValueException)
            {
                throw new NullReferenceException("Os campos do arquivo e autor são de preenchimentos obrigatórios");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LerLivro(int id)
        {
            return View(_contexto.Livros.ToList().Where(x => x.IdLivro == id));
        }

        private void PersistirLivroNoBancoDeDados(string pastaServidor, string nomeArquivo, string titulo, string genero, string autor, DateTime lancamento, string nomeLivro)
        {
            using (var contexto = _contexto)
            {

                Livro livro = new()
                {
                    Titulo = titulo,
                    Capa = nomeArquivo,
                    Lancamento = lancamento,
                    Caminho = nomeLivro,
                    Genero = genero,
                    Autor = autor
                };

                if (livro != null)
                {
                    contexto.Livros.Add(livro);
                    contexto.SaveChanges();
                }

            }
        }

        private void SalvarCapaNoServidor(IFormFile capa, string pastaServidor, string nomeCapa)
        {
            if (!Directory.Exists(pastaServidor))
            {
                Directory.CreateDirectory(pastaServidor);
            }
            if (capa != null)
            {
                using (var arquivo = System.IO.File.Create(pastaServidor + nomeCapa))
                {
                    capa.CopyToAsync(arquivo);
                }
            }
        }

        public void SalvarLivroNoServidor(IFormFile livro, string pastaServidor, string nomeLivro)
        {
            if (!Directory.Exists(pastaServidor))
            {
                Directory.CreateDirectory(pastaServidor);
            }

            using (var arquivo = System.IO.File.Create(pastaServidor + nomeLivro))
            {
                livro.CopyToAsync(arquivo);
            }
        }
    }
}
