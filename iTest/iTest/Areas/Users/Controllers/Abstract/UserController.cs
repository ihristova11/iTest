using iTest.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTest.Web.Areas.Users.Controllers.Abstract
{
    [Area("Users")]
    [Authorize(Roles = UserRoles.UserRole)]
    public abstract class UserController : Controller
    {
    }
}