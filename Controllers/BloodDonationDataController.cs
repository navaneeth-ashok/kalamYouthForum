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
        public IEnumerable<DonorDTO> FilterDonorList(string State = null, string District = null, string BloodGroup = null)
        {
            System.Diagnostics.Debug.WriteLine("Web API called");
            List<DonorDTO> donorDTOs = new List<DonorDTO>();
            List<SHGMember> donorList = new List<SHGMember>();
            var users = new List<ApplicationUser>();
            //if (State == null && District == null && BloodGroup == null)
            //{
            //    System.Diagnostics.Debug.WriteLine("State Null District Null Blood Null");
            //    donorList = _context.shgMembers.ToList();
            //    users = userManager.Users.ToList();
            //}
            //else if (State == null && District != null && BloodGroup == null)
            //{
            //    System.Diagnostics.Debug.WriteLine("State Null District Yes Blood Null");
            //    donorList = _context.shgMembers.Where(s => s.District.Contains(District)).ToList();
            //    users = userManager.Users.Where(s => s.District.Contains(District)).ToList();
            //} else if (District == null && State != null && BloodGroup == null)
            //{
            //    System.Diagnostics.Debug.WriteLine("State Yes District Null Blood Null");
            //    donorList = _context.shgMembers.Where(s => s.State.Contains(State)).ToList();
            //    users = userManager.Users.Where(s => s.State.Contains(State)).ToList();
            //}
            //else if (State == null && District == null && BloodGroup != null)
            //{
            //    System.Diagnostics.Debug.WriteLine("State Null District Null Blood Yes");
            //    BloodGroupList bloodGroup = (BloodGroupList)Convert.ToInt32(BloodGroup);
            //    donorList = _context.shgMembers.Where(s => s.BloodGroup.ToString().Contains(bloodGroup.ToString())).ToList();
            //    users = userManager.Users.Where(s => s.BloodGroup.ToString().Contains(BloodGroup)).ToList();
            //}
            //else if (State == null && District != null && BloodGroup != null)
            //{
            //    System.Diagnostics.Debug.WriteLine("State Null District Yes Blood Yes");
            //    donorList = _context.shgMembers.Where(s => s.District.Contains(District)).ToList();
            //    users = userManager.Users.Where(s => s.District.Contains(District)).ToList();
            //}
            //else if (District == null && State != null && BloodGroup != null)
            //{
            //    System.Diagnostics.Debug.WriteLine("State Yes District Null Blood Yes");
            //    donorList = _context.shgMembers.Where(s => s.State.Contains(State)).ToList();
            //    users = userManager.Users.Where(s => s.State.Contains(State)).ToList();
            //}

            //else
            //{
            
            if(BloodGroup == null || BloodGroup == "" || BloodGroup == "Any")
            {
                donorList = _context.shgMembers.Where(p => p.State.Contains(State)).Where(s => s.District.Contains(District)).ToList();
                users = userManager.Users.Where(s => s.State.Contains(State)).Where(s => s.District.Contains(District)).ToList();
            } else
            {
                BloodGroupList bloodGroup = (BloodGroupList)Convert.ToInt32(BloodGroup);
                System.Diagnostics.Debug.WriteLine("#######################");
                System.Diagnostics.Debug.WriteLine(bloodGroup.ToString());
                System.Diagnostics.Debug.WriteLine("#######################");
                donorList = _context.shgMembers.Where(p => p.State.Contains(State)).Where(s => s.District.Contains(District)).Where(t => ((string)(object)t.BloodGroup) == BloodGroup).ToList();
                users = userManager.Users.Where(s => s.State.Contains(State)).Where(s => s.District.Contains(District)).Where(t => ((string)(object)t.BloodGroup) == BloodGroup).ToList();
            }
                
            //}

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
