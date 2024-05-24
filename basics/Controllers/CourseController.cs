using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using basics.Models;
namespace basics.Controllers;

public class CourseController : Controller
{

    public IActionResult Details(int? id)
    {
        if(id==null){
            return RedirectToAction("List","Course");
        }
        var kurs = Repository.GetCourseById(id);

        return View(kurs);
    }
    public IActionResult List()
    {
       
        return View("CourseList", Repository.Courses);
    }
}
