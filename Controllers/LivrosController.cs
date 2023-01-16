using Livraria.Models;
using Livraria.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public LivrosController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Livro>> Get()
        {
            var livros = _context.LivroRepository.Get().ToList();
            if (livros is null)
            {
                return NotFound("Nenhum livro encontrado");
            }
            return livros;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Livro> Get(int id)
        {
            var livro = _context.LivroRepository.GetById(livro => livro.Id == id);
            if (livro is null)
            {
                return NotFound("Livro não encontrado");
            }
            return livro;
        }
        [HttpPost]
        public ActionResult Post(Livro livro)
        {
            if (livro is null)
            {
                return BadRequest();
            }
            _context.LivroRepository.Add(livro);
            _context.Commit();
            return Ok(livro);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            _context.LivroRepository.Update(livro);
            _context.Commit();
            return Ok(livro);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var livro = _context.LivroRepository.GetById(livro => livro.Id == id);
            if (livro == null)
            {
                return NotFound();
            }
            _context.LivroRepository.Delete(livro);
            _context.Commit();

            return Ok(livro);
        }
    }
}