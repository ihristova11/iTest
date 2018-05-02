using iTest.Data.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models
{
    public class Question : DataModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(500)]
        public string Description { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public bool IsCorrect { get; set; }
    }
}
