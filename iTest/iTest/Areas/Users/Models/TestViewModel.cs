using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Users.Models
{
    public class TestViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
