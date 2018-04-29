using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Admin.Models
{
    public class AdminAnswerViewModel
    {
        [Required]
        public string Description { get; set; }

        public bool IsCorrect { get; set; }
    }
}