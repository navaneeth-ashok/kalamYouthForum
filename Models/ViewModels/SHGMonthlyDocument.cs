using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models.ViewModels
{
    
    public class SHGMonthlyDocument
    {
        public int Id { get; set; }
        public int SHGId { get; set; }
        [ForeignKey("SHGId")]
        public SHEModel SheModel { get; set; }

        public int FileId { get; set; }
        [ForeignKey("FileId")]
        public MonthlyAccountDocument MonthlyAccountDocument { get; set; }
    }
}
