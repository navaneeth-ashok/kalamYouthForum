using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KalamYouthForumWebApp.Data;
using KalamYouthForumWebApp.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace KalamYouthForumWebApp.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        public IActionResult UploadImageDB(int projectID=1)
        {
            System.Diagnostics.Debug.WriteLine("Image IDs");
            int imgID = 0;
            foreach (var file in Request.Form.Files)
            {
                Image img = new Image();
                img.ImageTitle = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();

                string imageBase64Data = Convert.ToBase64String(img.ImageData);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                img.ImageDataURL = imageDataURL;
                imgID = img.Id;
                _context.Images.Add(img);
                _context.SaveChanges();
                ProjectsController projectsController = new ProjectsController(_context);
                System.Diagnostics.Debug.WriteLine(img.Id);
                projectsController.AssociateImages(projectID, img.Id);
                
            }
            return RedirectToAction("Edit" , "Projects", new { id = projectID });
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpGet]
        public IActionResult UploadDefaultImage()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Moderator")]
        // Upload default Image
        [HttpPost]
        public IActionResult UploadDefaultImageDB()
        {
            // check whether any existing default Image is present or not
            int defaultID = GetDefaultImageDB();
            if(defaultID != -1)
            {
                // rename the existing default image
                var currentDefaultImage = _context.Images.Find(defaultID);
                currentDefaultImage.ImageTitle = "old_" + currentDefaultImage.ImageTitle;
                _ = Edit(defaultID, currentDefaultImage);
                //await _context.SaveChangesAsync();
            }
            var file = Request.Form.Files.First();
            Image img = new Image();
            img.ImageTitle = "default_image_project_thumbnail" + file.FileName;

            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            img.ImageData = ms.ToArray();

            ms.Close();
            ms.Dispose();

            string imageBase64Data = Convert.ToBase64String(img.ImageData);
            string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
            img.ImageDataURL = imageDataURL;
            _context.Images.Add(img);
            _context.SaveChanges();
            ProjectsController projectsController = new ProjectsController(_context);
            return RedirectToAction("Index", "Images");
        }

        [Authorize(Roles = "Admin, Moderator")]
        public int GetDefaultImageDB()
        {
            var image = _context.Images.Where(i => i.ImageTitle.StartsWith("default_image_project_thumbnail")).FirstOrDefault();
            if (image != null)
            {
                return image.Id;
            }
            else return -1;
        }

        [Authorize(Roles = "Admin, Moderator")]
        // GET: Images
        public async Task<IActionResult> Index()
        {
            return View(await _context.Images.ToListAsync());
        }

        [Authorize(Roles = "Admin, Moderator")]
        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);

            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }


        // GET: Images/Create
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageTitle,ImageData")] Image image)
        {
            if (ModelState.IsValid)
            {
                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }

        // GET: Images/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageTitle,ImageData")] Image image)
        {
            if (id != image.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.Id))
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
            return View(image);
        }

        // GET: Images/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Images/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.Images.FindAsync(id);
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
