using iTest.Web.Areas.Users.Models.Details;
using System.Collections.Generic;

namespace iTest.Web.Areas.Users.Models.Dashboard
{
    public class UserTestViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserQuestionViewModel> Questions { get; set; }
    }
}
