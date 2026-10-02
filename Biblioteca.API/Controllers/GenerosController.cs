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

    // GET: api/Genero
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Genero>>> GetGenero()
    {
        return await _context.Generos.ToListAsync();
    }

    // GET: api/Genero/5
    [HttpGet("{idgenero}")]
    public async Task<ActionResult<Genero>> GetGenero(int idgenero)
    {
        var genero = await _context.Generos.FindAsync(idgenero);

        if (genero == null)
        {
            return NotFound();
        }

        return genero;
    }

    // PUT: api/Genero/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idgenero}")]
    public async Task<IActionResult> PutGenero(int? idgenero, Genero genero)
    {
        if (idgenero != genero.IdGenero)
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
            if (!GeneroExists(idgenero))
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

    // POST: api/Genero
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Genero>> PostGenero(Genero genero)
    {
        _context.Generos.Add(genero);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetGenero", new { idgenero = genero.IdGenero }, genero);
    }

    // DELETE: api/Genero/5
    [HttpDelete("{idgenero}")]
    public async Task<IActionResult> DeleteGenero(int? idgenero)
    {
        var genero = await _context.Generos.FindAsync(idgenero);
        if (genero == null)
        {
            return NotFound();
        }

        _context.Generos.Remove(genero);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GeneroExists(int? idgenero)
    {
        return _context.Generos.Any(e => e.IdGenero == idgenero);
    }
}
