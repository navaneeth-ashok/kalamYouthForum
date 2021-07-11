using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models
{
    public class SHGMember
    {
        [Key]
        public int SHGMemberId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please enter the name of the SHE", MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }


        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Display(Name = "District")]
        public string District { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone number 1 - Call")]
        public string Phone1 { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone number 2 - Whatsapp")]
        public string Phone2 { get; set; }
        
        [Required]
        [Display(Name = "Blood Group")]
        public BloodGroupList BloodGroup { get; set; }

        [Required]
        [Display(Name = "SignUp for Blood Donation?")]
        public bool BloodDonation { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public GenderList Gender { get; set; }

        [ForeignKey("SHEModel")]
        public int SHEId { get; set; }
        public virtual SHEModel SHEModel { get; set; }
    }

    public class DonorDTO
    {
        public string Name { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public BloodGroupList BloodGroup { get; set; }
        
    }
}
