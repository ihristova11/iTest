using iTest.Data.Models.Enums;
using System.Collections.Generic;

namespace iTest.Web.Areas.Admin.Models.Tests
{
    public class TestViewModel
    {
        public string Name { get; set; }

        public int RequestedTime { get; set; }

        public string AuthorId { get; set; }

        public string Category { get; set; }

        public Status Status { get; set; }

        public IList<CreateQuestionViewModel> Questions { get; set; }
    }
}
