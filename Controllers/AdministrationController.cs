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
        private readonly UserManager<IdentityUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            _context = context;
            this.userManager = userManager;
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
        public async Task<IActionResult> Details(string id)
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

            var userList = new List<IdentityUser>(); 

            foreach(var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                { 
                    userList.Add(user);
                }
                System.Diagnostics.Debug.WriteLine(user.Email);
            }
            var model = new RoleUserListViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
                Users = userList
            };
            
            return View(model);
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

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleID)
        {
            ViewBag.roleID = roleID;

            var role = await roleManager.FindByIdAsync(roleID);

            if(role == null)
            {
                ViewBag.ErrorMessage = "Role with id:" + roleID + " not found";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();
            foreach( var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                } else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if( role == null)
            {
                ViewBag.ErrorMessage = "Role not found";
                return View("NotFound"); 
            }

            //foreach(var user in model)
            //{
                
            //    System.Diagnostics.Debug.WriteLine("######################################");
            //    System.Diagnostics.Debug.WriteLine(user.UserName);
            //    System.Diagnostics.Debug.WriteLine(user.UserId);
            //    System.Diagnostics.Debug.WriteLine(user.IsSelected);
            //    System.Diagnostics.Debug.WriteLine("######################################");

            //}

            foreach (var user in model)
            {
                var userNew = await userManager.FindByIdAsync(user.UserId);
                IdentityResult result = null;
                if (user.IsSelected && !(await userManager.IsInRoleAsync(userNew, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(userNew, role.Name);
                }
                else if (!user.IsSelected && (await userManager.IsInRoleAsync(userNew, role.Name)))
                {
                    result = await userManager.RemoveFromRoleAsync(userNew, role.Name);
                }
                else
                {
                    continue;
                }

            }

            return RedirectToAction("Details", new { Id = roleId });
        }

    }
}
