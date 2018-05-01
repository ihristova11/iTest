using iTest.Data.Models;
using iTest.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Admin.Models
{
    public class AdminTestViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public int RequestedTime { get; set; }

        public string Author { get; set; }

        [Required]
        public CategoryDTO Category { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}