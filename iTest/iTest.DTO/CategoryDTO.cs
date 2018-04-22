using System.Collections.Generic;
using iTest.Data.Models.Implementations;

namespace iTest.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Test> Tests { get; set; } = new List<Test>();
    }
}
