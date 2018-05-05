using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Admin.Models.ManageTest
{
    public class CreateAnswerViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        public bool IsCorrect { get; set; }
    }
}