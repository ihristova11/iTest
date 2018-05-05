using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iTest.Web.Areas.Admin.Models.CustomValidationAttributes;

namespace iTest.Web.Areas.Admin.Models.ManageTest
{
    public class CreateQuestionViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Questions to your Test must be added!")]
        [CollectionCount(2, ErrorMessage = "Add at least two answers to your Test!")]
        public ICollection<CreateAnswerViewModel> Answers { get; set; }
    }
}