using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iTest.Web.Areas.Admin.Models.CustomValidationAttributes;

namespace iTest.Web.Areas.Admin.Models
{
    public class CreateQuestionViewModel
    {
        [Required]
        public string Description { get; set; }
        
        public IList<CreateAnswerViewModel> Answers { get; set; }
    }
}