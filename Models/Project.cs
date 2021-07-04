using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KalamYouthForumWebApp.Models
{
    public class Project
    {
        [Key]
        public int ProjectIDKey { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }

        public string FilePath { get; set; }

        // a project can contain multiple images
        public ICollection<Image> Images { get; set; }
    }
}
