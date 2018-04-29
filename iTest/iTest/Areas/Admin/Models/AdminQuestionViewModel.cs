using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iTest.Web.Areas.Admin.Models.CustomValidationAttributes;

namespace iTest.Web.Areas.Admin.Models
{
    public class AdminQuestionViewModel
    {
        [Required]
        public string Body { get; set; }

        [Required(ErrorMessage = "Please add Answers to your Question!")]
        [CollectionCount(2, ErrorMessage = "Please add atleast two Aswers to your Question!")]
        public IList<AdminAnswerViewModel> Answers { get; set; }
    }
}