using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models.ViewModels
{
    public class SHGMonthlyAccount
    {
        public SHEModel SHEModel { get; set; }
        public IEnumerable<MonthlyAccountDocument> MonthlyAccountDocument { get; set; }
    }
}
