using System.Collections.Generic;

namespace iTest.Web.Areas.Users.Models
{
    public class DetailsViewModel
    {
        public UserTestDetailsViewModel Test { get; set; }

        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}
