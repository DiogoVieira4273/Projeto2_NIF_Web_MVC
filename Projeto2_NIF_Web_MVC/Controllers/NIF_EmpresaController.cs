
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto2_NIF_Web_MVC.Models;

public class NIF_EmpresaController : Controller
{
    private readonly NIFDbContext _context;

    public NIF_EmpresaController(NIFDbContext context)
    {
        _context = context;
    }

    // GET: NIF_EMPRESAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.NIF_Empresa.ToListAsync());
    }

    // GET: NIF_EMPRESAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nif_empresa = await _context.NIF_Empresa
            .FirstOrDefaultAsync(m => m.ID == id);
        if (nif_empresa == null)
        {
            return NotFound();
        }

        return View(nif_empresa);
    }

    // GET: NIF_EMPRESAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: NIF_EMPRESAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,NIF,Name,Address,PC4,PC3,Region,County,Parish,Email,Phone,Website,Fax,Imagem_URL")] NIF_Empresa nif_empresa)
    {
        if (ModelState.IsValid)
        {
            _context.Add(nif_empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(nif_empresa);
    }

    // GET: NIF_EMPRESAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nif_empresa = await _context.NIF_Empresa.FindAsync(id);
        if (nif_empresa == null)
        {
            return NotFound();
        }
        return View(nif_empresa);
    }

    // POST: NIF_EMPRESAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("ID,NIF,Name,Address,PC4,PC3,Region,County,Parish,Email,Phone,Website,Fax,Imagem_URL")] NIF_Empresa nif_empresa)
    {
        if (id != nif_empresa.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(nif_empresa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NIF_EmpresaExists(nif_empresa.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(nif_empresa);
    }

    // GET: NIF_EMPRESAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nif_empresa = await _context.NIF_Empresa
            .FirstOrDefaultAsync(m => m.ID == id);
        if (nif_empresa == null)
        {
            return NotFound();
        }

        return View(nif_empresa);
    }

    // POST: NIF_EMPRESAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var nif_empresa = await _context.NIF_Empresa.FindAsync(id);
        if (nif_empresa != null)
        {
            _context.NIF_Empresa.Remove(nif_empresa);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool NIF_EmpresaExists(int? id)
    {
        return _context.NIF_Empresa.Any(e => e.ID == id);
    }
}
