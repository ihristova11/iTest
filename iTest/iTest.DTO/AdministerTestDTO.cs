using System.Collections.Generic;

namespace iTest.DTO
{
    public class AdministerTestDTO
    {
        public string Id { get; set; }

        public string TestName { get; set; }

        public string CategoryName { get; set; }

        public int RequestedTime { get; set; }

        public bool IsPublished { get; set; }

        public string CreatedByUserId { get; set; }

        public ICollection<AdministerQuestionDTO> Questions { get; set; }
    }
}
