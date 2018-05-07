using iTest.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace iTest.Web.Areas.Users.Models.Details
{
    public class UserTestDetailsViewModel
    {
        public string Name { get; set; }

        public string CategoryName { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime SubmittedOn { get; set; }

        public TimeSpan RequestedTime { get; set; }

        public TimeSpan ExecutionTime { get; set; }

        public ResultStatus ResultStatus { get; set; }

        public IEnumerable<UserQuestionViewModel> Questions { get; set; }

        public int CorrectAnswers { get; set; }

        public int QuestionsCount { get; set; }

        public string UserId { get; set; }
    }
}
