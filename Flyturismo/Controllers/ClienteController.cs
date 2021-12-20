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
    public class ClienteController : Controller
    {
        private readonly TurismoContext _context;

        public ClienteController(TurismoContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            

            //--------------------------------------------------------------------------

            var turismoContext = _context.Clientes.Include(c => c.Destino).Include(c => c.Hospedagem);
            return View(await turismoContext.ToListAsync());
        }

       
        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Destino)
                .Include(c => c.Hospedagem)
                .FirstOrDefaultAsync(m => m.Id_Cliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            ViewData["DestinoId_destino"] = new SelectList(_context.Destinos, "Id_Destino", "Cidade");
            ViewData["HospedagemId_hospedagem"] = new SelectList(_context.Hospedagens, "Id_Hospedagem", "Data_Entrada");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Cliente,Nome,Idade,CPF,Telefone,Endereco,DestinoId_destino,HospedagemId_hospedagem")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinoId_destino"] = new SelectList(_context.Destinos, "Id_Destino", "Cidade", cliente.DestinoId_destino);
            ViewData["HospedagemId_hospedagem"] = new SelectList(_context.Hospedagens, "Id_Hospedagem", "Data_Entrada", cliente.HospedagemId_hospedagem);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["DestinoId_destino"] = new SelectList(_context.Destinos, "Id_Destino", "Cidade", cliente.DestinoId_destino);
            ViewData["HospedagemId_hospedagem"] = new SelectList(_context.Hospedagens, "Id_Hospedagem", "Data_Entrada", cliente.HospedagemId_hospedagem);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Cliente,Nome,Idade,CPF,Telefone,Endereco,DestinoId_destino,HospedagemId_hospedagem")] Cliente cliente)
        {
            if (id != cliente.Id_Cliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id_Cliente))
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
            ViewData["DestinoId_destino"] = new SelectList(_context.Destinos, "Id_Destino", "Cidade", cliente.DestinoId_destino);
            ViewData["HospedagemId_hospedagem"] = new SelectList(_context.Hospedagens, "Id_Hospedagem", "Data_Entrada", cliente.HospedagemId_hospedagem);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Destino)
                .Include(c => c.Hospedagem)
                .FirstOrDefaultAsync(m => m.Id_Cliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id_Cliente == id);
        }
    }
}
