using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models.ViewModels
{
    public class RoleUserListViewModel
    {
        [Key]
        public string Id { get; set; }
        public string RoleName { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}
