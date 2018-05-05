using iTest.Data.Models;
using iTest.Data.Models.Enums;
using System;

namespace iTest.DTO
{
    public class UserTestDTO
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public int RequestedTime { get; set; }

        public DateTime StartedOn { get; set; }

        public TimeSpan ExecutionTime { get; set; }

        public ResultStatus ResultStatus { get; set; }
    }
}
