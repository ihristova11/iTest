using iTest.Data.Models.Abstract;
using iTest.Data.Models.Enums;
using System;

namespace iTest.Data.Models
{
    public class UserTest : DataModel
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public TimeSpan RequestedTime { get; set; }

        public DateTime StartedOn { get; set; }

        public TimeSpan ExecutionTime { get; set; }

        public ResultStatus ResultStatus { get; set; }
    }
}