using CustomerProject.End2EndTests.PageObjectModels;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CustomerProject.End2EndTests.Steps
{
    [Binding]
    public class CustomerEndtoEndSteps
    {
        private IWebDriver webDriver;
        private IndexPageObjectModel _indexPage;
        private CustomersListPageObjectModel _customerListPage;
        private readonly DbRepositoryHelper dbHelper;

        public int numberOfCustomersBefore { get; set; }
        public int numberOfCustomersAfter { get; set; }

        public CustomerEndtoEndSteps()
        {
            dbHelper = DbRepositoryHelper.Create();
        }
        [BeforeScenario]
        public void InitScenario()
        {
            webDriver = new ChromeDriver();
        }

        [AfterScenario]
        public void TearDownScenario()
        {
            webDriver.Dispose();
            dbHelper.DeleteCustomer("johnsnow19930201");
        }
        [Given(@"I am on All Customers Page to count number of customers")]
        public void GivenIAmOnAllCustomersPageToCountNumberOfCustomers()
        {
            // url can be included in the config
            webDriver.Navigate().GoToUrl("https://localhost:5001/Customer/CustomersListAsync");
            _customerListPage = new CustomersListPageObjectModel(webDriver);
            numberOfCustomersBefore = _customerListPage.GetNumberOfCustomers();
        }

        [Given(@"I navigate Add Customer Page")]
        public void GivenINavigateAddCustomerPage()
        {
            // url can be included in the config
            webDriver.Navigate().GoToUrl("https://localhost:5001");
        }
        
        [When(@"I enter details and click Add Customer")]
        public void WhenIEnterDetailsAndClickAddCustomer(Table table)
        {
            _indexPage = new IndexPageObjectModel(webDriver);
            table.FillInstance(_indexPage);
            _indexPage.EnterDetails();
            _indexPage.ClickAddCustomer();            
        }
        
        [Then(@"I can see my Customer in the List")]
        public void ThenICanSeeMyCustomerInTheList()
        {
            _customerListPage = new CustomersListPageObjectModel(webDriver);
            numberOfCustomersAfter = _customerListPage.GetNumberOfCustomers();
            numberOfCustomersAfter.Should().Be(numberOfCustomersBefore + 1);
            // TODO: check for last row record
        }
    }
}
