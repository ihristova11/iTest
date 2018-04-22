using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iTest.Data.Models.Implementations;
using iTest.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iTest.Web.Areas.Admin.Models
{
    public class TestViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RequestedTime { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public CategoryDTO Category { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}