using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Controllers
{
    public class Hellocontroller : Controller
    {
        public IActionResult Welcome(string name, int numberOfTimes)
        {
            ViewData["Name"] = name;
            ViewData["NumberOfTimes"] = numberOfTimes;
            return View();
        }

    }
}
