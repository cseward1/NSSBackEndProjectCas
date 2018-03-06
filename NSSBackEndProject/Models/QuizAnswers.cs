using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSSBackEndProject.Models
{
    public class QuizAnswers
    {
        [Key]
        public int QuizAnswersId { get; set; }

        [Required]
        public string Answers { get; set; }

        //Require the User:
        [Required]
        public ApplicationUser User { get; set; }

    }
}
