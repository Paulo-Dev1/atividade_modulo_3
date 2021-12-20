using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Flyturismo.Data;
using Flyturismo.Models;

namespace Flyturismo.Controllers
{
    public class HospedagemController : Controller
    {
        private readonly TurismoContext _context;

        public HospedagemController(TurismoContext context)
        {
            _context = context;
        }

        // GET: Hospedagem
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hospedagens.ToListAsync());
        }

        // GET: Hospedagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospedagem = await _context.Hospedagens
                .FirstOrDefaultAsync(m => m.Id_Hospedagem == id);
            if (hospedagem == null)
            {
                return NotFound();
            }

            return View(hospedagem);
        }

        // GET: Hospedagem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hospedagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Hospedagem,Tipo_Hospedagem,Data_Entrada,Data_Saida")] Hospedagem hospedagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospedagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospedagem);
        }

        // GET: Hospedagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospedagem = await _context.Hospedagens.FindAsync(id);
            if (hospedagem == null)
            {
                return NotFound();
            }
            return View(hospedagem);
        }

        // POST: Hospedagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Hospedagem,Tipo_Hospedagem,Data_Entrada,Data_Saida")] Hospedagem hospedagem)
        {
            if (id != hospedagem.Id_Hospedagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospedagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospedagemExists(hospedagem.Id_Hospedagem))
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
            return View(hospedagem);
        }

        // GET: Hospedagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospedagem = await _context.Hospedagens
                .FirstOrDefaultAsync(m => m.Id_Hospedagem == id);
            if (hospedagem == null)
            {
                return NotFound();
            }

            return View(hospedagem);
        }

        // POST: Hospedagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hospedagem = await _context.Hospedagens.FindAsync(id);
            _context.Hospedagens.Remove(hospedagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospedagemExists(int id)
        {
            return _context.Hospedagens.Any(e => e.Id_Hospedagem == id);
        }
    }
}
