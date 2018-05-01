using iTest.Data.Models.Abstract;
using Microsoft.TeamFoundation.TestManagement.Client;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Implementations
{
    public class Answer : DataModel, IIdentifiable<int>, IEditable, IDeletable, IAuditable
    {
        [Required]
        [MinLength(4)]
        [MaxLength(500)]
        public string Description { get; set; }

        public bool IsCorrect { get; set; }
    }
}