using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSSBackEndProject.Models
{
    public class Friendship
    {
        [Key]
        public int FriendshipId { get; set; }

        //require a boolean to hold the sttaus of the relationship between users:
        [Required]
        public bool FriendshipStatus { get; set; }

        //require the user(s) Information
        //QUESTION: Do I need to require more than one user since a userSender and a userReciever information will be stored within this table? YES, you do. I have made changes to correct this. 
        [Required]
        public ApplicationUser UserSender { get; set; }

        [Required]
        public ApplicationUser UserReciever { get; set; }
    }
}
