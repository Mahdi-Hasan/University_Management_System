using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UMS.Data;
using UMS.Models;

namespace UMS.Controllers
{
    public class CourseRegistrationsController : Controller
    {
        private readonly UMSContext _context;

        public CourseRegistrationsController(UMSContext context)
        {
            _context = context;
        }

        // GET: CourseRegistrations
        public async Task<IActionResult> Index()
        {
            var uMSContext = _context.CourseRegistration.Include(c => c.Course).Include(c => c.Student);
            return View(await uMSContext.ToListAsync());
        }

        // GET: CourseRegistrations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CourseRegistration == null)
            {
                return NotFound();
            }

            var courseRegistration = await _context.CourseRegistration
                .Include(c => c.Course)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseRegistration == null)
            {
                return NotFound();
            }

            return View(courseRegistration);
        }

        // GET: CourseRegistrations/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
            return View();
        }

        // POST: CourseRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,StudentId,RegDate")] CourseRegistration courseRegistration)
        {
            try
            {
                courseRegistration.Id = Guid.NewGuid();
                courseRegistration.IsApproved = 0;
                _context.Add(courseRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", courseRegistration.CourseId);
                ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", courseRegistration.StudentId);
                return View(courseRegistration);
            }

        }

        // GET: CourseRegistrations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CourseRegistration == null)
            {
                return NotFound();
            }

            var courseRegistration = await _context.CourseRegistration.FindAsync(id);
            if (courseRegistration == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", courseRegistration.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", courseRegistration.StudentId);
            return View(courseRegistration);
        }

        // POST: CourseRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CourseId,StudentId,RegDate")] CourseRegistration courseRegistration)
        {
            if (id != courseRegistration.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseRegistrationExists(courseRegistration.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", courseRegistration.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", courseRegistration.StudentId);
            return View(courseRegistration);
        }

        // GET: CourseRegistrations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CourseRegistration == null)
            {
                return NotFound();
            }

            var courseRegistration = await _context.CourseRegistration
                .Include(c => c.Course)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseRegistration == null)
            {
                return NotFound();
            }

            return View(courseRegistration);
        }

        // POST: CourseRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CourseRegistration == null)
            {
                return Problem("Entity set 'UMSContext.CourseRegistration'  is null.");
            }
            var courseRegistration = await _context.CourseRegistration.FindAsync(id);
            if (courseRegistration != null)
            {
                _context.CourseRegistration.Remove(courseRegistration);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseRegistrationExists(Guid id)
        {
            return (_context.CourseRegistration?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
