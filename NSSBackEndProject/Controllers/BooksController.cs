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
using NSSBackEndProject.Models.BookViewModels;

namespace NSSBackEndProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
     
            _context = context;
            _userManager = userManager;
        }
        //create list tracked and tracked methods to add the book and the book's information to the database and unto the user's bookshelf page:
        // This task retrieves the currently authenticated user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> ListTrackedBook()
        {
            ApplicationUser user = await GetCurrentUserAsync();

            var model = new TrackedBooksViewModel();
            model.ApplicationUser = GetUserTrackedBooks(user);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Track(string apiId, string title, string bookImage, string bookAuthor, string bookGenre, string bookDescription, string img)
        {
            //gets the current user
            ApplicationUser user = await GetCurrentUserAsync();

            if (IsBookShelf(apiId, user))
            {
                return RedirectToActionPermanent("ListTrackedBook");
            }

            //add movie to database
            Book book = new Book
            {
                ApiId = apiId,
                BookTitle = title,
                BookImage = bookImage,
                Author = bookAuthor,
                
                Description = bookDescription,
            };
            _context.Add(book);


            //track that movie for the current user
            var trackBook = new BookUser
            {

                User = user,
                BookId = book.BookId,
               

            };


            _context.Add(trackBook);
            await _context.SaveChangesAsync();

            return RedirectToActionPermanent("ListTrackedBook");
        }

        public ICollection<BookShelf> GetUserTrackedBooks(ApplicationUser user)
        {
            return (from m in _context.Book
                    join mu in _context.BookUser
                      on m.BookId equals mu.BookId
                    where mu.User == user
                    select new BookShelf
                    {
                        User = mu.User,
                        BookTitle = m.BookTitle,
                        BookImage = m.BookImage,
                     
                       // Favorited = mu.Favorited,
                        //Watched = mu.Watched
                    }).ToList();
        }

        public bool IsBookShelf(string bookId, ApplicationUser user)
        {
            var isTracked = _context.BookUser
                .Include("Book")
                .Where(mu => mu.Book.ApiId == bookId && mu.User == user)
                .FirstOrDefault();

            if (isTracked == null)
            {
                return false;
            }

            return true;
        }

        //end the list tracked and tracked code:

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Book.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .SingleOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // This task retrieves the currently authenticated user
        //private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //public async Task<IActionResult> FavoriteBook()
        //{
        //    ApplicationUser user = await GetCurrentUserAsync();

        //    var model = new Book();
        //    //model.TrackedUserBooks = GetUserTrackedBooks(user);

        //    return View(model);
        //}
        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookTitle,BookImage,Author,Genre,Description,Hashtags")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.SingleOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookTitle,BookImage,Author,Genre,Description,Hashtags")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
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
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .SingleOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.SingleOrDefaultAsync(m => m.BookId == id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.BookId == id);
        }
    }
}
