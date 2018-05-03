using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iTest.Web.Areas.Admin.Models.CustomValidationAttributes;

namespace iTest.Web.Areas.Admin.Models
{
    public class CreateQuestionViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        public ICollection<CreateAnswerViewModel> Answers { get; set; }
    }
}