using iTest.Data.Models.Implementations;
using System;
using System.Collections.Generic;

namespace iTest.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Name { get; set; }

        public ICollection<Test> Tests { get; set; } = new List<Test>();
    }
}
