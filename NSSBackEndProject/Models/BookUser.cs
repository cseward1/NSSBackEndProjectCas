using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSSBackEndProject.Models
{
    public class BookUser
    {

        [Key]
        // Field being indexed in db context
        public int BookUserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }

        public string Genre { get; set; }

        public bool Favorited { get; set; }
        public bool Watched { get; set; }

        public BookUser()
        {
            Favorited = false;
            Watched = false;
        }

    }
}
