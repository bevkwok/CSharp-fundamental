using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace portofolio1
{
    public class HomeController: Controller
    {
        // Requests
        // localhost:5000
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }


        [Route("projects")]
        [HttpGet]
        public ViewResult Projects()
        {
            return View("projects");
        }


        [Route("contact")]
        [HttpGet]
        public ViewResult Contact()
        {
            return View("contact");
        }

        public RedirectToActionResult ToIndex()
        {
            return RedirectToAction("Index");
        }
        public RedirectToActionResult ToProjects()
        {
            return RedirectToAction("Projects");
        }

            public RedirectToActionResult ToContact()
        {
            return RedirectToAction("Contact");
        }
    }

    
}