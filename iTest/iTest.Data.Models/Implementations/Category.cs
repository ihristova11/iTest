using iTest.Data.Models.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Implementations
{
    public class Category : DataModel, IIdentifiable<int>, IEditable, IDeletable
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

        public ICollection<Test> Tests { get; set; } = new List<Test>();
    }
}