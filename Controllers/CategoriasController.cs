using Livraria.Models;
using Livraria.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public CategoriasController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var Categorias = _context.CategoriaRepository.Get().ToList();
            if (Categorias is null)
            {
                return NotFound("Nenhuma categoria encontrado");
            }
            return Categorias;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.CategoriaRepository.Get().FirstOrDefault(categoria => categoria.Id == id);
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
            _context.CategoriaRepository.Add(categoria);
            _context.Commit();
            return Ok(categoria);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            _context.CategoriaRepository.Update(categoria);
            _context.Commit();
            return Ok(categoria);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.CategoriaRepository.GetById(categoria => categoria.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.CategoriaRepository.Delete(categoria);
            _context.Commit();

            return Ok(categoria);
        }
    }
}