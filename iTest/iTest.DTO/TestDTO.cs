using System;
using System.Collections.Generic;
using iTest.Data.Models.Enums;

namespace iTest.DTO
{
    public class TestDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime RequestedTime { get; set; }

        public DateTime ExecutionTime { get; set; }

        public Status Status { get; set; }

        public CategoryDTO Category { get; set; }

        public ICollection<ResultDTO> Results { get; set; } = new List<ResultDTO>();

        public ICollection<UserTestDTO> Users { get; set; } = new List<UserTestDTO>();
    }
}
