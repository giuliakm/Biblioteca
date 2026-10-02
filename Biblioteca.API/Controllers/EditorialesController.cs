using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Modelos;

[Route("api/[controller]")]
[ApiController]
public class EditorialesController : ControllerBase
{
    private readonly BibliotecaAPIContext _context;
    public EditorialesController(BibliotecaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Editorial
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Editorial>>> GetEditorial()
    {
        var editoriales = await _context.Editoriales
            .Include(g => g.Libros)
            .ToListAsync();

        return editoriales;
    }

    // GET: api/Editorial/5
    [HttpGet("{ideditorial}")]
    public async Task<ActionResult<Editorial>> GetEditorial(int ideditorial)
    {
        var editorial = await _context.Editoriales
            .Include(g => g.Libros).
            FirstOrDefaultAsync(a => a.IdEditorial == ideditorial);

        if (editorial == null)
        {
            return NotFound();
        }

        return editorial;
    }

    // PUT: api/Editorial/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{ideditorial}")]
    public async Task<IActionResult> PutEditorial(int? ideditorial, Editorial editorial)
    {
        if (ideditorial != editorial.IdEditorial)
        {
            return BadRequest();
        }

        _context.Entry(editorial).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EditorialExists(ideditorial))
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

    // POST: api/Editorial
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Editorial>> PostEditorial(Editorial editorial)
    {
        _context.Editoriales.Add(editorial);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEditorial", new { ideditorial = editorial.IdEditorial }, editorial);
    }

    // DELETE: api/Editorial/5
    [HttpDelete("{ideditorial}")]
    public async Task<IActionResult> DeleteEditorial(int? ideditorial)
    {
        var editorial = await _context.Editoriales.FindAsync(ideditorial);
        if (editorial == null)
        {
            return NotFound();
        }

        _context.Editoriales.Remove(editorial);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EditorialExists(int? ideditorial)
    {
        return _context.Editoriales.Any(e => e.IdEditorial == ideditorial);
    }
}
