using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerProject.Models;
using CustomerProject.Data;
using AutoMapper;
using NToastNotify;

namespace CustomerProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public HomeController(ICustomerRepository repository, IMapper mapper, IToastNotification toastNotification)
        {
            _repository = repository;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomersList(string heading)
        {
            var customers = _repository.GetAllCustomers();
            var customersVM = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
            ViewData["Heading"] = "All Customers";
            return View(customersVM);
        }

        public async Task<IActionResult> AddCustomerAsync(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index));
            }
            int recordsAffected = 0;
            try
            {
                var customerEntity = _mapper.Map<CustomerViewModel, Customer>(customer);
                recordsAffected = await _repository.AddCustomerAsync(customerEntity);
                if (recordsAffected == 0)
                {
                    _toastNotification.AddErrorToastMessage("Oops! something went wrong");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Oops! something went wrong");
                return RedirectToAction(nameof(Index));
            }
            _toastNotification.AddSuccessToastMessage("Customer Added");
            return RedirectToAction("CustomersList");
        }

        public IActionResult TopFiveOldestCustomers()
        {
            var customers = _repository.GetAllCustomers()
                                        .OrderBy(c => c.DateOfBirth)
                                        .Take(5)
                                        .OrderBy(c => c.LastName);
            var customersVM = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);

            var customersListView = View(nameof(CustomersList), customersVM);
            customersListView.ViewData["Heading"] = "Top Five Oldest Customers";
            return customersListView;
        }

    }
}
