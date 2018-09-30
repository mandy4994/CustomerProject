using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerProject.Models;
using CustomerProject.Data;
using AutoMapper;
using NToastNotify;
using Microsoft.Extensions.Logging;

namespace CustomerProject.Controllers
{
    public class CustomerController : Controller
    {
        // Following strings can be made a part of configuration if its required 
        // to have different strings in different environments
        private const string AllCustomersViewBagHeading = "All Customers";
        private const string Top5CustomersViewBagHeading = "Top Five Oldest Customers";
        private const string ErrorToast = "Oops! something went wrong";
        private const string CustomerAddedToast = "Customer Added";
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(
            ICustomerRepository repository,
            IMapper mapper,
            IToastNotification toastNotification,
            ILogger<CustomerController> logger
            )
        {
            _repository = repository;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CustomersListAsync()
        {
            _logger.LogInformation("Getting all Customers");
            List<Customer> customers = null;
            try
            {
                customers = await _repository.GetAllCustomers();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while getting all customers - {ex}");
                _toastNotification.AddErrorToastMessage(ErrorToast);
                return RedirectToAction(nameof(Index));
            }
            var customersVM = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerListViewModel>>(customers);
            ViewData["Heading"] = AllCustomersViewBagHeading;
            return View(customersVM);
        }

        public async Task<IActionResult> AddCustomerAsync(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Cannot add customer - invalid details");
                return View(nameof(Index));
            }
            int recordsAffected = 0;
            try
            {
                var customerEntity = _mapper.Map<CustomerViewModel, Customer>(customer);
                recordsAffected = await _repository.AddCustomerAsync(customerEntity);          
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while saving customer - {ex} ");
                _toastNotification.AddErrorToastMessage(ErrorToast);
                return RedirectToAction(nameof(Index));
            }
            if (recordsAffected == 0)
            {
                _logger.LogError("No customer was added");
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
            List<Customer> customers = null;
            try
            {
                customers = await _repository.GetTop5oldestCustomers();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while getting top 5 oldest customers - {ex}");
                _toastNotification.AddErrorToastMessage(ErrorToast);
                return RedirectToAction(nameof(Index));
            }
            var customersVM = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerListViewModel>>(customers);

            var customersListView = View(nameof(CustomersListAsync), customersVM);
            customersListView.ViewData["Heading"] = Top5CustomersViewBagHeading;
            return customersListView;
        }

    }
}
