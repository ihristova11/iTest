﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iTest.Data.Models.Enums;
using iTest.DTO;
using iTest.Web.Areas.Admin.Models.CustomValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iTest.Web.Areas.Admin.Models
{
    public class CreateTestViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Range(1, 1000, ErrorMessage = "Time must be positive value, between 1 and 1000 minutes")]
        public int RequestedTime { get; set; }

        [DataType(DataType.Text)]
        public string AuthorId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        
        [DataType(DataType.Text)]
        public string Category { get; set; }

        [DataType(DataType.Text)]
        public string Status { get; set; }

        public ICollection<CreateQuestionViewModel> Questions { get; set; }
    }
}