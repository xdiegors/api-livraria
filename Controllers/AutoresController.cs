using Livraria.Data;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly DataContext _context;

        public AutoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            var Autores = _context.Autores.AsNoTracking().ToList();
            if (Autores is null)
            {
                return NotFound("Nenhum autor encontrado");
            }
            return Autores;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Autor> Get(int id)
        {
            var autor = _context.Autores.AsNoTracking().FirstOrDefault(autor => autor.Id == id);
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
            _context.Autores.Add(autor);
            _context.SaveChanges();
            return Ok(autor);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            _context.Autores.Update(autor);
            _context.SaveChanges();
            return Ok(autor);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var autor = _context.Autores.FirstOrDefault(autor => autor.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            _context.Autores.Remove(autor);
            _context.SaveChanges();

            return Ok(autor);
        }
    }
}