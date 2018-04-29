using iTest.Data.Models.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Implementations
{
    public class Question : DataModel, IIdentifiable<int>, IEditable, IDeletable
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(500)]
        public string Description { get; set; }

        public IList<Answer> Answers { get; set; } = new List<Answer>();

        public bool IsCorrect { get; set; }
        
    }
}
