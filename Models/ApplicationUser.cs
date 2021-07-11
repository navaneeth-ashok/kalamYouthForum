using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public DateTime Dob { get; set; }

        public string LocalBody { get; set; }

        public string District { get; set; }

        public string State { get; set; }

        public GenderList Gender { get; set; }

        public BloodGroupList BloodGroup { get; set; }

        [Display(Name = "SignUp for Blood Donation?")]
        public bool BloodDonation { get; set; }
    }

    public enum GenderList
    {
        Male,
        Female,
        Others
    }


    public enum BloodGroupList
    {
        [Display(Name = "A+")]
        APositive,
        [Display(Name = "A-")]
        ANegative,
        [Display(Name = "B+")]
        BPositive,
        [Display(Name = "B-")]
        BNegative,
        [Display(Name = "O+")]
        OPositive,
        [Display(Name = "O-")]
        ONegative,
        [Display(Name = "AB+")]
        ABPositive,
        [Display(Name = "AB-")]
        ABNegative,
    }
}
