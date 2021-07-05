using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models.ViewModels
{
    public class RoleViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
