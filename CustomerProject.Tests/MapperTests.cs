using AutoMapper;
using CustomerProject.Data;
using CustomerProject.Mapping;
using CustomerProject.Models;
using FluentAssertions;
using System;
using Xunit;

namespace CustomerProject.Tests
{
    [Trait("Category", "Unit")]
    public class MapperTests
    {
        private readonly IMapper _mapper;

        public MapperTests()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            Mapper.Initialize(m => m.AddProfile<MappingProfile>());
            Mapper.AssertConfigurationIsValid();
        }

        [Fact]
        public void GivenDateOfBirthIsNull_WhenMappedToCustomerEntity_ThenCustCodeNotIncludesDateOfBirth()
        {
            var customerViewModel = new CustomerViewModel
            {
                FirstName = "John",
                LastName = "Snow"
            };
            var customerEntity = _mapper.Map<Customer>(customerViewModel);
            customerEntity.CustCode.Should().Be("johnsnow");
        }

        [Fact]
        public void GivenDateOfBirthExist_WhenMappedToCustomerEntity_ThenCustCodeIncludesDateOfBirth()
        {
            var customerViewModel = new CustomerViewModel
            {
                FirstName = "John",
                LastName = "Snow",
                DateOfBirth = new DateTime(2000, 1, 2)
            };
            var customerEntity = _mapper.Map<Customer>(customerViewModel);
            customerEntity.CustCode.Should().Be("johnsnow20000102");
        }
    }
}
