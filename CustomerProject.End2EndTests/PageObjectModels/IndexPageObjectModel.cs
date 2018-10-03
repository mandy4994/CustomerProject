using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.End2EndTests.PageObjectModels
{
    public class IndexPageObjectModel
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _firstNameInput;
        private IWebElement _lastNameInput;
        private IWebElement _emailNameInput;
        private IWebElement _dobInput;
        private IWebElement _addCustomerBtn;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }


        public IndexPageObjectModel(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            InstantiateWebElements();
        }

        internal void InstantiateWebElements()
        {
            _firstNameInput = _webDriver.FindElement(By.Id("FirstNameInput"));
            _lastNameInput = _webDriver.FindElement(By.Id("LastNameInput"));
            _emailNameInput = _webDriver.FindElement(By.Id("EmailInput"));
            _dobInput = _webDriver.FindElement(By.Id("DobInput"));
            _addCustomerBtn = _webDriver.FindElement(By.Id("SubmitBtn"));
        }
        internal void EnterDetails()
        {
            _firstNameInput.SendKeys(FirstName);
            _lastNameInput.SendKeys(LastName);
            _emailNameInput.SendKeys(Email);
            _dobInput.EnterDate(Dob);
        }

        internal void ClickAddCustomer()
        {
            _addCustomerBtn.Click();
        }
    }
}
