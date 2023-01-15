using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Livro
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        public DateTime? Ano { get; set; }
        [StringLength(250)]
        public string? Descricao { get; set; }
    }
}