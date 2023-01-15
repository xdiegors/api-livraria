using Livraria.Data;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly DataContext _context;

        public LivrosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Livro>> Get()
        {
            var livros = _context.Livros.AsNoTracking().ToList();
            if (livros is null)
            {
                return NotFound("Nenhum livro encontrado");
            }
            return livros;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Livro> Get(int id)
        {
            var livro = _context.Livros.AsNoTracking().FirstOrDefault(livro => livro.Id == id);
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
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return Ok(livro);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            _context.Livros.Update(livro);
            _context.SaveChanges();
            return Ok(livro);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro == null)
            {
                return NotFound();
            }
            _context.Livros.Remove(livro);
            _context.SaveChanges();

            return Ok(livro);
        }
    }
}