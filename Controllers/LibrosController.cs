using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppEF.Data;
using WebAppEF.Models;

namespace WebAppEF.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = 
                _context.Libros
                .Include(l => l.autor)
                .Include(l => l.editorial)
                .Include(l => l.genero)
                .Include(l => l.ubicacion);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.autor)
                .Include(l => l.editorial)
                .Include(l => l.genero)
                .Include(l => l.ubicacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nombre");
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "Id", "Nombre");
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nombre");
            ViewData["UbicacionId"] = new SelectList(_context.Ubicaciones, "Id", "Nombre");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Copias,GeneroId,UbicacionId,EditorialId,AutorId")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Id", libro.AutorId);
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "Id", "Id", libro.EditorialId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Id", libro.GeneroId);
            ViewData["UbicacionId"] = new SelectList(_context.Ubicaciones, "Id", "Id", libro.UbicacionId);
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nombre", libro.AutorId);
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "Id", "Nombre", libro.EditorialId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nombre", libro.GeneroId);
            ViewData["UbicacionId"] = new SelectList(_context.Ubicaciones, "Id", "Nombre", libro.UbicacionId);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Copias,GeneroId,UbicacionId,EditorialId,AutorId")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Id", libro.AutorId);
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "Id", "Id", libro.EditorialId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Id", libro.GeneroId);
            ViewData["UbicacionId"] = new SelectList(_context.Ubicaciones, "Id", "Id", libro.UbicacionId);
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.autor)
                .Include(l => l.editorial)
                .Include(l => l.genero)
                .Include(l => l.ubicacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}
