using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
