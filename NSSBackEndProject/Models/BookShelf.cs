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
        public Book Book { get; set; }

        //Require the User:
        [Required]
        public ApplicationUser User { get; set; }

    }
}
