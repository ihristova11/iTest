using iTest.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace iTest.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime RequestedTime { get; set; }

        public DateTime ExecutionTime { get; set; }

        public Status Status { get; set; }

        public CategoryDTO Category { get; set; }

        public ICollection<ResultDTO> Results { get; set; } = new List<ResultDTO>();

        public ICollection<UserTestDTO> Users { get; set; } = new List<UserTestDTO>();
    }
}
