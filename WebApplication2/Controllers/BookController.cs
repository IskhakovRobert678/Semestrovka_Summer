using WebApplication2.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        //[Authorize(Policy = Constants.Policies.RequireManager)]
        //[Authorize(Policy = "RequireManager")]
        public IActionResult FreeBook()
        {
            return View();
        }

        [Authorize(Policy = "RequireDonatUser")]
        public IActionResult DonatBook()
        {
            return View();
        }
    }
}
