﻿using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Users.Models
{
    public class UserCategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
