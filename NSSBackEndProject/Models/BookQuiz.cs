using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSSBackEndProject.Models
{
    public class BookQuiz
    {
        [Key]
        public int BookQuizId { get; set; }


        //Require the Book Id: 
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }

        //Require the User:
        [Required]
        public ApplicationUser User { get; set; }

        //Require the Quiz Questions:
        [Required]
        public string QuizQuestions { get; set; }

        //Require the Quiz Answers:
        [Required]
        public string QuizAnswers { get; set; }
    }
}
