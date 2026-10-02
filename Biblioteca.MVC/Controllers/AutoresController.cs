
using Biblioteca.Modelos;
using Biblioteca.Consumer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

public class AutoresController : Controller
{
    // GET: AUTORES
    public ActionResult Index()
    {
        var autores = CRUD<Autor>.GetAll();
        return View(autores);
    }

    // GET: AUTORES/Details/5
    public ActionResult Details(int id)
    {
        var autor = CRUD<Autor>.GetById(id);
        if (autor == null)
        {
            return NotFound();
        }
        return View(autor);
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
    // GET: AUTORES/Create
    public ActionResult Create()
    {
        ViewBag.Libros = GetLibros();
        return View();
    }



    // POST: AUTORES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Autor autor)
    {
        try
        {
            CRUD<Autor>.Create(autor);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(autor);
        }
    }

    // GET: AUTORES/Edit/5
    public ActionResult Edit(int id)
    {
        var autor = CRUD<Autor>.GetById(id);
        ViewBag.Libros = GetLibros();
        if (autor == null)
        {
            return NotFound();
        }
        return View(autor);
    }

    // POST: AUTORES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Autor autor)
    {
        try
        {
            CRUD<Autor>.Update(id, autor);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(autor);
        }
    }

    // GET: AUTORES/Delete/5
    public IActionResult Delete(int id)
    {
        var autor = CRUD<Autor>.GetById(id);
        if (autor == null)
        {
            return NotFound();
        }
        return View(autor);
    }

    
}
