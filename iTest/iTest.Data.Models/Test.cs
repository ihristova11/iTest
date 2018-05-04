using iTest.Data.Models.Abstract;
using iTest.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models
{
    public class Test : DataModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public int RequestedTime { get; set; }

        public int ExecutionTime { get; set; }

        public Status Status { get; set; }

        [Required]
        public Category Category { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public User Author { get; set; }

        public ICollection<UserTest> Users { get; set; } = new List<UserTest>();

        public ICollection<Question> Questions { get; set; } = new List<Question>();

        public ICollection<Result> Results { get; set; } = new List<Result>();

    }
}
