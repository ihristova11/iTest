using iTest.DTO;
using System.Collections.Generic;

namespace iTest.Web.Areas.Users.Models
{
    public class QuestionViewModel
    {
        public string Description { get; set; }

        public ICollection<AnswerDTO> Answers { get; set; }

        public bool IsCorrect { get; set; }
    }
}