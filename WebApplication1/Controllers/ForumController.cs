﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEnvironment_Hackathon_GaMo.Context;

namespace WebEnvironment_Hackathon_GaMo.Controllers
{
    public class ForumController : Controller
    {
        private readonly WebEnviDbContext _context;
        public ForumController(WebEnviDbContext context)
        {
            _context = context;
        }
        // GET: ForumController
        public async Task< ActionResult> Index()
        {
            return _context.Forums != null ?
                          View(await _context.Forums.ToListAsync()) :
                          Problem("Entity set 'BookStoreMVCWebContext.Book'  is null.");
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
