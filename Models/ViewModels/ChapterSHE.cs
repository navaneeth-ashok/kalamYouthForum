using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models.ViewModels
{
    public class ChapterSHE
    {
        public ChapterModel Chapter { get; set; }
        public IEnumerable<SHEModel> SHEModels { get; set; }
    }
}
