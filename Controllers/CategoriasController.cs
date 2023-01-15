using Livraria.Data;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var Categorias = _context.Categorias.AsNoTracking().ToList();
            if (Categorias is null)
            {
                return NotFound("Nenhuma categoria encontrado");
            }
            return Categorias;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(categoria => categoria.Id == id);
            if (categoria is null)
            {
                return NotFound("Categoria não encontrada");
            }
            return categoria;
        }
        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest();
            }
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            _context.Categorias.Update(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
    }
}