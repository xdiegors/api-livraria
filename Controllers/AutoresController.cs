using Livraria.Models;
using Livraria.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public AutoresController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            var Autores = _context.AutorRepository.Get().ToList();
            if (Autores is null)
            {
                return NotFound("Nenhum autor encontrado");
            }
            return Autores;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Autor> Get(int id)
        {
            var autor = _context.AutorRepository.GetById(autor => autor.Id == id);
            if (autor is null)
            {
                return NotFound("Autor não encontrado");
            }
            return autor;
        }
        [HttpPost]
        public ActionResult Post(Autor autor)
        {
            if (autor is null)
            {
                return BadRequest();
            }
            _context.AutorRepository.Add(autor);
            _context.Commit();
            return Ok(autor);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            _context.AutorRepository.Update(autor);
            _context.Commit();
            return Ok(autor);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var autor = _context.AutorRepository.GetById(autor => autor.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            _context.AutorRepository.Delete(autor);
            _context.Commit();

            return Ok(autor);
        }
    }
}