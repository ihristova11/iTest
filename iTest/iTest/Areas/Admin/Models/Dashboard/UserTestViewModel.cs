using System;
using iTest.Data.Models.Enums;

namespace iTest.Web.Areas.Admin.Models.Dashboard
{
    public class UserTestViewModel
    {
        public string TestName { get; set; }

        public string UserName { get; set; }

        public string Category { get; set; }

        public TimeSpan RequestedTime { get; set; }

        public TimeSpan ExecutionTime { get; set; }

        public string Result { get; set; }
    }
}
