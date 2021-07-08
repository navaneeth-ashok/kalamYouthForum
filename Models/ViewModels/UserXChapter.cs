using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models.ViewModels
{
    public class UserXChapter
    {
        [Key]
        public int Id { get; set; }

        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser ApplicationUser { get; set; }

        public int ChapterID { get; set; }
        [ForeignKey("ChapterID")]
        public ChapterModel Chapter { get; set; }
    }
}
