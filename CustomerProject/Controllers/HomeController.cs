using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerProject.Models;

namespace CustomerProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCustomer(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index));
            }
            return View(nameof(Index));
        }

    }
}
