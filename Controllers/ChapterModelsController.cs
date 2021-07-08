using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KalamYouthForumWebApp.Data;
using KalamYouthForumWebApp.Models;
using KalamYouthForumWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace KalamYouthForumWebApp.Controllers
{
    public class ChapterModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChapterModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin, Moderator, Chapter")]
        // GET: ChapterModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.chapterModels.ToListAsync());
        }

        [Authorize(Roles = "Admin, Moderator, Chapter")]
        // GET: ChapterModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapterModel = await _context.chapterModels
                .FirstOrDefaultAsync(m => m.ChapterID == id);

            var sheModels =  _context.sheModels.Where(i => i.ChapterModels.Any(p => p.ChapterID == id));

            var model = new ChapterSHE
            {
                Chapter = chapterModel,
                SHEModels = sheModels
            };

            if (chapterModel == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [Authorize(Roles = "Admin, Moderator, Chapter")]
        // GET: ChapterModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChapterModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChapterID,ChapterName,Panchayat,Muncipality,Taluk,Constituency,OfficeAddress")] ChapterModel chapterModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chapterModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chapterModel);
        }

        // GET: ChapterModels/Edit/5
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapterModel = await _context.chapterModels.FindAsync(id);
            if (chapterModel == null)
            {
                return NotFound();
            }
            return View(chapterModel);
        }

        // POST: ChapterModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChapterID,ChapterName,Panchayat,Muncipality,Taluk,Constituency,OfficeAddress")] ChapterModel chapterModel)
        {
            if (id != chapterModel.ChapterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chapterModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChapterModelExists(chapterModel.ChapterID))
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
            return View(chapterModel);
        }

        // GET: ChapterModels/Delete/5
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapterModel = await _context.chapterModels
                .FirstOrDefaultAsync(m => m.ChapterID == id);
            if (chapterModel == null)
            {
                return NotFound();
            }

            return View(chapterModel);
        }

        // POST: ChapterModels/Delete/5
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chapterModel = await _context.chapterModels.FindAsync(id);
            _context.chapterModels.Remove(chapterModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChapterModelExists(int id)
        {
            return _context.chapterModels.Any(e => e.ChapterID == id);
        }
    }
}
