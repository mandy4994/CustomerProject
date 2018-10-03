using OpenQA.Selenium;

namespace CustomerProject.End2EndTests.PageObjectModels
{
    public class CustomersListPageObjectModel
    {
        private readonly IWebDriver _driver;
        private IWebElement _customertable;

        public CustomersListPageObjectModel(IWebDriver driver)
        {
            _driver = driver;
            InstantiateWebElements();
        }

        private void InstantiateWebElements()
        {
            _customertable = _driver.FindElement(By.Id("CustomerTable"));
        }

        public int numbersOfRows { get; set; }

        public int GetNumberOfCustomers()
        {
            var tableRows = _customertable.FindElements(By.TagName("tr"));
            // Excluding the header row
            numbersOfRows = tableRows.Count - 1;
            return numbersOfRows;
        }
    }
}
