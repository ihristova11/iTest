using System.Collections.Generic;

namespace iTest.Web.Areas.Users.Models
{
    public class DashboardViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public IEnumerable<TestViewModel> Tests { get; set; }
    }
}
