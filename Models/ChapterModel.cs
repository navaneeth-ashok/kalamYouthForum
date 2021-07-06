using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models
{
    public class ChapterModel
    {
        [Key]
        public int ChapterID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Name of Panchayat")]
        public string Panchayat { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Name of Muncipality")]
        public string Muncipality { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Name of Taluk")]
        public string Taluk { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Name of Constituency")]
        public string Constituency { get; set; }
        
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Full Address of the Office")]
        public string OfficeAddress { get; set; }

        // one chapter can contain multiple SHE inside it
        public ICollection<SHEModel> SHEModels { get; set; }

    }
}
