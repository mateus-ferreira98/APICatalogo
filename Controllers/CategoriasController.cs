using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> ListarCategoriaProduto()
        {
            try
            {
                return _context.Categorias!.Include(p => p.Produtos).Where(c => c.Id <= 5).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                      "Ocorreu um problema ao tratar a sua solicitação.");
            }
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Listar()
        {
            return _context.Categorias!.AsNoTracking().ToList();
        }

        [HttpGet("id{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> ObterPorId(int id)
        {
            try
            {
                var categoria = _context.Categorias!.AsNoTracking().FirstOrDefault(c => c.Id == id);
                if (categoria is null)
                {
                    return NotFound($"Categoria com id = {id} não encontrada...");
                }
                return categoria;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                      "Ocorreu um problema ao tratar a sua solicitação.");
            }
            
        }

        [HttpPost]
        public ActionResult Criar(Categoria categoria)
        {
            if (categoria is null)
                return BadRequest("Dados inválidos");

            _context.Categorias!.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.Id }, categoria);

        }

        [HttpPut("{id:int}")]
        public ActionResult Atualizar(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest("Dados inválidos");
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias!.FirstOrDefault(p => p.Id == id);

            if (categoria is null)
                return NotFound("Categoria não localizada...");

            _context.Categorias!.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }


    }
}
