using iTest.Data.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models
{
    public class Category : DataModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Test> Tests { get; set; } = new List<Test>();
    }
}