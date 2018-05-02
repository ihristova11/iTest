using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iTest.Data.Models.Enums;
using iTest.DTO;
using iTest.Web.Areas.Admin.Models.CustomValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iTest.Web.Areas.Admin.Models
{
    public class TestViewModel
    {
        public string Name { get; set; }

        public int RequestedTime { get; set; }

        public string AuthorId { get; set; }

        public string Category { get; set; }

        public Status Status { get; set; }

        public IList<CreateQuestionViewModel> Questions { get; set; }
    }
}
