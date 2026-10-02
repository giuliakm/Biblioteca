using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Modelos;

[Route("api/[controller]")]
[ApiController]
public class GenerosController : ControllerBase
{
    private readonly BibliotecaAPIContext _context;

    public GenerosController(BibliotecaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Generos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Genero>>> GetGenero()
    {
        var generos = await _context.Generos
            .Include(g => g.Libros)
            .ToListAsync();

        return generos;
    }

    // GET: api/Generos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Genero>> GetGenero(int id)
    {
        var genero = await _context.Generos
            .Include(g => g.Libros)
            .FirstOrDefaultAsync(g => g.IdGenero == id);

        if (genero == null)
        {
            return NotFound();
        }

        return genero;
    }

    // PUT: api/Generos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGenero(int id, Genero genero)
    {
        if (id != genero.IdGenero)
        {
            return BadRequest();
        }

        _context.Entry(genero).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GeneroExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Generos
    [HttpPost]
    public async Task<ActionResult<Genero>> PostGenero(Genero genero)
    {
        _context.Generos.Add(genero);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            "GetGenero",
            new { id = genero.IdGenero },
            genero
        );
    }

    // DELETE: api/Generos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGenero(int id)
    {
        var genero = await _context.Generos.FindAsync(id);

        if (genero == null)
        {
            return NotFound();
        }

        _context.Generos.Remove(genero);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GeneroExists(int id)
    {
        return _context.Generos.Any(e => e.IdGenero == id);
    }
}
