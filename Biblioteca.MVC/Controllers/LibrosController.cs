
using Biblioteca.Consumer;
using Biblioteca.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class LibrosController : Controller
{
    // GET: LIBROS
    public ActionResult Index()
    {
        var libros = CRUD<Libro>.GetAll();
        return View(libros);
    }

    // GET: LIBROS/Details/5
    public ActionResult Details(int id)
    {
        var libro = CRUD<Libro>.GetById(id);
        if (libro == null)
        {
            return NotFound();
        }
        return View(libro);
    }

    // GET: LIBROS/Create
    public ActionResult Create()
    {
        ViewBag.Autores = GetAutores();
        ViewBag.Generos = GetGeneros();
        ViewBag.Editoriales = GetEditoriales();
        return View();
    }

    // metodos para extaer autores, generos y editoriales

    private List<SelectListItem> GetAutores()
    {
        var autores = CRUD<Autor>.GetAll();

        return autores.Select(a => new SelectListItem
        {
            Value = a.IdAutor.ToString(),
            Text = a.Nombre + " " + a.Apellido
        }).ToList();
    }

    private List<SelectListItem> GetGeneros()
    {
        var generos = CRUD<Genero>.GetAll();

        return generos.Select(g => new SelectListItem
        {
            Value = g.IdGenero.ToString(),
            Text = g.Nombre
        }).ToList();
    }

    private List<SelectListItem> GetEditoriales()
    {
        var editoriales = CRUD<Editorial>.GetAll();

        return editoriales.Select(e => new SelectListItem
        {
            Value = e.IdEditorial.ToString(),
            Text = e.Nombre
        }).ToList();
    }

    // POST: LIBROS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Libro libro)
    {
        try
        {
            CRUD<Libro>.Create(libro);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(libro);
        }
    }

    // GET: LIBROS/Edit/5
    public ActionResult Edit(int id)
    {
        var libro = CRUD<Libro>.GetById(id);
        if (libro == null)
        {
            return NotFound();
        }
        return View(libro);
    }

    // POST: LIBROS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Libro libro)
    {
        try
        {
            CRUD<Libro>.Update(id, libro);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(libro);
        }
    }

    // GET: LIBROS/Delete/5
    public IActionResult Delete(int id)
    {
        var libro = CRUD<Libro>.GetById(id);
        ViewBag.Autores = GetAutores();
        ViewBag.Generos = GetGeneros();
        ViewBag.Editoriales = GetEditoriales();
        if (libro == null)
        {
            return NotFound();
        }
        return View(libro);
    }

    // POST: LIBROS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, Libro libro)
    {
        try
        {
            CRUD<Libro>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
