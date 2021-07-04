using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageDataURL { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
