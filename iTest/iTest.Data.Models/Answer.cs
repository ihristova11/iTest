using iTest.Data.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models
{
    public class Answer : DataModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(500)]
        public string Description { get; set; }

        public bool IsCorrect { get; set; }
    }
}