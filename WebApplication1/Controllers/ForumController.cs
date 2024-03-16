using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebEnvironment_Hackathon_GaMo.Context;

namespace WebApplication1.Controllers
{
    public class ForumController : Controller
    {
        private readonly WebEnviDbContext context;
        // GET: ForumController
        public ForumController(WebEnviDbContext context)
        {
            this.context = context;
        }
        public ActionResult Index()
        {
			var posts = (from post in context.Forums select post).ToList();
			return View(posts);
        }

        // GET: ForumController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ForumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ForumController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ForumController/Edit/5
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

        // GET: ForumController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ForumController/Delete/5
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
