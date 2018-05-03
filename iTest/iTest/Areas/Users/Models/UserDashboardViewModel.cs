using System.Collections.Generic;

namespace iTest.Web.Areas.Users.Models
{
    public class UserDashboardViewModel
    {
        public string Author { get; set; }

        public IEnumerable<UserCategoryViewModel> Categories { get; set; }

        public IEnumerable<UserTestViewModel> Tests { get; set; }
    }
}
