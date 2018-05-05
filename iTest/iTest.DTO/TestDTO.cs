using iTest.Data.Models.Enums;
using System.Collections.Generic;

namespace iTest.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RequestedTime { get; set; }

        public int ExecutionTime { get; set; }

        public Status Status { get; set; }

        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }

        public string CategoryName { get; set; }

        public string AuthorId { get; set; }
        public UserDTO Author { get; set; }

        public IEnumerable<QuestionDTO> Questions { get; set; }
    }
}
