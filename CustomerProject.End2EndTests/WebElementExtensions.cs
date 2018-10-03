using OpenQA.Selenium;
using System;

namespace CustomerProject.End2EndTests
{
    public static class WebElementExtensions
    {
        public static void EnterDate(this IWebElement webElement, DateTime date)
        {
            webElement.SendKeys(
                date.Day.ToString() + Keys.Right + date.Month.ToString() + Keys.Right + date.Year.ToString());
        }
    }
}
