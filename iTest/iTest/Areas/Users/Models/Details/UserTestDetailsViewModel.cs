using iTest.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace iTest.Web.Areas.Users.Models.Details
{
    public class UserTestDetailsViewModel
    {
        public string Name { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime SubmittedOn { get; set; }

        public ResultStatus ResultStatus { get; set; }

        public TimeSpan ExecutedTime { get; set; }

        public List<UserQuestionViewModel> Questions { get; set; }
    }
}
