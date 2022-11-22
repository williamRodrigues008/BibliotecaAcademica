using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAcademica.Models
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public int IdLivro { get; set; }

        [Required(ErrorMessage = "O Titulo do Livro é obrigatório")]
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public DateTime Lancamento { get; set; }

        [Required(ErrorMessage = "O Arquivo do Livro é obrigatório")]
        public string Caminho { get; set; }
        public string Capa { get; set; }
    }
}
