using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSSBackEndProject.Models
{
    public class FanFiction
    {
        [Key]
        public int FanFictionId { get; set; }

        [Required]
        public string BookTitle { get; set; }
        

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public string EssayTitle { get; set; }

        
        public string FileURL { get; set; }
        
        [Required]
        public string Comments { get; set; }

        [Required]
        public bool ApprovalRating { get; set;  }

    }
}
