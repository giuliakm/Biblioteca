
using Biblioteca.Consumer;
using Biblioteca.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class GenerosController : Controller
{
    // GET: GENEROS
    public ActionResult Index()
    {
        var generos = CRUD<Genero>.GetAll();
        return View(generos);
    }

    // GET: GENEROS/Details/5
    public ActionResult Details(int id)
    {
        var genero = CRUD<Genero>.GetById(id);
        if (genero == null)
        {
            return NotFound();
        }
        return View(genero);
    }

    // GET: GENEROS/Create
    public ActionResult Create()
    {
        ViewBag.Libros = GetLibros();
        return View();
    }

    // POST: GENEROS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Genero genero)
    {
        try
        {
            CRUD<Genero>.Create(genero);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(genero);
        }
    }

    // Metodo interno para obtener los 

    private List<SelectListItem> GetLibros()
    {
        var libros = CRUD<Libro>.GetAll();

        return libros.Select(p => new SelectListItem
        {
            Value = p.IdLibro.ToString(),
            Text = p.Titulo
        }).ToList();
    }

    // GET: GENEROS/Edit/5
    public ActionResult Edit(int id)
    {
        var genero = CRUD<Genero>.GetById(id);
        ViewBag.Libros = GetLibros();
        if (genero == null)
        {
            return NotFound();
        }
        return View(genero);
    }

    // POST: GENEROS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Genero genero)
    {
        try
        {
            CRUD<Genero>.Update(id, genero);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(genero);
        }
    }

    // GET: GENEROS/Delete/5
    public IActionResult Delete(int id)
    {
        var genero = CRUD<Genero>.GetById(id);
        if (genero == null)
        {
            return NotFound();
        }
        return View(genero);
    }

    // POST: GENEROS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, Genero genero)
    {
        try
        {
            CRUD<Genero>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
