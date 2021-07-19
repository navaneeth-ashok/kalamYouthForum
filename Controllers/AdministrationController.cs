using KalamYouthForumWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalamYouthForumWebApp.Data;
using KalamYouthForumWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace KalamYouthForumWebApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            _context = context;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

            var userList = new List<ApplicationUser>(); 

            foreach(var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                { 
                    userList.Add(user);
                }
            }
            var model = new RoleUserListViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
                Users = userList
            };
            
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [HttpGet]
        public void SendConfirmationMail(string MessageToken, string Email, string UserName)
        {
            AuthMessageSenderOptions authMessageSenderOptions = new AuthMessageSenderOptions();
            var client = new SendGridClient(authMessageSenderOptions.SendGridKey);
            var from = new EmailAddress("kalamyouthforumdev@gmail.com", "Kalam Youth Forum");
            var subject = "Kalam Youth Forum Account Registration";
            var to = new EmailAddress(Email, UserName);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
            System.Diagnostics.Debug.WriteLine(response.Status);
            System.Diagnostics.Debug.WriteLine(response.Result);
        }


    }
}
