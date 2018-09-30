using AutoMapper;
using CustomerProject.Controllers;
using CustomerProject.Data;
using CustomerProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CustomerProject.Tests
{
    [Trait("Category", "Unit")]
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IToastNotification> _toastrMock;
        private readonly Mock<ILogger<CustomerController>> _loggerMock;
        private CustomerController _controller;

        public CustomerControllerTests()
        {
            _repositoryMock = new Mock<ICustomerRepository>();
            _mapperMock = new Mock<IMapper>();
            _toastrMock = new Mock<IToastNotification>();
            _loggerMock = new Mock<ILogger<CustomerController>>();
        }

        [Fact]
        public async Task CustomersListViewTestAsync()
        {
            // Arrange
            var _customersVm = new List<CustomerListViewModel>();
            _mapperMock.Setup(m => m.Map<IEnumerable<Customer>, IEnumerable<CustomerListViewModel>>(
                It.IsAny<IEnumerable<Customer>>())).Returns(_customersVm);
            _controller = new CustomerController(
                            _repositoryMock.Object,
                            _mapperMock.Object,
                            _toastrMock.Object,
                            _loggerMock.Object
                            );

            // Act
            var result = await _controller.CustomersListAsync() as ViewResult;

            // Assert
            _repositoryMock.Verify(r => r.GetAllCustomers(), Times.Once);
            Assert.Equal("All Customers", result.ViewData["Heading"]);
            Assert.Equal(_customersVm, result.Model);
        }

        [Fact]
        public async Task CustomersListView_WhenExceptionOccurs_ShowErrorAndRedirectToIndexAsync()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetAllCustomers())
                .ThrowsAsync(new Exception());
            _controller = new CustomerController(
                                        _repositoryMock.Object,
                                        _mapperMock.Object,
                                        _toastrMock.Object,
                                        _loggerMock.Object
                                        );
            var customerVm = new CustomerViewModel();

            // Act
            var result = await _controller.CustomersListAsync() as RedirectToActionResult;

            // Assert
            _toastrMock.Verify(t => t.AddErrorToastMessage("Oops! something went wrong", null), Times.Once);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public async Task AddCustomerAsync_WhenModelStateInvalid_ReturnsIndexViewAsync()
        {
            // Arrange
            _controller = new CustomerController(
                                        _repositoryMock.Object,
                                        _mapperMock.Object,
                                        _toastrMock.Object,
                                        _loggerMock.Object
                                        );
            var customerVm = new CustomerViewModel();
            _controller.ModelState.AddModelError("key", "error message");

            // Act
            var result = await _controller.AddCustomerAsync(customerVm) as ViewResult;

            // Assert
            Assert.Equal("Index", result.ViewName);
        }

        [Fact]
        public async Task AddCustomerAsync_WhenNoRecordsAffected_ShowErrorAndRedirectToIndexAsync()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.AddCustomerAsync(It.IsAny<Customer>()))
                .Returns(Task.FromResult(0));
            _controller = new CustomerController(
                                        _repositoryMock.Object,
                                        _mapperMock.Object,
                                        _toastrMock.Object,
                                        _loggerMock.Object
                                        );
            var customerVm = new CustomerViewModel();

            // Act
            var result = await _controller.AddCustomerAsync(customerVm) as RedirectToActionResult;

            // Assert
            _repositoryMock.Verify(r => r.AddCustomerAsync(It.IsAny<Customer>()), Times.Once);
            _toastrMock.Verify(t => t.AddErrorToastMessage("Oops! something went wrong", null), Times.Once);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public async Task AddCustomerAsync_WhenExceptionOccurs_ShowErrorAndRedirectToIndexAsync()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.AddCustomerAsync(It.IsAny<Customer>()))
                .ThrowsAsync(new Exception());
            _controller = new CustomerController(
                                        _repositoryMock.Object,
                                        _mapperMock.Object,
                                        _toastrMock.Object,
                                        _loggerMock.Object
                                        );
            var customerVm = new CustomerViewModel();

            // Act
            var result = await _controller.AddCustomerAsync(customerVm) as RedirectToActionResult;

            // Assert
            _toastrMock.Verify(t => t.AddErrorToastMessage("Oops! something went wrong", null), Times.Once);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public async Task AddCustomerAsync_Success_RedirectsToCustomersListViewAsync()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.AddCustomerAsync(It.IsAny<Customer>()))
                .Returns(Task.FromResult(1));
            _controller = new CustomerController(
                                        _repositoryMock.Object,
                                        _mapperMock.Object,
                                        _toastrMock.Object,
                                        _loggerMock.Object
                                        );
            var customerVm = new CustomerViewModel();

            // Act
            var result = await _controller.AddCustomerAsync(customerVm) as RedirectToActionResult;

            // Assert
            _toastrMock.Verify(t => t.AddSuccessToastMessage("Customer Added", null), Times.Once);
            Assert.Equal("CustomersListAsync", result.ActionName);
        }

        [Fact]
        public async Task TopFiveOldestCustomersAsync_Returns_CustomersListViewAsync()
        {
            // Arrange
            var _customersVm = new List<CustomerListViewModel>();
            _mapperMock.Setup(m => m.Map<IEnumerable<Customer>, IEnumerable<CustomerListViewModel>>(
                It.IsAny<IEnumerable<Customer>>())).Returns(_customersVm);
            _controller = new CustomerController(
                                        _repositoryMock.Object,
                                        _mapperMock.Object,
                                        _toastrMock.Object,
                                        _loggerMock.Object
                                        );

            // Act
            var result = await _controller.TopFiveOldestCustomersAsync() as ViewResult;

            // Assert
            _repositoryMock.Verify(r => r.GetTop5oldestCustomers(), Times.Once);
            Assert.Equal("Top Five Oldest Customers", result.ViewData["Heading"]);
            Assert.Equal(_customersVm, result.Model);
            Assert.Equal("CustomersListAsync", result.ViewName);
        }
    }
}
