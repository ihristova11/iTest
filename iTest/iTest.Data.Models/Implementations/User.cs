using iTest.Data.Models.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Implementations
{
    public class User : IdentityUser, IEditable, IDeletable
    {
        public bool IsDeleted { get; set; }

        public ICollection<UserTest> Tests { get; set; } = new List<UserTest>();

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
    }
}
