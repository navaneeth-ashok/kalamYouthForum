using KalamYouthForumWebApp.Data;
using KalamYouthForumWebApp.Models;
using KalamYouthForumWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Controllers
{
    public class DocumentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public DocumentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpPost]
        public FileResult Download(int id)
        {
            var fileToRetrieve = _context.MonthlyAccountDocuments.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.FileType, fileToRetrieve.Name + fileToRetrieve.Extension);
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int shgID)
        {
            var file = await _context.MonthlyAccountDocuments.FindAsync(id);
            _context.MonthlyAccountDocuments.Remove(file);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "SHE", new { id = shgID });
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        [HttpPost]
        public async Task<IActionResult> UploadToDatabase(List<IFormFile> files, MonthlyAccountDocument monthlyAccountDocument, int? shgID, int? chapterID)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                var fileModel = new MonthlyAccountDocument
                {
                    DateOfUpload = DateTime.UtcNow,
                    DateOfAccount = monthlyAccountDocument.DateOfAccount,
                    FileType = file.ContentType,
                    Extension = extension,
                    Name = fileName,
                    Description = monthlyAccountDocument.Description,
                    TotalAmount = monthlyAccountDocument.TotalAmount,
                    UploadedBy = user.Name
            };
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    fileModel.Content = dataStream.ToArray();
                }
                _context.MonthlyAccountDocuments.Add(fileModel);
                _context.SaveChanges();
                if (shgID != null)
                {
                    AssociateDocumentToSHE(fileModel.Id, Convert.ToInt32(shgID));
                }
            }
            TempData["Message"] = "File successfully uploaded to Database";
            return RedirectToAction("Details", "SHE" , new { id = shgID });
        }

        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser")]
        public void AssociateDocumentToSHE(int documentID, int shgID)
        {
            SHGMonthlyDocument shgMonthlyDocument = new SHGMonthlyDocument
            {
                SHGId = shgID,
                FileId = documentID,
            };

            _context.Add(shgMonthlyDocument);
            _context.SaveChanges();
        }
    }
}
