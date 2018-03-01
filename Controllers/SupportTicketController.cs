using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Foro.Models;

namespace Foro.Controllers
{
    public class SupportTicketController : Controller
    {
        private readonly MvcContext _context;

        public SupportTicketController(MvcContext context)
        {
            _context = context;
        }

        // GET: SupportTicket
        public async Task<IActionResult> Index()
        {
            var mvcContext = _context.SupportTicket.Include(s => s.Client).Include(s => s.User);
            return View(await mvcContext.ToListAsync());
        }

        // GET: SupportTicket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportTicket = await _context.SupportTicket
                .Include(s => s.Client)
                .Include(s => s.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (supportTicket == null)
            {
                return NotFound();
            }

            return View(supportTicket);
        }

        // GET: SupportTicket/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "IdentityCard");
            ViewData["UserID"] = new SelectList(_context.User, "ID", "Name");
            return View();
        }

        // POST: SupportTicket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProblemTittle,ProblemDetail,UserID,ClientID,Status")] SupportTicket supportTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "IdentityCard", supportTicket.ClientID);
            ViewData["UserID"] = new SelectList(_context.User, "ID", "Name", supportTicket.UserID);
            return View(supportTicket);
        }

        // GET: SupportTicket/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportTicket = await _context.SupportTicket.SingleOrDefaultAsync(m => m.ID == id);
            if (supportTicket == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "IdentityCard", supportTicket.ClientID);
            ViewData["UserID"] = new SelectList(_context.User, "ID", "Name", supportTicket.UserID);
            return View(supportTicket);
        }

        // POST: SupportTicket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProblemTittle,ProblemDetail,UserID,ClientID,Status")] SupportTicket supportTicket)
        {
            if (id != supportTicket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportTicketExists(supportTicket.ID))
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
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "IdentityCard", supportTicket.ClientID);
            ViewData["UserID"] = new SelectList(_context.User, "ID", "Name", supportTicket.UserID);
            return View(supportTicket);
        }

        // GET: SupportTicket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportTicket = await _context.SupportTicket
                .Include(s => s.Client)
                .Include(s => s.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (supportTicket == null)
            {
                return NotFound();
            }

            return View(supportTicket);
        }

        // POST: SupportTicket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supportTicket = await _context.SupportTicket.SingleOrDefaultAsync(m => m.ID == id);
            _context.SupportTicket.Remove(supportTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportTicketExists(int id)
        {
            return _context.SupportTicket.Any(e => e.ID == id);
        }
    }
}
