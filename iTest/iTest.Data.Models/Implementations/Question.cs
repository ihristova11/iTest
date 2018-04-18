﻿using iTest.Data.Models.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;

namespace iTest.Data.Models.Implementations
{
    public class Question : IIdentifiable<string>, IAuditable, IDeletable
    {
        public string Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Description { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
