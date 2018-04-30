using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iTest.Web.Areas.Admin.Models.CustomValidationAttributes;

namespace iTest.Web.Areas.Admin.Models
{
    public class AdminQuestionViewModel
    {
        [Required(ErrorMessage = "Please enter the Question's description!")]
        [StringLength(500, ErrorMessage = "Question description's length must be maximum 500 symbols!")]
        public string DescriptionPlainText { get; set; }

        [Required]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please add Answers to your Question!")]
        [CollectionCount(2, ErrorMessage = "Please add atleast two Aswers to your Question!")]
        public IList<AdminAnswerViewModel> Answers { get; set; }
    }
}