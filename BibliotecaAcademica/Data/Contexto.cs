using BibliotecaAcademica.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAcademica.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options){}

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
