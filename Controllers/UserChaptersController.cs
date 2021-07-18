using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KalamYouthForumWebApp.Data;
using KalamYouthForumWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace KalamYouthForumWebApp.Controllers
{
    public class UserChaptersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserChaptersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: UserChapters
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserXChapters.Include(u => u.ApplicationUser).Include(u => u.Chapter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserChapters/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userXChapter = await _context.UserXChapters
                .Include(u => u.ApplicationUser)
                .Include(u => u.Chapter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userXChapter == null)
            {
                return NotFound();
            }

            return View(userXChapter);
        }

        // GET: UserChapters/Create
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["ChapterID"] = new SelectList(_context.chapterModels, "ChapterID", "ChapterName");
            return View();
        }

        // POST: UserChapters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,ChapterID")] UserXChapter userXChapter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userXChapter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "UserName", userXChapter.UserID);
            ViewData["ChapterID"] = new SelectList(_context.chapterModels, "ChapterID", "ChapterName", userXChapter.ChapterID);
            return View(userXChapter);
        }

        // GET: UserChapters/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userXChapter = await _context.UserXChapters.FindAsync(id);
            if (userXChapter == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "UserName", userXChapter.UserID);
            ViewData["ChapterID"] = new SelectList(_context.chapterModels, "ChapterID", "ChapterName", userXChapter.ChapterID);
            return View(userXChapter);
        }

        // POST: UserChapters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,ChapterID")] UserXChapter userXChapter)
        {
            if (id != userXChapter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userXChapter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserXChapterExists(userXChapter.Id))
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
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "UserName", userXChapter.UserID);
            ViewData["ChapterID"] = new SelectList(_context.chapterModels, "ChapterID", "ChapterName", userXChapter.ChapterID);
            return View(userXChapter);
        }

        // GET: UserChapters/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userXChapter = await _context.UserXChapters
                .Include(u => u.ApplicationUser)
                .Include(u => u.Chapter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userXChapter == null)
            {
                return NotFound();
            }

            return View(userXChapter);
        }

        // POST: UserChapters/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userXChapter = await _context.UserXChapters.FindAsync(id);
            _context.UserXChapters.Remove(userXChapter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserXChapterExists(int id)
        {
            return _context.UserXChapters.Any(e => e.Id == id);
        }
    }
}
