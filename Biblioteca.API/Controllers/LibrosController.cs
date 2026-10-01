using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Modelos;

[Route("api/[controller]")]
[ApiController]
public class LibrosController : ControllerBase
{
    private readonly BibliotecaAPIContext _context;
    public LibrosController(BibliotecaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Libro
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Libro>>> GetLibro()
    {
        return await _context.Libro.ToListAsync();
    }

    // GET: api/Libro/5
    [HttpGet("{idlibro}")]
    public async Task<ActionResult<Libro>> GetLibro(int idlibro)
    {
        var libro = await _context.Libro.FindAsync(idlibro);

        if (libro == null)
        {
            return NotFound();
        }

        return libro;
    }

    // PUT: api/Libro/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idlibro}")]
    public async Task<IActionResult> PutLibro(int? idlibro, Libro libro)
    {
        if (idlibro != libro.IdLibro)
        {
            return BadRequest();
        }

        _context.Entry(libro).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LibroExists(idlibro))
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

    // POST: api/Libro
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Libro>> PostLibro(Libro libro)
    {
        _context.Libro.Add(libro);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetLibro", new { idlibro = libro.IdLibro }, libro);
    }

    // DELETE: api/Libro/5
    [HttpDelete("{idlibro}")]
    public async Task<IActionResult> DeleteLibro(int? idlibro)
    {
        var libro = await _context.Libro.FindAsync(idlibro);
        if (libro == null)
        {
            return NotFound();
        }

        _context.Libro.Remove(libro);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LibroExists(int? idlibro)
    {
        return _context.Libro.Any(e => e.IdLibro == idlibro);
    }
}
