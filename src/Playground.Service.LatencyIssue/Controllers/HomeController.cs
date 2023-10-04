using Microsoft.AspNetCore.Mvc;

namespace Playground.Service.LatencyIssue.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
