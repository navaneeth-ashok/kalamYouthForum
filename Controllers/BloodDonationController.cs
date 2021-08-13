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
        public IActionResult Index(string State, string District, string BloodGroup)
        {
            BloodDonationDataController bloodDonationDataController = new BloodDonationDataController(_context, userManager);
            IEnumerable<DonorDTO> donors = new List<DonorDTO>();
            var state = State != null ? State : "";
            var district = District != null ? District : "";
            var bloodgroup = BloodGroup != null ? BloodGroup : "";
            //var donorList = _context.shgMembers.Select(s => s.BloodGroup).ToList();
            var donorList = _context.shgMembers.Select(t => ((string)(object)t.BloodGroup)).ToList();
            foreach (var d in donorList)
            {
                System.Diagnostics.Debug.WriteLine(d);
            }
            donors = bloodDonationDataController.FilterDonorList(state, district, bloodgroup);
            ViewBag.State = State;
            ViewBag.District = District;
            ViewBag.BloodGroup = BloodGroup;
            return View(donors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Notify(string State, string District, string BloodGroup, string Name, string PhoneNumber)
        {
            BloodDonationDataController bloodDonationDataController = new BloodDonationDataController(_context, userManager);
            IEnumerable<DonorDTO> donors = new List<DonorDTO>();
            var state = State != null ? State : "";
            var district = District != null ? District : "";
            var bloodgroup = BloodGroup != null ? BloodGroup : "";
            var donorList = _context.shgMembers.Select(t => ((string)(object)t.BloodGroup)).ToList();
            donors = bloodDonationDataController.FilterDonorList(state, district, bloodgroup);
            foreach(var donor in donors)
            {
                System.Diagnostics.Debug.WriteLine(donor.Phone1);
                System.Diagnostics.Debug.WriteLine(donor.Phone2);
                System.Diagnostics.Debug.WriteLine(donor.Name);
                System.Diagnostics.Debug.WriteLine(Name);
                System.Diagnostics.Debug.WriteLine(PhoneNumber);

            }
            ViewBag.Notification = "Notification has been sent successfully to the donors.";
            return RedirectToAction("Index");
        }

    }
}
