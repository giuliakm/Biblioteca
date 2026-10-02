using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Modelos;

[Route("api/[controller]")]
[ApiController]
public class AutoresController : ControllerBase
{
    private readonly BibliotecaAPIContext _context;
    public AutoresController(BibliotecaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Autor
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Autor>>> GetAutor()
    {
        return await _context.Autores.ToListAsync();
    }

    // GET: api/Autor/5
    [HttpGet("{idautor}")]
    public async Task<ActionResult<Autor>> GetAutor(int idautor)
    {
        var autor = await _context.Autores.FindAsync(idautor);

        if (autor == null)
        {
            return NotFound();
        }

        return autor;
    }

    // PUT: api/Autor/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idautor}")]
    public async Task<IActionResult> PutAutor(int? idautor, Autor autor)
    {
        if (idautor != autor.IdAutor)
        {
            return BadRequest();
        }

        _context.Entry(autor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AutorExists(idautor))
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

    // POST: api/Autor
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Autor>> PostAutor(Autor autor)
    {
        _context.Autores.Add(autor);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAutor", new { idautor = autor.IdAutor }, autor);
    }

    // DELETE: api/Autor/5
    [HttpDelete("{idautor}")]
    public async Task<IActionResult> DeleteAutor(int? idautor)
    {
        var autor = await _context.Autores.FindAsync(idautor);
        if (autor == null)
        {
            return NotFound();
        }

        _context.Autores.Remove(autor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AutorExists(int? idautor)
    {
        return _context.Autores.Any(e => e.IdAutor == idautor);
    }
}
