using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Admin.Models
{
    public class CreateAnswerViewModel
    {
        [Required]
        public string Content { get; set; }

        public bool IsCorrect { get; set; }
    }
}