using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Users.Models.Details
{
    public class UserQuestionViewModel
    {
        public string Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        public List<UserAnswerViewModel> Answers { get; set; }

        public bool IsCorrect { get; set; }
    }
}
