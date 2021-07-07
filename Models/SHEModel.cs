using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models
{
    public class SHEModel
    {
        [Key]
        public int SHEId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please enter the name of the SHE", MinimumLength = 1)]
        [Display(Name = "SHG Name")]
        public string SHEName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "SHG Date of Formation")]
        public DateTime DateOfFormation { get; set; }

        [Required]
        [Display(Name = "Number of Members")]
        public int NumberOfMembers { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Name of Elected President")]
        public string ElectedPresident { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email of President")]
        public string PresidentEmail { get; set; }
        
        [Required]
        [Phone]
        [Display(Name = "Phone number of President")]
        public string PresidentPhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Name of Elected Secretary")]
        public string ElectedSecretary { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email of Secretary")]
        public string SecretaryEmail { get; set; }
        
        [Required]
        [Phone]
        [Display(Name = "Phone number of Secretary")]
        public string SecretaryPhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Name of Elected Treasurer")]
        public string ElectedTreasurer { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email of Treasurer")]
        public string TreasurerEmail { get; set; }
        
        [Required]
        [Phone]
        [Display(Name = "Phone number of Treasurer")]
        public string TreasurerPhoneNumber { get; set; }

        //Binding one SHE to one Chapter
        public IEnumerable<ChapterModel> ChapterModels { get; set; }

    }
}
