using iTest.Data.Models.Abstract;
using Microsoft.TeamFoundation.TestManagement.Client;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Implementations
{
    public class Question : DataModel, IIdentifiable<int>, IEditable, IDeletable, IAuditable
    {
        [Required]
        [MinLength(4)]
        [MaxLength(500)]
        public string Description { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public bool IsCorrect { get; set; }
    }
}
