using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Admin.Models.Categories
{
    public class AdminCategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
