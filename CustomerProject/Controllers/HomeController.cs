using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerProject.Models;
using CustomerProject.Data;
using AutoMapper;

namespace CustomerProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public HomeController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
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
