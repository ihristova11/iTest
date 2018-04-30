using System.Collections.Generic;

namespace iTest.Web.Areas.Admin.Models
{
    public class AdminIndexViewModel
    {
        public ICollection<AdminTestViewModel> CreatedTests { get; set; } = new List<AdminTestViewModel>();

        public ICollection<AdminTestResultViewModel> TestResults { get; set; } = new List<AdminTestResultViewModel>();
    }
}
