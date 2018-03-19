using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NSSBackEndProject.Data;
using NSSBackEndProject.Models;

namespace NSSBackEndProject.Controllers
{
    public class FriendshipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FriendshipsController(ApplicationDbContext context)
        {
            _context = context;
        }
        //create new method to display the MyFriends View:
        public async Task<IActionResult> MyFriends()
        {
            return View(await _context.Friendship.ToListAsync());
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.Friendship.ToListAsync());
        }

        // GET: Friendships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendship = await _context.Friendship
                .SingleOrDefaultAsync(m => m.FriendshipId == id);
            if (friendship == null)
            {
                return NotFound();
            }

            return View(friendship);
        }

        // GET: Friendships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Friendships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendshipId,FriendshipStatus")] Friendship friendship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friendship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(friendship);
        }

        // GET: Friendships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendship = await _context.Friendship.SingleOrDefaultAsync(m => m.FriendshipId == id);
            if (friendship == null)
            {
                return NotFound();
            }
            return View(friendship);
        }

        // POST: Friendships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FriendshipId,FriendshipStatus")] Friendship friendship)
        {
            if (id != friendship.FriendshipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friendship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendshipExists(friendship.FriendshipId))
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
            return View(friendship);
        }

        // GET: Friendships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendship = await _context.Friendship
                .SingleOrDefaultAsync(m => m.FriendshipId == id);
            if (friendship == null)
            {
                return NotFound();
            }

            return View(friendship);
        }

        // POST: Friendships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var friendship = await _context.Friendship.SingleOrDefaultAsync(m => m.FriendshipId == id);
            _context.Friendship.Remove(friendship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

   

        private bool FriendshipExists(int id)
        {
            return _context.Friendship.Any(e => e.FriendshipId == id);
        }
    }
}
