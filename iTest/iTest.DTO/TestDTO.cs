using iTest.Data.Models.Enums;
using System.Collections.Generic;

namespace iTest.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ExecutedTime { get; set; }

        public int ExecutionTime { get; set; }

        public Status Status { get; set; }

        public string CategoryName { get; set; }

        public string AuthorId { get; set; }

        public UserDTO Author { get; set; }

        public ICollection<UserTestDTO> Users { get; set; } = new List<UserTestDTO>();

        public ICollection<QuestionDTO> Questions { get; set; } = new List<QuestionDTO>();

        public ICollection<ResultDTO> Results { get; set; } = new List<ResultDTO>();
    }
}
