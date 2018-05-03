using iTest.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Users.Models
{
    public class TestDetailsViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RequestedTime { get; set; }

        [Required]
        public CategoryDTO Category { get; set; }

        public ICollection<QuestionDTO> Questions { get; set; }
    }
}
