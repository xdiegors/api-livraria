using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Livraria.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        [JsonIgnore]
        public ICollection<Livro>? Livros { get; set; }
    }
}