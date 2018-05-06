using System.Collections.Generic;

namespace iTest.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public IEnumerable<AnswerDTO> Answers { get; set; }

        public bool IsCorrect { get; set; }
    }
}
