
using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace MeetingApp.Controllers
{
    public class MeetingController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(UserInfo model)
        {

            if (ModelState.IsValid)
            {
                Repository.CreateUser(model);
                ViewBag.UserCount = Repository.Users.Where(i => i.WillAttend == true).Count();
                return View("Thanks", model);
            }else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult List()
        {
            var users = Repository.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Title = "Detay Sayfası";
            return View(Repository.GetById(id));
        }
    }
}