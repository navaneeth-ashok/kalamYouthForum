using KalamYouthForumWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalamYouthForumWebApp.Data;

namespace KalamYouthForumWebApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;

        public AdministrationController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.roleManager = roleManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<IdentityRole> roleManagers = roleManager.Roles.ToList();
            List<RoleViewModel> roleViewModels = new List<RoleViewModel>();
            foreach( var role in roleManagers)
            {
                RoleViewModel roleViewModel = new RoleViewModel
                {
                    RoleName = role.Name,
                    Id = role.Id
                };
                roleViewModels.Add(roleViewModel);
            }
            return View(roleViewModels);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = _context.Roles.FirstOrDefault(r => r.Id == id);
            
            if (role == null)
            {
                return NotFound();
            }

            RoleViewModel roleViewModel = new RoleViewModel
            {
                RoleName = role.Name
            };

            return View(roleViewModel);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = roleViewModel.RoleName
                };

                IdentityResult identityResult = await roleManager.CreateAsync(identityRole);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(roleViewModel);
        }

    }
}
