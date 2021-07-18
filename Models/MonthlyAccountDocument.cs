using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models
{
    public class MonthlyAccountDocument
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Content { get; set; }

        [Required]
        [Column(TypeName = "decimal(20, 2)")]
        [Display(Name = "Total Amount mentioned")]
        public decimal TotalAmount { get; set; }
        
        [Required]
        [Display(Name = "Detailed description of the file")]
        public string Description { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }

        public DateTime DateOfUpload { get; set; }

        [Required]
        [Display(Name = "Choose the First Day of the Month to which the report is attached")]
        [DataType(DataType.Date)]
        public DateTime DateOfAccount { get; set; }

        public string UploadedBy { get; set; }
    }
}
