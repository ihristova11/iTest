using System;
using System.ComponentModel.DataAnnotations;
using iTest.Data.Models.Abstract;

namespace iTest.Data.Models
{
    public class UserTest : DataModel
    {
        public string UserId { get; set; }
        [Required]
        public User User { get; set; }

        public int TestId { get; set; }
        [Required]
        public Test Test { get; set; }

        [Required]
        public bool IsPassed { get; set; }

        public TimeSpan ExecutionTime { get; set; }

        public DateTime StartedOn { get; set; }
    }
}