using System.Collections.Generic;

namespace iTest.Web.Areas.Users.Models.Details
{
    public class UserQuestionViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public IEnumerable<UserAnswerViewModel> Answers { get; set; }

        public bool IsCorrect { get; set; }

        public string AnswerId { get; set; }
    }
}
