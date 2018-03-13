using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSSBackEndProject.Models
{
    public class BookShelf
    {
        [Key]
        public int BookShelfId { get; set; }

        //Require the Book Id: 
        [Required]
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



        //Require the User:
        [Required]
        public ApplicationUser User { get; set; }

    }
}
