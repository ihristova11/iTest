using iTest.Data.Models.Contracts;
using iTest.Data.Models.Enums;
using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Implementations
{
    public class Test : IIdentifiable<string>, IAuditable, IDeletable
    {
        public string Id { get; set; }

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

        [Required]
        public Status Status { get; set; }

        [Required]
        public Category Category { get; set; }

        public ICollection<Result> Results { get; set; } = new List<Result>();

        public ICollection<UserTest> Users { get; set; } = new List<UserTest>();
    }
}
