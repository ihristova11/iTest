using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Admin.Models
{
    public class CreateQuestionViewModel
    {
        [Required]
        public string Description { get; set; }

        public List<CreateAnswerViewModel> Answers { get; set; }
    }
}