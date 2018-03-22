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
   
    public class FriendshipsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FriendshipsController(ApplicationDbContext context, UserManager<ApplicationUser>
        userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser>
           GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        //create new method to display the MyFriends View and allows you to search for all users:
        //See FriendRequests that are pending:
        [HttpGet]
        public async Task<IActionResult> MyFriends()
        {
            // return View(await _context.Friendship.ToListAsync());
            var UserReciever = await GetCurrentUserAsync();
            //f is reffering to the Friendship:
            return View(await _context.Friendship.Include("UserSender").Where(f => (f.UserReciever == UserReciever) && !(f.FriendshipStatus)).ToListAsync());
        }
        
        //create a method to display specific friends when you search for their first name, last name, or both. search by name only:
        [HttpPost]
        public async Task<IActionResult> FriendsList(string SearchFriends)
        //u equals user
        {
            return View(await _context.ApplicationUser.Where(u => (u.FirstName + " " + u.LastName).Contains(SearchFriends)).ToListAsync());
        }

        //Send a Friend Request:
        [HttpGet]
        public async Task<IActionResult> SendFriendRequest(string UserRecieverId)
        {
            
            //create a new instance of Friendship:
            Friendship friendship = new Friendship();

            //tried calling in the Application User but I dont think that will work:
            ApplicationUser UserSender = await GetCurrentUserAsync();
            
            //details You want included into the friendship:
            ApplicationUser ur = _context.ApplicationUser.Single(a => a.Id == UserRecieverId);
           
            friendship.UserSender = UserSender;
            friendship.UserReciever = ur;

           
            //add the friendship to the database:
            _context.Add(friendship);
            _context.SaveChanges();
            //bring the user back to their MyFriendsPage:
            return View("MyFriends");
        }
        //end the new method:"



        //PENDING FRIEND REQUEST: CHNAGE THE STATE OF THE FRIENDSHIP:
        [HttpGet]
        public IActionResult ConfirmFriendRequest( int Friendship)
        {
            var ConfirmFriendship = _context.Friendship.SingleOrDefault(i => i.FriendshipId == Friendship);
            ConfirmFriendship.FriendshipStatus = true;

            //add the New Friendship to the database:
            _context.Update(ConfirmFriendship);
            _context.SaveChanges();
            return RedirectToAction("MyFriends");
            //bring the user back to their MyFriendsPage:

        }


        //END the method:

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
