
using Biblioteca.Consumer;
using Biblioteca.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EditorialesController : Controller
{
    // GET: EDITORIALES
    public ActionResult Index()
    {
        var editoriales = CRUD<Editorial>.GetAll();
        return View(editoriales);
    }

    // GET: EDITORIALES/Details/5
    public ActionResult Details(int id)
    {
        var editorial = CRUD<Editorial>.GetById(id);
        if (editorial == null)
        {
            return NotFound();
        }
        return View(editorial);
    }

    // GET: EDITORIALES/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: EDITORIALES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Editorial editorial)
    {
        try
        {
            CRUD<Editorial>.Create(editorial);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(editorial);
        }
    }

    // GET: EDITORIALES/Edit/5
    public ActionResult Edit(int id)
    {
        var editorial = CRUD<Editorial>.GetById(id);
        if (editorial == null)
        {
            return NotFound();
        }
        return View(editorial);
    }

    // POST: EDITORIALES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Editorial editorial)
    {
        try
        {
            CRUD<Editorial>.Update(id, editorial);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(editorial);
        }
    }

    // GET: EDITORIALES/Delete/5
    public IActionResult Delete(int id)
    {
        var editorial = CRUD<Editorial>.GetById(id);
        if (editorial == null)
        {
            return NotFound();
        }
        return View(editorial);
    }

    // POST: EDITORIALES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, Editorial editorial)
    {
        try
        {
            CRUD<Editorial>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
