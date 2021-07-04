using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalamYouthForumWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using KalamYouthForumWebApp.Models;
using KalamYouthForumWebApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace KalamYouthForumWebApp.ViewComponents
{
    public class ProjectList : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ProjectList(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ProjectImages> projectImages = new List<ProjectImages>();
            IEnumerable<Project> projects = _context.Project.ToList().OrderByDescending(p => p.ProjectIDKey).Take(3).ToList();
            foreach (var project in projects)
            {
                ProjectImages ViewModel = new ProjectImages();
                ViewModel.Project = project;
                ViewModel.RelatedProjectImages = _context.Images.Where(i => i.Projects.Any(p => p.ProjectIDKey == project.ProjectIDKey));
                projectImages.Add(ViewModel);
            }
            return View("ProjectList", projectImages);
        }
    }
}
