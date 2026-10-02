
using Biblioteca.Consumer;
using Biblioteca.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class GenerosController : Controller
{
    // GET: GENEROS
    public ActionResult Index()
    {
        var generos = CRUD<Genero>.GetAll();
        return View(generos);
    }

    // GET: GENEROS/Details/5
    public ActionResult Details(int idgenero)
    {
        var genero = CRUD<Genero>.GetById(idgenero);
        if (genero == null)
        {
            return NotFound();
        }
        return View(genero);
    }

    // GET: GENEROS/Create
    public ActionResult Create()
    {
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

    // GET: GENEROS/Edit/5
    public ActionResult Edit(int idgenero)
    {
        var genero = CRUD<Genero>.GetById(idgenero);
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
    public ActionResult Edit(int idgenero, Genero genero)
    {
        try
        {
            CRUD<Genero>.Update(idgenero, genero);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(genero);
        }
    }

    // GET: GENEROS/Delete/5
    public IActionResult Delete(int idgenero)
    {
        var genero = CRUD<Genero>.GetById(idgenero);
        if (genero == null)
        {
            return NotFound();
        }
        return View(genero);
    }

    // POST: GENEROS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int idgenero, Genero genero)
    {
        try
        {
            CRUD<Genero>.Delete(idgenero);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
