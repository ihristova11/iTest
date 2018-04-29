using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iTest.Data.Models.Enums;
using iTest.DTO;
using iTest.Web.Areas.Admin.Models.CustomValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iTest.Web.Areas.Admin.Models
{
    public class AdministerTestViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Test's name must be entered!")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Test name's length must be at least 4 and maximum 50 symbols!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Test's duration must be specified!")]
        [Range(10, 120, ErrorMessage = "Test's duration must be atleast 10 minutes and maximum 2 hours!")]
        public int RequestedTime { get; set; }

        public string AuthorId { get; set; }
        
        [Required(ErrorMessage = "Test's category must be specified!")]
        public CategoryDTO Category { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public Status Status { get; set; }

        [Required(ErrorMessage = "Questions to your Test must be added!")]
        [CollectionCount(1, ErrorMessage = "Add at least one question to your Test!")]
        public IList<AdministerQuestionViewModel> Questions { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
    }
}
