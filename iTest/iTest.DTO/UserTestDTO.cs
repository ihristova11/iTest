using System;
using iTest.Data.Models;

namespace iTest.DTO
{
    public class UserTestDTO
    {
        public string UserId { get; set; }
        
        public User User { get; set; }

        public int TestId { get; set; }
       
        public Test Test { get; set; }

        public bool IsPassed { get; set; }

        public TimeSpan ExecutionTime { get; set; }

        public DateTime StartedOn { get; set; }
    }
}
