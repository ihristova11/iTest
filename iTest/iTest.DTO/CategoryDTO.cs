﻿using iTest.Data.Models;
using System.Collections.Generic;

namespace iTest.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorId { get; set; }

        public UserDTO Author { get; set; }

        public ICollection<Test> Tests { get; set; } = new List<Test>();
    }
}
