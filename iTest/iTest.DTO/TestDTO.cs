using iTest.Data.Models.Enums;
using iTest.Data.Models.Implementations;
using System;
using System.Collections.Generic;

namespace iTest.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public int RequestedTime { get; set; }

        public int ExecutionTime { get; set; }

        public Status Status { get; set; }

        public CategoryDTO Category { get; set; }

        public string AuthorId { get; set; }

        public UserDTO Author { get; set; }

        public ICollection<UserTest> Users { get; set; } = new List<UserTest>();

        public ICollection<Question> Questions { get; set; } = new List<Question>();

        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
