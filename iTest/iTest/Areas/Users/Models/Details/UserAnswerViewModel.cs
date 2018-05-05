using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Users.Models.Details
{
    public class UserAnswerViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
