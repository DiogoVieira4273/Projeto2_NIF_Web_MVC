using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto2_NIF_Web_MVC.Models;

namespace Projeto2_NIF_Web_MVC.Controllers
{
    public class NIF_EmpresaController : Controller
    {
        private readonly NIFDbContext _context;

        public NIF_EmpresaController(NIFDbContext context)
        {
            _context = context;
        }

        // GET: NIF_Empresa
        public async Task<IActionResult> Index()
        {
            return View(await _context.NIF_Empresa.ToListAsync());
        }

        // GET: NIF_Empresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nIF_Empresa = await _context.NIF_Empresa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nIF_Empresa == null)
            {
                return NotFound();
            }

            return View(nIF_Empresa);
        }

        // GET: NIF_Empresa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NIF_Empresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NIF,Name,Address,PC4,PC3,Region,County,Parish,Email,Phone,Website,Fax,Imagem_URL")] NIF_Empresa nIF_Empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nIF_Empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nIF_Empresa);
        }

        // GET: NIF_Empresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nIF_Empresa = await _context.NIF_Empresa.FindAsync(id);
            if (nIF_Empresa == null)
            {
                return NotFound();
            }
            return View(nIF_Empresa);
        }

        // POST: NIF_Empresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NIF,Name,Address,PC4,PC3,Region,County,Parish,Email,Phone,Website,Fax,Imagem_URL")] NIF_Empresa nIF_Empresa)
        {
            if (id != nIF_Empresa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nIF_Empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NIF_EmpresaExists(nIF_Empresa.ID))
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
            return View(nIF_Empresa);
        }

        // GET: NIF_Empresa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nIF_Empresa = await _context.NIF_Empresa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nIF_Empresa == null)
            {
                return NotFound();
            }

            return View(nIF_Empresa);
        }

        // POST: NIF_Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nIF_Empresa = await _context.NIF_Empresa.FindAsync(id);
            if (nIF_Empresa != null)
            {
                _context.NIF_Empresa.Remove(nIF_Empresa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NIF_EmpresaExists(int id)
        {
            return _context.NIF_Empresa.Any(e => e.ID == id);
        }
    }
}
