using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSSBackEndProject.Models
{
    public class Recommendations
    {
        [Key]
        public int RecommendationsId { get; set; }

        //Require a Note section for a friend/user to send a message tagged with the book recommended:
        [Required]
        public string Note { get; set; }


        //Require the Book Id: 
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }

        //Require the User Id (I will have a Sender and a Reciever though....)
        //QUESTION: Do I need to have more than one user Requirement or is one fine? (Because I will have a user and sender)
        [Required]
        public ApplicationUser User { get; set; }


    }
}
