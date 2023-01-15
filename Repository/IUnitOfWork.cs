using Livraria.Models;

namespace Livraria.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Livro> LivroRepository { get; }
        IRepository<Categoria> CategoriaRepository { get; }
        IRepository<Autor> AutorRepository { get; }
        void Commit();
    }
}