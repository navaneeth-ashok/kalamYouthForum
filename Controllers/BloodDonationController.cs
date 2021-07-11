using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KalamYouthForumWebApp.Data;
using KalamYouthForumWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace KalamYouthForumWebApp.Controllers
{
    public class BloodDonationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public BloodDonationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: BloodDonation
        public IActionResult Index(string State, string District)
        {
            BloodDonationDataController bloodDonationDataController = new BloodDonationDataController(_context, userManager);
            IEnumerable<DonorDTO> donors = new List<DonorDTO>();
            var state = State != null ? State : "";
            var district = District != null ? District : "";
            donors = bloodDonationDataController.FilterDonorList(state, district);
            return View(donors);
        }

    }
}
