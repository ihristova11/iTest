using System.Collections.Generic;

namespace iTest.DTO
{
    public class QuestionDTO
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public ICollection<AnswerDTO> Answers { get; set; } = new List<AnswerDTO>();

        public bool IsCorrect { get; set; }
    }
}
