﻿using System;
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
using Microsoft.AspNetCore.Identity;

namespace KalamYouthForumWebApp.Controllers
{
    public class ChapterModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public ChapterModelsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin, Moderator, Chapter")]
        // GET: ChapterModels
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var chapterXUsers = _context.UserXChapters.Where(a => a.UserID == user.Id).Select( u => u.ChapterID).ToList();
            IEnumerable<ChapterModel> chapterModels = new List<ChapterModel>();
            if ((await userManager.IsInRoleAsync(user, "Admin")) || (await userManager.IsInRoleAsync(user, "Moderator")))
            {
                chapterModels = await _context.chapterModels.ToListAsync();
            } else
            {
                chapterModels = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).ToListAsync();
            }
            return View(chapterModels);
        }

        [Authorize(Roles = "Admin, Moderator, Chapter")]
        // GET: ChapterModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await userManager.GetUserAsync(HttpContext.User);
            var UsersChapterIDs = _context.UserXChapters.Where(a => a.UserID == user.Id).Select(u => u.ChapterID).ToList();
            if (!UsersChapterIDs.Contains(Convert.ToInt32(id))
                && !(await userManager.IsInRoleAsync(user, "Admin"))
                && !(await userManager.IsInRoleAsync(user, "Moderator")))
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

            List<int> IdsToSearch = new List<int>();
            var documentIDs = _context.ChapterMonthlyDocument.Where(a => a.ChapterID == id).ToList();
            foreach (var idEle in documentIDs)
            {
                IdsToSearch.Add(Convert.ToInt32(idEle.FileId));
            }

            IEnumerable<MonthlyAccountDocument> monthlyAccountDocuments = _context.MonthlyAccountDocuments.Where(r => IdsToSearch.Contains(r.Id)).ToList();



            ChapterMonthlyAccount chapterMonthlyAccount = new ChapterMonthlyAccount
            {
                ChapterSHE = model,
                MonthlyAccountDocument = monthlyAccountDocuments,
            };


            return View(chapterMonthlyAccount);
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
                // assign this chapter to the user automatically
                UserChaptersController userChaptersController = new UserChaptersController(_context);
                var user = await userManager.GetUserAsync(HttpContext.User);
                UserXChapter userXChapter = new UserXChapter
                {
                    UserID = user.Id,
                    ChapterID = chapterModel.ChapterID
                };
                await userChaptersController.Create(userXChapter);
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
            var user = await userManager.GetUserAsync(HttpContext.User);
            var UsersChapterIDs = _context.UserXChapters.Where(a => a.UserID == user.Id).Select(u => u.ChapterID).ToList();
            if (!UsersChapterIDs.Contains(Convert.ToInt32(id)) 
                && !(await userManager.IsInRoleAsync(user, "Admin"))
                && !(await userManager.IsInRoleAsync(user, "Moderator")))
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
            var user = await userManager.GetUserAsync(HttpContext.User);
            var UsersChapterIDs = _context.UserXChapters.Where(a => a.UserID == user.Id).Select(u => u.ChapterID).ToList();
            if (!UsersChapterIDs.Contains(Convert.ToInt32(id)) 
                && !(await userManager.IsInRoleAsync(user, "Admin"))
                && !(await userManager.IsInRoleAsync(user, "Moderator")))
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
        [Authorize(Roles = "Admin, Moderator")]
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
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chapterModel = await _context.chapterModels.FindAsync(id);
            _context.chapterModels.Remove(chapterModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin, Moderator, Chapter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddExpenseReport(int chapterID)
        {
            ViewBag.chapterID = chapterID;
            return View();
        }

        private bool ChapterModelExists(int id)
        {
            return _context.chapterModels.Any(e => e.ChapterID == id);
        }
    }
}
