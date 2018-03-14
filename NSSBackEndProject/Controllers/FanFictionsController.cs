using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NSSBackEndProject.Data;
using NSSBackEndProject.Models;
using Microsoft.AspNetCore.Identity;

namespace NSSBackEndProject.Controllers
{
         public class FanFictionsController : Controller { 
         // create an instance of the UserManager to be able to retrieve the current active user:
      private readonly UserManager<ApplicationUser> _userManager;
      private readonly ApplicationDbContext _context;
        
        //create new instances of the manager and context:
         public FanFictionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

           // This task retrieves the currently authenticated user:
           private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        //added code ends



        // GET: FanFictions
        public async Task<IActionResult> Index() => View(await _context.FanFiction.ToListAsync());

        // GET: FanFictions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fanFiction = await _context.FanFiction
                .SingleOrDefaultAsync(m => m.FanFictionId == id);
            if (fanFiction == null)
            {
                return NotFound();
            }

            return View(fanFiction);
        }

        // GET: FanFictions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FanFictions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FanFictionId,BookId,FanFictionEssay,Comments,ApprovalRating")] FanFiction fanFiction)
        {
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                fanFiction.User = await GetCurrentUserAsync();
                _context.Add(fanFiction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fanFiction);
        }

        // GET: FanFictions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fanFiction = await _context.FanFiction.SingleOrDefaultAsync(m => m.FanFictionId == id);
            if (fanFiction == null)
            {
                return NotFound();
            }
            return View(fanFiction);
        }

        // POST: FanFictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FanFictionId,BookId,FanFictionEssay,Comments,ApprovalRating")] FanFiction fanFiction)
        {
            if (id != fanFiction.FanFictionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fanFiction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FanFictionExists(fanFiction.FanFictionId))
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
            return View(fanFiction);
        }

        // GET: FanFictions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fanFiction = await _context.FanFiction
                .SingleOrDefaultAsync(m => m.FanFictionId == id);
            if (fanFiction == null)
            {
                return NotFound();
            }

            return View(fanFiction);
        }

        // POST: FanFictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fanFiction = await _context.FanFiction.SingleOrDefaultAsync(m => m.FanFictionId == id);
            _context.FanFiction.Remove(fanFiction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FanFictionExists(int id)
        {
            return _context.FanFiction.Any(e => e.FanFictionId == id);
        }

            public ActionResult UploadDocument()
            {
                return View();
            }
        
    }
}
