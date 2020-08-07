using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace razor_fun
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }
    }
}