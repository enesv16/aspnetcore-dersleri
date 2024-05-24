using System.Runtime.CompilerServices;
using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index(){

            int saat = DateTime.Now.Hour;

            // ViewBag.selamlama= saat>12 ?  "İyi Günler" : "İyi Sabahlar";
            // ViewBag.Username= "Enes";
            ViewData["Selamlama"] = saat>12 ?  "İyi Günler" : "İyi Sabahlar";
            int UserCount = Repository.Users.Where(i => i.WillAttend == true).Count();

            var meetingInfo = new MeetingInfo(){
                Id=1,
                Location= "Bursa, AKKM",
                Date= new DateTime(2024,01,20,20,45,00),
                NumberOfPeople=UserCount
            };

            return View(meetingInfo);
        }
    }
}