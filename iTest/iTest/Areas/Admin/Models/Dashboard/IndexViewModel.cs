using System.Collections.Generic;

namespace iTest.Web.Areas.Admin.Models.Dashboard
{
    public class IndexViewModel
    {
        public string AdminName { get; set; }

        public IList<TestViewModel> Tests { get; set; }

        public IList<UserTestViewModel> UserResults { get; set; }
    }
}
