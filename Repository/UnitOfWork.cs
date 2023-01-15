using Livraria.Data;
using Livraria.Models;

namespace Livraria.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext _context;
        private Repository<Livro> _livroRepository;
        private Repository<Categoria> _categoriaRepository;
        private Repository<Autor> _autorRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IRepository<Livro> LivroRepository
        {
            get
            {
                if (_livroRepository == null)
                {
                    _livroRepository = new Repository<Livro>(_context);
                }
                return _livroRepository;
            }

        }
        public IRepository<Categoria> CategoriaRepository
        {
            get
            {
                if (_categoriaRepository == null)
                {
                    _categoriaRepository = new Repository<Categoria>(_context);
                }
                return _categoriaRepository;
            }

        }
        public IRepository<Autor> AutorRepository
        {
            get
            {
                if (_autorRepository == null)
                {
                    _autorRepository = new Repository<Autor>(_context);
                }
                return _autorRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}