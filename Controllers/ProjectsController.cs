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
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Project.ToListAsync());
        }

        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        [HttpGet]
        public IActionResult List()

        {
            List<ProjectImages> projectImages = new List<ProjectImages>();
            IEnumerable<Project> projects = _context.Project.ToList().OrderByDescending(p => p.ProjectIDKey).ToList();
            foreach (var project in projects)
            {
                ProjectImages ViewModel = new ProjectImages();
                ViewModel.Project = project;
                ViewModel.RelatedProjectImages = _context.Images.Where(i => i.Projects.Any(p => p.ProjectIDKey == project.ProjectIDKey));
                projectImages.Add(ViewModel);
            }
            
            return View(projectImages);
        }

        [HttpGet]
        public IActionResult ListProjects()

        {
            List<ProjectImages> projectImages = new List<ProjectImages>();
            IEnumerable<Project> projects = _context.Project.ToList().OrderByDescending(p => p.ProjectIDKey).ToList();
            foreach (var project in projects)
            {
                ProjectImages ViewModel = new ProjectImages();
                ViewModel.Project = project;
                ViewModel.RelatedProjectImages = _context.Images.Where(i => i.Projects.Any(p => p.ProjectIDKey == project.ProjectIDKey));
                projectImages.Add(ViewModel);
            }

            return View(projectImages);
        }

        // GET: Projects/Details/5
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        public IActionResult Details(int? id)
        {
            ProjectImages ViewModel = new ProjectImages();
            if (id == null)
            {
                return NotFound();
            }

            //var project = await _context.Project
            //    .FirstOrDefaultAsync(m => m.ProjectIDKey == id);

            var project = _context.Project.Find(id);
            ViewModel.Project = project;
            ViewModel.RelatedProjectImages = _context.Images.Where(i => i.Projects.Any(p => p.ProjectIDKey == id));



            if (project == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        [HttpGet]
        public IActionResult View(int? id)
        {
            ProjectImages ViewModel = new ProjectImages();
            if (id == null)
            {
                return NotFound();
            }

            //var project = await _context.Project
            //    .FirstOrDefaultAsync(m => m.ProjectIDKey == id);

            var project = _context.Project.Find(id);
            ViewModel.Project = project;
            ViewModel.RelatedProjectImages = _context.Images.Where(i => i.Projects.Any(p => p.ProjectIDKey == id));



            if (project == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        //[HttpGet]
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]

        public void AssociateImages(int projectID, int imageID)
        {
            Project SelectedProject = _context.Project.Include(p => p.Images).Where(a => a.ProjectIDKey == projectID).FirstOrDefault();
            System.Diagnostics.Debug.WriteLine(SelectedProject.Heading);
            
            Image SelectedImage = _context.Images.Find(imageID);

            SelectedProject.Images.Add(SelectedImage);
            _context.SaveChanges();
        }

        // GET: Projects/Create
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectIDKey,Heading,Content,FilePath")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.DateOfPublish = DateTime.Now;
                _context.Add(project);
                await _context.SaveChangesAsync();
                ImagesController imagesController = new ImagesController(_context);
                AssociateImages(project.ProjectIDKey, imagesController.GetDefaultImageDB());
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProjectImages ViewModel = new ProjectImages();
            var project = await _context.Project.FindAsync(id);
            ViewModel.Project = project;
            ViewModel.RelatedProjectImages = _context.Images.Where(i => i.Projects.Any(p => p.ProjectIDKey == id));
            if (project == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectIDKey,Heading,Content,FilePath")] Project project)
        {
            if (id != project.ProjectIDKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    project.DateOfPublish = DateTime.Now;
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectIDKey))
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
            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjectIDKey == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [Authorize(Roles = "Admin, Moderator, ProjectAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectIDKey == id);
        }
    }
}
