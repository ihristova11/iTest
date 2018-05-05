using iTest.Web.Areas.Users.Models.Details;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Users.Models.Dashboard
{
    public class UserTestViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public IEnumerable<UserQuestionViewModel> Questions { get; set; }
    }
}
