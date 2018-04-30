using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Admin.Models
{
    public class AdminAnswerViewModel
    {
        [Required(ErrorMessage = "Please enter the Answer's content!")]
        [StringLength(500, ErrorMessage = "Answers content's length must be maximum 500 symbols!")]
        public string ContentPlaintext { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsCorrect { get; set; }
    }
}