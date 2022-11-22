using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAcademica.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
    }
}
