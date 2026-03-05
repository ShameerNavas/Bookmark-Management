using BOOKMARK.DBContext;
using BOOKMARK.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BOOKMARK.Controllers
{
    [Authorize]
    public class BookmarkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookmarkController(ApplicationDbContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }


        [HttpPost]
        public IActionResult Add(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {

                var userName = User.Identity.Name;
                if (string.IsNullOrEmpty(userName))
                    return RedirectToAction("Login", "Home");

                var count = _context.Bookmarks.Count(b => b.UserName == userName);

               if (count >= 5) 
               {
               ViewBag.Error = "You can only add up to 5 bookmarks.";
                    return View(bookmark);
                }


                bookmark.UserName = userName;
                bookmark.CreatedAt = DateTime.Now;  
                _context.Bookmarks.Add(bookmark);
                _context.SaveChanges();


                TempData["Message"] = "Bookmark added successfully!";
                return RedirectToAction("Add");
            }
            return View(bookmark);
        }



        public IActionResult List(string search, int? page)
        {
            var userName = User.Identity.Name;

            int pageSize = 4;
            int pageNumber = page ?? 1;

            // ✅ Start with only this user's bookmarks
            var query = _context.Bookmarks
                .Where(b => b.UserName == userName);

            // ✅ If search text is provided, filter by Title or Url
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(b => b.Title.Contains(search) || b.Url.Contains(search));
            }

            // ✅ Apply pagination
            var bookmarks = query
                .OrderByDescending(b => b.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // ✅ Pass info to View
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling((double)query.Count() / pageSize);
            ViewBag.Search = search;

            return View(bookmarks);
        }


        // GET: Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bookmark = _context.Bookmarks.FirstOrDefault(b => b.Id == id);
            if (bookmark == null)
            {
                return NotFound();
            }
            return View(bookmark);
        }

        [HttpPost]
        public IActionResult Edit(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                var existing = _context.Bookmarks.FirstOrDefault(b => b.Id == bookmark.Id);

                if (existing != null)
                {
                    existing.Title = bookmark.Title;
                    existing.Url = bookmark.Url;

                    _context.SaveChanges(); // ✅ really updates DB

                    TempData["Message"] = "Changes applied successfully!";
                    return RedirectToAction("List");
                }
            }

            return View(bookmark);
        }






        // DELETE
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var userName = User.Identity.Name;
            var bookmark = _context.Bookmarks.FirstOrDefault(b => b.Id == id && b.UserName == userName);

            if (bookmark != null)
            {
                _context.Bookmarks.Remove(bookmark);
                _context.SaveChanges();
                TempData["Message"] = "Bookmark deleted successfully!";
            }

            return RedirectToAction("List");
        }


    }
}
