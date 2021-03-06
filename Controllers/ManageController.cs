using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Controllers
{
    public class ManageController : Controller
    {
        [Authorize(Roles = "Admin, Moderator, Chapter, SHGUser, PageAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
