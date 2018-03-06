using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSSBackEndProject.Models
{
    public class QuizQuestions
    {
        [Key]
        public int QuizQuestionsId { get; set; }

        [Required]
        public string Questions { get; set; }

    }
}
