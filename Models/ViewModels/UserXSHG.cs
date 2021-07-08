using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models.ViewModels
{
    public class UserXSHG
    {
        [Key]
        public int Id { get; set; }

        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser ApplicationUser { get; set; }

        public int SHGID { get; set; }
        [ForeignKey("SHGID")]
        public SHEModel SHEModel { get; set; }
    }
}
