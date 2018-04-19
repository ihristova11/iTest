using iTest.Data.Models.Contracts;
using iTest.Data.Models.Enums;
using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;

namespace iTest.Data.Models.Implementations
{
    public class Test : IIdentifiable<string>, IAuditable, IDeletable
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime RequestedTime { get; set; }

        public DateTime ExecutionTime { get; set; }

        public Status Status { get; set; }

        public Category Category { get; set; }

        public ICollection<Result> Results { get; set; } = new List<Result>();

        public ICollection<UserTest> Users { get; set; } = new List<UserTest>();

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
