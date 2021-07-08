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

namespace KalamYouthForumWebApp.Controllers
{
    public class UserSHGController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserSHGController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserSHG
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        public IActionResult Index()
        {
            var applicationDbContext = _context.UserXSHGs.Include(u => u.ApplicationUser).Include(u => u.SHEModel);
            List<UserChapterSHG> userChapterSHGs = new List<UserChapterSHG>();
            foreach(var userSHG in applicationDbContext)
            {
                System.Diagnostics.Debug.WriteLine(userSHG.SHEModel.SHEName);
                //var something = _context.sheModels.Include(a => a.ChapterModels).Where(b => b.SHEId == )  b
                System.Diagnostics.Debug.WriteLine(userSHG.SHEModel.ChapterModels);
                //System.Diagnostics.Debug.WriteLine(userSHG.SHEModel.ChapterModels.First().ChapterID);
                //System.Diagnostics.Debug.WriteLine(userSHG.SHEModel.ChapterModels.First().ChapterName);
                //var sheModel = _context.sheModels.Find(userSHG.SHEModel.SHEId);
                //System.Diagnostics.Debug.WriteLine(sheModel.SecretaryEmail);
                //System.Diagnostics.Debug.WriteLine(sheModel.ChapterModels);
                //System.Diagnostics.Debug.WriteLine(sheModel.ChapterModels);

                //ChapterModel chapterModel = userSHG.SHEModel.ChapterModels.FirstOrDefault();
                //ChapterModel chapterModel = _context.chapterModels.Include(c => c.SHEModels).Where(d => d.)
                var chapterModel = _context.chapterModels.Where( s => s.SHEModels.Any(c => c.SHEId == userSHG.SHEModel.SHEId)).First();

                
                var model = new UserChapterSHG
                {
                    UserXSHG = userSHG,
                    ChapterModel = chapterModel
                };
                userChapterSHGs.Add(model);
            }
            //return View(await applicationDbContext.ToListAsync());
            return View(userChapterSHGs);
        }

        // GET: UserSHG/Details/5
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
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
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["SHGID"] = new SelectList(_context.sheModels, "SHEId", "SHEName");
            return View();
        }

        // POST: UserSHG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,SHGID")] UserXSHG userXSHG)
        {
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
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
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
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "UserName", userXSHG.UserID);
            ViewData["SHGID"] = new SelectList(_context.sheModels, "SHEId", "SHEName", userXSHG.SHGID);
            return View(userXSHG);
        }

        // POST: UserSHG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,SHGID")] UserXSHG userXSHG)
        {
            if (id != userXSHG.Id)
            {
                return NotFound();
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
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
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
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
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
