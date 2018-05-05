using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iTest.Web.Areas.Admin.Models.CustomValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iTest.Web.Areas.Admin.Models.ManageTest
{
    public class CreateTestViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Test's name must be entered!")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Test name's length must be at least 4 and maximum 50 symbols!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Test's duration must be specified!")]
        [Range(10, 120, ErrorMessage = "Test's duration must be atleast 10 minutes and maximum 2 hours!")]
        public int RequestedTime { get; set; }

        [DataType(DataType.Text)]
        public string AuthorId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required(ErrorMessage = "Test's category must be specified!")]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }

        [DataType(DataType.Text)]
        public string Status { get; set; }

        [Required(ErrorMessage = "Questions to your Test must be added!")]
        [CollectionCount(1, ErrorMessage = "Add at least one question to your Test!")]
        public ICollection<CreateQuestionViewModel> Questions { get; set; }
    }
}