using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Implementations
{
    public class UserTest
    {
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        public int TestId { get; set; }

        [Required]
        public Test Test { get; set; }
    }
}