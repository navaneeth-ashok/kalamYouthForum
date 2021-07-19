using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KalamYouthForumWebApp.Data;
using KalamYouthForumWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using KalamYouthForumWebApp.Models.ViewModels;

namespace KalamYouthForumWebApp.Controllers
{
    public class NewsletterListController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public NewsletterListController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: NewsletterList
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        public async Task<IActionResult> Index()
        {
            List<string> shgMembersEmail = await _context.shgMembers.Select(a => a.Email).ToListAsync();
            List<string> registeredMembersEmail = await userManager.Users.Select(a => a.Email).ToListAsync();
            List<string> newsletterUsersEmail = await _context.newsletterLists.Select(a => a.EmailID).ToListAsync();
            List<NewsletterList> newsletterUsers = await _context.newsletterLists.ToListAsync();

            List<string> concatenatedList = shgMembersEmail.Concat(registeredMembersEmail).Concat(newsletterUsersEmail).ToList();
            string concatenatedString = string.Join(",", concatenatedList);
            string commaSeperatedMailingListSHG = string.Join(",", shgMembersEmail);
            string commaSeperatedMailingListRegistered = string.Join(",", registeredMembersEmail);
            string commaSeperatedMailingListNewsLetter = string.Join(",", newsletterUsersEmail);

            NewsletterCombined newsletterList = new NewsletterCombined
            {
                shgMembersEmail = shgMembersEmail,
                registeredMembersEmail = registeredMembersEmail,
                newsletterUsersEmail = newsletterUsers,
                commaSeperatedMailingListSHG = commaSeperatedMailingListSHG,
                commaSeperatedMailingListRegistered = commaSeperatedMailingListRegistered,
                commaSeperatedMailingListNewsLetter = commaSeperatedMailingListNewsLetter,
                commaSeperatedMailingList = concatenatedString,
            };




            return View(newsletterList);
        }

        // GET: NewsletterList/Details/5
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletterList = await _context.newsletterLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsletterList == null)
            {
                return NotFound();
            }

            return View(newsletterList);
        }

        // GET: NewsletterList/Create
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsletterList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string EmailID)
        {
            if (ModelState.IsValid)
            {
                var newsletterList = new NewsletterList
                {
                    EmailID = EmailID
                };
                _context.Add(newsletterList);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: NewsletterList/Edit/5
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletterList = await _context.newsletterLists.FindAsync(id);
            if (newsletterList == null)
            {
                return NotFound();
            }
            return View(newsletterList);
        }

        // POST: NewsletterList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmailID")] NewsletterList newsletterList)
        {
            if (id != newsletterList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsletterList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsletterListExists(newsletterList.Id))
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
            return View(newsletterList);
        }

        // GET: NewsletterList/Delete/5
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletterList = await _context.newsletterLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsletterList == null)
            {
                return NotFound();
            }

            return View(newsletterList);
        }

        // POST: NewsletterList/Delete/5
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsletterList = await _context.newsletterLists.FindAsync(id);
            _context.newsletterLists.Remove(newsletterList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsletterListExists(int id)
        {
            return _context.newsletterLists.Any(e => e.Id == id);
        }
    }
}
