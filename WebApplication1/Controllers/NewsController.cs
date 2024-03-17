using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEnvironment_Hackathon_GaMo.Context;
using WebEnvironment_Hackathon_GaMo.Models;

namespace WebEnvironment_Hackathon_GaMo.Controllers
{
    public class NewsController : Controller
    {
        // GET: NewsController
        private readonly WebEnviDbContext _context;

        public NewsController(WebEnviDbContext context)
        {
            _context = context;
        }
      
        public async Task<IActionResult> Index()
        {
            return _context.News != null ?
                          View(await _context.News.ToListAsync()) :
                          Problem("Entity set 'BookStoreMVCWebContext.Book'  is null.");
        }

        // GET: NewsController/Details/5
        public async Task< ActionResult >Details(int ?id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id_New == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: NewsController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_New,Title,Description,Language,ImageUrl,Created_at ,Created_by ,UserId")] News news)
        {
            if (ModelState.IsValid)
            {
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: NewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
