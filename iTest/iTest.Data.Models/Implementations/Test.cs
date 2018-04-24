using iTest.Data.Models.Contracts;
using iTest.Data.Models.Enums;
using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Implementations
{
    public class Test : IIdentifiable<int>, IAuditable, IDeletable
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
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequestedTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExecutionTime { get; set; }

        public Status Status { get; set; }

        [Required]
        public Category Category { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public ICollection<UserTest> Users { get; set; } = new List<UserTest>();

        public ICollection<Question> Questions { get; set; } = new List<Question>();

        public ICollection<Result> Results { get; set; } = new List<Result>();

    }
}
