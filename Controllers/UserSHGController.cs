using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KalamYouthForumWebApp.Data;
using KalamYouthForumWebApp.Models.ViewModels;
using KalamYouthForumWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace KalamYouthForumWebApp.Controllers
{
    public class UserSHGController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public UserSHGController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: UserSHG
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        public async Task<IActionResult> Index()
        {

            var user = await userManager.GetUserAsync(HttpContext.User);
            var chapterXUsers = _context.UserXChapters.Where(a => a.UserID == user.Id).Select(u => u.ChapterID).ToList();
            var chapters = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).ToListAsync();
            var usersChaptersIDs = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).Select(a => a.ChapterID).ToListAsync();
            var shgList = _context.sheModels.Where(i => i.ChapterModels.Any(p => usersChaptersIDs.Contains(p.ChapterID)));
            
            var applicationDbContext = _context.UserXSHGs.Include(u => u.ApplicationUser).Include(u => u.SHEModel);
            List<UserChapterSHG> userChapterSHGs = new List<UserChapterSHG>();
            foreach(var userSHG in applicationDbContext)
            {
                ChapterModel chapterModel = new ChapterModel();
                if ((await userManager.IsInRoleAsync(user, "Admin")) || (await userManager.IsInRoleAsync(user, "Moderator")))
                {
                    chapterModel = _context.chapterModels.Where(s => s.SHEModels.Any(c => c.SHEId == userSHG.SHEModel.SHEId)).FirstOrDefault();
                }
                else
                {
                    chapterModel = _context.chapterModels.Where(s => s.SHEModels.Any(c => c.SHEId == userSHG.SHEModel.SHEId)).Where(p => usersChaptersIDs.Contains(p.ChapterID)).FirstOrDefault();
                }
                if (chapterModel != null)
                {
                    var model = new UserChapterSHG
                    {
                        UserXSHG = userSHG,
                        ChapterModel = chapterModel
                    };
                    userChapterSHGs.Add(model);
                }
                
                //var model = new UserChapterSHG
                //{
                //    UserXSHG = userSHG,
                //    ChapterModel = chapterModel
                //};
                //userChapterSHGs.Add(model);
            }
            //return View(await applicationDbContext.ToListAsync());
            return View(userChapterSHGs);
        }

        // GET: UserSHG/Details/5
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userXSHG = await _context.UserXSHGs
                .Include(u => u.ApplicationUser)
                .Include(u => u.SHEModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userXSHG == null)
            {
                return NotFound();
            }

            return View(userXSHG);
        }

        // GET: UserSHG/Create
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        public async Task<IActionResult> Create()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var chapterXUsers = _context.UserXChapters.Where(a => a.UserID == user.Id).Select(u => u.ChapterID).ToList();
            var chapters = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).ToListAsync();
            var usersChaptersIDs = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).Select(a => a.ChapterID).ToListAsync();

            var shgList = _context.sheModels.Where(i => i.ChapterModels.Any(p => usersChaptersIDs.Contains(p.ChapterID)));
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "UserName");
            if ((await userManager.IsInRoleAsync(user, "Admin")) || (await userManager.IsInRoleAsync(user, "Moderator")))
            {
                ViewData["SHGID"] = new SelectList(_context.sheModels, "SHEId", "SHEName");
                ViewData["SHGCount"] = _context.sheModels.ToList().Count;
            } else
            {
                ViewData["SHGID"] = new SelectList(shgList, "SHEId", "SHEName");
                ViewData["SHGCount"] = shgList.ToList().Count;
            }
            
            return View();
        }

        // POST: UserSHG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,SHGID")] UserXSHG userXSHG)
        {
            if (userXSHG.SHGID == 0)
            {
                return View(userXSHG);
            }
            if (ModelState.IsValid)
            {
                _context.Add(userXSHG);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "UserName", userXSHG.UserID);
            ViewData["SHGID"] = new SelectList(_context.sheModels, "SHEId", "SHEName", userXSHG.SHGID);
            return View(userXSHG);
        }

        // GET: UserSHG/Edit/5
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userXSHG = await _context.UserXSHGs.FindAsync(id);
            if (userXSHG == null)
            {
                return NotFound();
            }
            var user = await userManager.GetUserAsync(HttpContext.User);
            var chapterXUsers = _context.UserXChapters.Where(a => a.UserID == user.Id).Select(u => u.ChapterID).ToList();
            var chapters = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).ToListAsync();
            var usersChaptersIDs = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).Select(a => a.ChapterID).ToListAsync();
            
            var shgList = _context.sheModels.Where(i => i.ChapterModels.Any(p => usersChaptersIDs.Contains(p.ChapterID)));
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "UserName", userXSHG.UserID);
            if ((await userManager.IsInRoleAsync(user, "Admin")) || (await userManager.IsInRoleAsync(user, "Moderator")))
            {
                ViewData["SHGID"] = new SelectList(_context.sheModels, "SHEId", "SHEName");
                ViewData["SHGCount"] = _context.sheModels.ToList().Count;
            }
            else
            {
                ViewData["SHGID"] = new SelectList(shgList, "SHEId", "SHEName");
                ViewData["SHGCount"] = shgList.ToList().Count;
            }
            return View(userXSHG);
        }

        // POST: UserSHG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,SHGID")] UserXSHG userXSHG)
        {
            if (id != userXSHG.Id )
            {
                return NotFound();
            }

            if (userXSHG.SHGID == 0)
            {
                return View(userXSHG);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userXSHG);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserXSHGExists(userXSHG.Id))
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
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Username", userXSHG.UserID);
            ViewData["SHGID"] = new SelectList(_context.sheModels, "SHEId", "SHEName", userXSHG.SHGID);
            return View(userXSHG);
        }

        // GET: UserSHG/Delete/5
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userXSHG = await _context.UserXSHGs
                .Include(u => u.ApplicationUser)
                .Include(u => u.SHEModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userXSHG == null)
            {
                return NotFound();
            }

            return View(userXSHG);
        }

        // POST: UserSHG/Delete/5
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userXSHG = await _context.UserXSHGs.FindAsync(id);
            _context.UserXSHGs.Remove(userXSHG);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserXSHGExists(int id)
        {
            return _context.UserXSHGs.Any(e => e.Id == id);
        }
    }
}
