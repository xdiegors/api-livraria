using Livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Livro>? Livros { get; set; }

        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Autor>? Autores { get; set; }
    }
}

