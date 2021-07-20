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
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Hosting;

namespace KalamYouthForumWebApp.Controllers
{
    public class NewsletterListController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHostEnvironment _hostEnvironment;

        public NewsletterListController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHostEnvironment hostEnvironment)
        {
            _context = context;
            this.userManager = userManager;
            _hostEnvironment = hostEnvironment;
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
            string htmlMail = System.IO.File.ReadAllText(_hostEnvironment.ContentRootPath + "/newsletterTemplate/template.html");
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



            ViewBag.HTMLMail = htmlMail;
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

        public AuthMessageSenderOptions Options { get; }

        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SendEmail(string subject, string toList, string htmlContent )
        {
            AuthMessageSenderOptions authMessageSenderOptions = new();
            var apiKey = authMessageSenderOptions.SendGridKey;
            var user = authMessageSenderOptions.SendGridUser;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("kalamyouthforumdev@gmail.com", user);
            var plainTextContent = "Please open the mail in a browser to view the full content.";
            List<EmailAddress> tos = new List<EmailAddress>();
            var toListElements = toList.Split(',').ToList();
            foreach(var toId in toListElements)
            { 
                var toInstance = new EmailAddress(toId);
                tos.Add(toInstance);
            }
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Newsletter sent successfully";
                ViewBag.Response = response.Body;
                return View();
            } else
            {
                ViewBag.Message = "Failed to sent the newsletter";
                ViewBag.Response = response.Body;
                return View();
            }
        }

        private bool NewsletterListExists(int id)
        {
            return _context.newsletterLists.Any(e => e.Id == id);
        }
    }
}
