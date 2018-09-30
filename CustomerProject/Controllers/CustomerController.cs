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
    public class CustomerController : Controller
    {
        private const string AllCustomersViewBagHeading = "All Customers";
        private const string Top5CustomersViewBagHeading = "Top Five Oldest Customers";
        private const string ErrorToast = "Oops! something went wrong";
        private const string CustomerAddedToast = "Customer Added";
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public CustomerController(
            ICustomerRepository repository,
            IMapper mapper,
            IToastNotification toastNotification
            )
        {
            _repository = repository;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CustomersListAsync()
        {
            var customers = await _repository.GetAllCustomers();
            var customersVM = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
            ViewData["Heading"] = AllCustomersViewBagHeading;
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
                    _toastNotification.AddErrorToastMessage(ErrorToast);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage(ErrorToast);
                return RedirectToAction(nameof(Index));
            }
            _toastNotification.AddSuccessToastMessage(CustomerAddedToast);
            return RedirectToAction(nameof(CustomersListAsync));
        }

        // The following action returns the CustomersListAsyncView, but it can be made to return
        // its own view if it needs to be different from the shared CustomersListAsyncView
        public async Task<IActionResult> TopFiveOldestCustomersAsync()
        {
            var customers = await _repository.GetTop5oldestCustomers();
            var customersVM = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);

            var customersListView = View(nameof(CustomersListAsync), customersVM);
            customersListView.ViewData["Heading"] = Top5CustomersViewBagHeading;
            return customersListView;
        }

    }
}
