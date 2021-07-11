using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KalamYouthForumWebApp.Data;
using KalamYouthForumWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace KalamYouthForumWebApp.Controllers
{
    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class BloodDonationDataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        
        public BloodDonationDataController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: api/FilterDonorList
        /// <summary>
        /// Web API to fetch the list of blood donors according to the input provided
        /// </summary>
        /// <param name="State">State you are searching for</param>
        /// <param name="District">District you are searching for</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DonorDTO> FilterDonorList(string State = null, string District = null)
        {
            System.Diagnostics.Debug.WriteLine("Web API called");
            List<DonorDTO> donorDTOs = new List<DonorDTO>();
            List<SHGMember> donorList = new List<SHGMember>();
            var users = new List<ApplicationUser>();
            if (State == null && District == null)
            {
                donorList = _context.shgMembers.ToList();
                users = userManager.Users.ToList();
            }
            else if (State == null && District != null)
            {
                donorList = _context.shgMembers.Where(s => s.District.Contains(District)).ToList();
                users = userManager.Users.Where(s => s.District.Contains(District)).ToList();
            } else if (District == null && State != null)
            {
                donorList = _context.shgMembers.Where(s => s.State.Contains(State)).ToList();
                users = userManager.Users.Where(s => s.State.Contains(State)).ToList();
            } else
            {
                donorList = _context.shgMembers.Where(p => p.State.Contains(State)).Where(s => s.District.Contains(District)).ToList();
                users = userManager.Users.Where(s => s.State.Contains(State)).Where(s => s.District.Contains(District)).ToList();
            }

            foreach (var donor in donorList)
            {
                if (donor.BloodDonation == true)
                {
                    DonorDTO donorDTO = new DonorDTO
                    {
                        Name = donor.Name,
                        Phone1 = donor.Phone1,
                        Phone2 = donor.Phone2,
                        District = donor.District,
                        State = donor.State,
                        BloodGroup = donor.BloodGroup
                    };
                    donorDTOs.Add(donorDTO);
                }

            }
            
            foreach (var user in users)
            {
                if (user.BloodDonation == true)
                {
                    DonorDTO donorDTO = new DonorDTO
                    {
                        Name = user.Name,
                        Phone1 = user.PhoneNumber,
                        Phone2 = user.PhoneNumber,
                        District = user.District,
                        State = user.State,
                        BloodGroup = user.BloodGroup
                    };
                    donorDTOs.Add(donorDTO);
                }
            }
            return donorDTOs;
        }
    }
}
