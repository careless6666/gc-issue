using Microsoft.AspNetCore.Mvc;

namespace Aer.Playground.Service.LatencyIssue.Controllers
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
