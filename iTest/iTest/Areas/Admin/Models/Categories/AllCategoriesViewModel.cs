using iTest.DTO;
using System.Collections.Generic;

namespace iTest.Web.Areas.Admin.Models.Categories
{
    public class AllCategoriesViewModel
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }
    }
}
