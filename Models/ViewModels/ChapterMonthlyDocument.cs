using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models.ViewModels
{
    public class ChapterMonthlyDocument
    {
        public int Id { get; set; }
        public int ChapterID { get; set; }
        [ForeignKey("ChapterID")]
        public ChapterModel ChapterModel { get; set; }

        public int FileId { get; set; }
        [ForeignKey("FileId")]
        public MonthlyAccountDocument MonthlyAccountDocument { get; set; }
    }
}
