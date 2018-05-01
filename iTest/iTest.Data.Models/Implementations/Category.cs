using iTest.Data.Models.Abstract;
using Microsoft.TeamFoundation.TestManagement.Client;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Implementations
{
    public class Category : DataModel, IIdentifiable<int>, IEditable, IDeletable, IAuditable
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Test> Tests { get; set; } = new List<Test>();
    }
}