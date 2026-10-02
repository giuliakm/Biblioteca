
using Biblioteca.Consumer;
using Biblioteca.Modelos;
using Microsoft.AspNetCore.Mvc;
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
    public ActionResult Details(int idlibro)
    {
        var libro = CRUD<Libro>.GetById(idlibro);
        if (libro == null)
        {
            return NotFound();
        }
        return View(libro);
    }

    // GET: LIBROS/Create
    public ActionResult Create()
    {
        return View();
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
    public ActionResult Edit(int idlibro)
    {
        var libro = CRUD<Libro>.GetById(idlibro);
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
    public ActionResult Edit(int idlibro, Libro libro)
    {
        try
        {
            CRUD<Libro>.Update(idlibro, libro);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(libro);
        }
    }

    // GET: LIBROS/Delete/5
    public IActionResult Delete(int idlibro)
    {
        var libro = CRUD<Libro>.GetById(idlibro);
        if (libro == null)
        {
            return NotFound();
        }
        return View(libro);
    }

    // POST: LIBROS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int idlibro, Libro libro)
    {
        try
        {
            CRUD<Libro>.Delete(idlibro);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
