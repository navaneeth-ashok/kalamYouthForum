using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalamYouthForumWebApp.Models;

namespace KalamYouthForumWebApp.Models.ViewModels
{
    public class ProjectImages
    {
        public Project Project { get; set; }
        public IEnumerable<Image> RelatedProjectImages { get; set; }
    }
}
