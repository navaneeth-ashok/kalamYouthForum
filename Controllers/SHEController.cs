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
using Microsoft.AspNetCore.Identity;

namespace KalamYouthForumWebApp.Controllers
{
    public class SHEController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public SHEController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        // GET: SHE
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var chapterXUsers = _context.UserXChapters.Where(a => a.UserID == user.Id).Select(u => u.ChapterID).ToList();
            var chapters = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).ToListAsync();
            var usersChaptersIDs = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).Select(a => a.ChapterID).ToListAsync();
            // if user is present in the chapter, show all the SHG inside the chapter
            List<SHEModel> shes = new List<SHEModel>();
            if(usersChaptersIDs.Count > 0)
            {
                shes = _context.sheModels.Where(i => i.ChapterModels.Any(p => usersChaptersIDs.Contains(p.ChapterID))).ToList();
            } 
            
            // Now add SHGs the user is part of
            var shgXUsers = _context.UserXSHGs.Where(a => a.UserID == user.Id).Select(u => u.SHGID).ToList();
            var shesBelongToUser = await _context.sheModels.Where(r => shgXUsers.Contains(r.SHEId)).ToListAsync();
            var fullSHGList = shes.Concat(shesBelongToUser).ToList();
            
            if((await userManager.IsInRoleAsync(user, "Admin")) || (await userManager.IsInRoleAsync(user, "Moderator"))){
                fullSHGList = await _context.sheModels.ToListAsync();
            }

            //var shes = await _context.sheModels.ToListAsync();
            List<SHEChapter> sheChapters = new List<SHEChapter>();
            foreach (var she in fullSHGList)
            {
                SHEModel sheModel = _context.sheModels.Include(c => c.ChapterModels).Where(a => a.SHEId == she.SHEId).FirstOrDefault();
                //System.Diagnostics.Debug.WriteLine(she.SHEName);
                //System.Diagnostics.Debug.WriteLine(she.ChapterModels.First().ChapterID);
                //System.Diagnostics.Debug.WriteLine(she.ChapterModels.First().ChapterName);
                // because an SHG is part of one chapter only, retrieve the Chapter associated with it
                // and send to view
                ChapterModel chapterModel = she.ChapterModels.FirstOrDefault();

                var model = new SHEChapter
                {
                    Chapter = chapterModel,
                    SHEModel = she
                };
                sheChapters.Add(model);
            }
            return View(sheChapters);
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        public void AssociateSHEToChapter(int chapterID, int sheID)
        {
            // Adding SHE to Chapter
            ChapterModel SelectedChapter = _context.chapterModels.Include(c => c.SHEModels).Where(a => a.ChapterID == chapterID).FirstOrDefault();
            SHEModel sheModel = _context.sheModels.Find(sheID);
            SelectedChapter.SHEModels.Add(sheModel);
            // Adding Chapter to SHE
            SHEModel SelectedSHGModel = _context.sheModels.Include(a => a.ChapterModels).Where(b => b.SHEId == sheID).FirstOrDefault();
            SelectedSHGModel.ChapterModels.Add(SelectedChapter);

            _context.SaveChanges();
        }


        // GET: SHE/Details/5
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await userManager.GetUserAsync(HttpContext.User);
            var chapterXUsers = _context.UserXChapters.Where(a => a.UserID == user.Id).Select(u => u.ChapterID).ToList();
            var UsersSHGIDs = _context.UserXSHGs.Where(a => a.UserID == user.Id).Select(u => u.SHGID).ToList();
            var usersChaptersIDs = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).Select(a => a.ChapterID).ToListAsync();
            var UserChapterSHGID = _context.sheModels.Where(i => i.ChapterModels.Any(p => usersChaptersIDs.Contains(p.ChapterID))).Select(a => a.SHEId).ToList();
            if (!UsersSHGIDs.Contains(Convert.ToInt32(id)) 
                && !UserChapterSHGID.Contains(Convert.ToInt32(id))
                && !(await userManager.IsInRoleAsync(user, "Admin"))
                && !(await userManager.IsInRoleAsync(user, "Moderator")))
            {
                return NotFound();
            }

            var sHEModel = await _context.sheModels
                .FirstOrDefaultAsync(m => m.SHEId == id);
            if (sHEModel == null)
            {
                return NotFound();
            }

            List<int> IdsToSearch = new List<int>();
            var documentIDs = _context.SHGMonthlyDocuments.Where(a => a.SHGId == id).ToList();
            System.Diagnostics.Debug.WriteLine("#####################");
            foreach ( var idEle in documentIDs)
            {
                IdsToSearch.Add(Convert.ToInt32(idEle.FileId));
                System.Diagnostics.Debug.WriteLine(idEle.FileId);
            }
            System.Diagnostics.Debug.WriteLine("#####################");
            System.Diagnostics.Debug.WriteLine(IdsToSearch);

            IEnumerable<MonthlyAccountDocument> monthlyAccountDocuments = _context.MonthlyAccountDocuments.Where(r => IdsToSearch.Contains(r.Id)).ToList();

            

            SHGMonthlyAccount shgMonthlyAccount = new SHGMonthlyAccount
            {
                SHEModel = sHEModel,
                MonthlyAccountDocument = monthlyAccountDocuments,
            };


            return View(shgMonthlyAccount);
        }

        // GET: SHE/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        [HttpPost]
        public IActionResult Create(int chapterID)
        {
            ViewBag.Message = chapterID;
            return View();
        }

        // POST: SHE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSHE([Bind("SHEId,SHEName,DateOfFormation,NumberOfMembers,ElectedPresident,PresidentEmail,PresidentPhoneNumber,ElectedSecretary,SecretaryEmail,SecretaryPhoneNumber,ElectedTreasurer,TreasurerEmail,TreasurerPhoneNumber")] SHEModel sHEModel, int chapterID)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sHEModel);
                await _context.SaveChangesAsync();
                // assigning this SHE to the parent chapter
                AssociateSHEToChapter(chapterID, sHEModel.SHEId);
                return RedirectToAction("Details", "ChapterModels", new { id = chapterID });
            }
            return View(sHEModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        public IActionResult AddMembers(int shgID)
        {
            ViewBag.shgID = shgID;
            return View();
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpGet]
        public IActionResult ViewSHGMember(int id)
        {
            var model = _context.shgMembers.Find(id);
            return View(model);
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpPost]
        public IActionResult ViewAllSHGMembers()
        {
            List<SHGMember> shgMembers = new List<SHGMember>();
            var members = _context.shgMembers.ToList();
            foreach (var member in members)
            {
                shgMembers.Add(member);
            }
            return View(shgMembers);
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpPost]
        public IActionResult ViewMembers(int shgID)
        {
            List<SHGMember> shgMembers = new List<SHGMember>();
            var members = _context.shgMembers.Where(a => a.SHEId == shgID).ToList();
            foreach(var member in members)
            {
                shgMembers.Add(member);
            }
            ViewBag.shgID = shgID;
            return View(shgMembers);
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMembersToSHG(SHGMember memberModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberModel);
                await _context.SaveChangesAsync();
                ReCalculateMemberCount(memberModel.SHEId);
                return RedirectToAction("Details", "SHE", new { id = memberModel.SHEId });
            }
            return View(memberModel);
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpGet]
        public IActionResult DeleteMembersFromSHG(int id)
        {
            var model = _context.shgMembers.Find(id);
            return View(model);
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpGet]
        public IActionResult EditSHGMember(int id)
        {
            var model = _context.shgMembers.Find(id);
            return View(model);
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSHGMember(int SHGMemberId, SHGMember shgMember)
        {
            if (SHGMemberId != shgMember.SHGMemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shgMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SHEModelExists(shgMember.SHGMemberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = shgMember.SHEId });
            }
            return View(shgMember);
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMembersFromSHGConfirmed(int SHGMemberId)
        {
            System.Diagnostics.Debug.WriteLine(SHGMemberId);
            var model = _context.shgMembers.Find(SHGMemberId);
            _context.shgMembers.Remove(model);
            await _context.SaveChangesAsync();
            ReCalculateMemberCount(model.SHEId);
            return RedirectToAction("Details", new { id = model.SHEId });
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        public void ReCalculateMemberCount(int id)
        {
            var sHEModel = _context.sheModels.Find(id);
            int shgMemberCount = _context.shgMembers.Where(a => a.SHEId == id).ToList().Count();
            sHEModel.NumberOfMembers = shgMemberCount;
            _context.SaveChanges();
        }


        // GET: SHE/Edit/5
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await userManager.GetUserAsync(HttpContext.User);
            var chapterXUsers = _context.UserXChapters.Where(a => a.UserID == user.Id).Select(u => u.ChapterID).ToList();
            var UsersSHGIDs = _context.UserXSHGs.Where(a => a.UserID == user.Id).Select(u => u.SHGID).ToList();
            var usersChaptersIDs = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).Select(a => a.ChapterID).ToListAsync();
            var UserChapterSHGID = _context.sheModels.Where(i => i.ChapterModels.Any(p => usersChaptersIDs.Contains(p.ChapterID))).Select(a => a.SHEId).ToList();
            if (!UsersSHGIDs.Contains(Convert.ToInt32(id)) 
                && !UserChapterSHGID.Contains(Convert.ToInt32(id))
                && !(await userManager.IsInRoleAsync(user, "Admin"))
                && !(await userManager.IsInRoleAsync(user, "Moderator")))
            {
                return NotFound();
            }

            var sHEModel = await _context.sheModels.FindAsync(id);
            if (sHEModel == null)
            {
                return NotFound();
            }
            return View(sHEModel);
        }

        // POST: SHE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SHEId,SHEName,DateOfFormation,NumberOfMembers,ElectedPresident,PresidentEmail,PresidentPhoneNumber,ElectedSecretary,SecretaryEmail,SecretaryPhoneNumber,ElectedTreasurer,TreasurerEmail,TreasurerPhoneNumber")] SHEModel sHEModel)
        {
            if (id != sHEModel.SHEId)
            {
                return NotFound();
            }
            var user = await userManager.GetUserAsync(HttpContext.User);
            var chapterXUsers = _context.UserXChapters.Where(a => a.UserID == user.Id).Select(u => u.ChapterID).ToList();
            var UsersSHGIDs = _context.UserXSHGs.Where(a => a.UserID == user.Id).Select(u => u.SHGID).ToList();
            var usersChaptersIDs = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).Select(a => a.ChapterID).ToListAsync();
            var UserChapterSHGID = _context.sheModels.Where(i => i.ChapterModels.Any(p => usersChaptersIDs.Contains(p.ChapterID))).Select(a => a.SHEId).ToList();
            if (!UsersSHGIDs.Contains(Convert.ToInt32(id)) 
                && !UserChapterSHGID.Contains(Convert.ToInt32(id))
                && !(await userManager.IsInRoleAsync(user, "Admin"))
                && !(await userManager.IsInRoleAsync(user, "Moderator")))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sHEModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SHEModelExists(sHEModel.SHEId))
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
            return View(sHEModel);
        }

        // GET: SHE/Delete/5
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await userManager.GetUserAsync(HttpContext.User);
            var chapterXUsers = _context.UserXChapters.Where(a => a.UserID == user.Id).Select(u => u.ChapterID).ToList();
            var UsersSHGIDs = _context.UserXSHGs.Where(a => a.UserID == user.Id).Select(u => u.SHGID).ToList();
            var usersChaptersIDs = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).Select(a => a.ChapterID).ToListAsync();
            var UserChapterSHGID = _context.sheModels.Where(i => i.ChapterModels.Any(p => usersChaptersIDs.Contains(p.ChapterID))).Select(a => a.SHEId).ToList();
            if (!UsersSHGIDs.Contains(Convert.ToInt32(id)) 
                && !UserChapterSHGID.Contains(Convert.ToInt32(id))
                && !(await userManager.IsInRoleAsync(user, "Admin"))
                && !(await userManager.IsInRoleAsync(user, "Moderator")))
            {
                return NotFound();
            }

            var sHEModel = await _context.sheModels
                .FirstOrDefaultAsync(m => m.SHEId == id);
            if (sHEModel == null)
            {
                return NotFound();
            }

            return View(sHEModel);
        }

        // POST: SHE/Delete/5
        [Authorize(Roles = "Admin, Moderator, Chapter")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var chapterXUsers = _context.UserXChapters.Where(a => a.UserID == user.Id).Select(u => u.ChapterID).ToList();
            var UsersSHGIDs = _context.UserXSHGs.Where(a => a.UserID == user.Id).Select(u => u.SHGID).ToList();
            var usersChaptersIDs = await _context.chapterModels.Where(r => chapterXUsers.Contains(r.ChapterID)).Select(a => a.ChapterID).ToListAsync();
            var UserChapterSHGID = _context.sheModels.Where(i => i.ChapterModels.Any(p => usersChaptersIDs.Contains(p.ChapterID))).Select(a => a.SHEId).ToList();
            if (!UsersSHGIDs.Contains(Convert.ToInt32(id)) 
                && !UserChapterSHGID.Contains(Convert.ToInt32(id))
                && !(await userManager.IsInRoleAsync(user, "Admin"))
                && !(await userManager.IsInRoleAsync(user, "Moderator")))
            {
                return NotFound();
            }
            var sHEModel = await _context.sheModels.FindAsync(id);
            _context.sheModels.Remove(sHEModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddExpenseReport(int shgId)
        {
            ViewBag.shgID = shgId;
            return View();
        }



        private bool SHEModelExists(int id)
        {
            return _context.sheModels.Any(e => e.SHEId == id);
        }
    }
}
