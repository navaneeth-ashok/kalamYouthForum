using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models
{
    public class NewsletterList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email ID")]
        public string EmailID { get; set; }

    }
}
