using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSSBackEndProject.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string BookTitle { get; set; }

        [Required]
        public string BookImage { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Hashtags { get; set; }
    }
}
