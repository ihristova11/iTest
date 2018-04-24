using iTest.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTest.Web.Areas.Admin.Controllers.Abstract
{
    [Area("Admin")]
    [Authorize(Roles = UserRoles.AdminRole)]
    public abstract class AdminController : Controller
    {
    }
}