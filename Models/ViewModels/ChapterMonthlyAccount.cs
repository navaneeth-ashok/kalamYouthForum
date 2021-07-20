using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models.ViewModels
{
    public class ChapterMonthlyAccount
    {
        public ChapterSHE ChapterSHE { get; set; }
        public IEnumerable<MonthlyAccountDocument> MonthlyAccountDocument { get; set; }
    }
}
