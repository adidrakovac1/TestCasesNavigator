using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace UITests
{
    public class Tests
    {
        private IWebDriver driver;
        private IJavaScriptExecutor js;
        private IDictionary<string, object> vars;

        [SetUp]
        public void Setup()
        {
            driver = WebDriverSingleton.Instance;  
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverSingleton.QuitDriver(); 
        }

        [Test]
        public void Search_WhenPlaceIsExactMatch_ShouldDisplayCorrectPlace()
        {
            driver.Navigate().GoToUrl("https://www.navigator.ba/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1168);
            driver.FindElement(By.Id("ember564")).Click();
            driver.FindElement(By.Id("ember564")).SendKeys("Sarajevo City Center (SCC)");

            Thread.Sleep(2000);

            driver.FindElement(By.CssSelector(".iconav-search")).Click();

            Thread.Sleep(2000);

            try
            {
                var searchResults = driver.FindElement(By.CssSelector(".menu_content_list.search-results"));
                Assert.That(searchResults, Is.Not.Null, "The search results were not displayed.");

                var placeName = driver.FindElement(By.CssSelector("div.name[title='Sarajevo City Center (SCC)']"));
                Assert.That(placeName, Is.Not.Null, "The place 'Sarajevo City Center (SCC)' was not found.");

                Console.WriteLine("Test passed: I found the place: Sarajevo City Center (SCC)");
            }
            catch (NoSuchElementException)
            {
                var failureMessage = "Test failed: Could not find the place 'Sarajevo City Center (SCC)'.";
                Console.WriteLine(failureMessage);

                Assert.Fail(failureMessage);
            }

            try
            {
                var noResultsMessage = driver.FindElement(By.CssSelector("p.no-results"));
                string actualText = noResultsMessage.Text;

                bool isExpectedMessage = actualText == "We are sorry. We could not find any results matching your search term."
                                      || actualText == "Žao nam je. Nismo uspjeli pronaći niti jedan rezultat za traženu pretragu.";

                Assert.That(isExpectedMessage, Is.True, $"Unexpected 'no results' message: '{actualText}'");
                Console.WriteLine("Test failed: No results found message displayed: " + actualText);
            }
            catch (NoSuchElementException)
            {
                var failureMessage = "Test failed: 'No results found' message was not displayed.";
                Console.WriteLine(failureMessage);
                Assert.Fail(failureMessage);
            }
        }

        [Test]
        public void SearchSuggestion_WhenClicked_ShouldNavigateToCorrectPlace()
        {
            driver.Navigate().GoToUrl("https://www.navigator.ba/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1168);
            driver.FindElement(By.Id("ember564")).SendKeys("Sarajevo City Center (SCC)");

            Thread.Sleep(2000);

            var dropdown = driver.FindElement(By.CssSelector(".tt-dropdown-menu"));
            if (dropdown.Displayed)
            {
                var suggestionP = driver.FindElements(By.CssSelector(".tt-suggestion p"))
                                         .FirstOrDefault(p => p.Text.Contains("Sarajevo City Center (SCC)"));

                if (suggestionP != null)
                {
                    var parentDiv = suggestionP.FindElement(By.XPath(".."));
                    parentDiv.Click();
                    Console.WriteLine("Test passed: Clicked on 'Sarajevo City Center (SCC)'");
                }
                else
                {
                    Assert.Fail("Test failed: Could not find the suggestion 'Sarajevo City Center (SCC)'");
                    Console.WriteLine("Test failed: Could not find the suggestion 'Sarajevo City Center (SCC)'");
                }
            }
            else
            {
                Assert.Fail("Test failed: Dropdown menu is not visible.");
                Console.WriteLine("Test failed: Dropdown menu is not visible.");
            }

            Thread.Sleep(2000);

            new Actions(driver).MoveToElement(driver.FindElement(By.CssSelector(".profile-image"))).Perform();
        }

        [Test]
        public void Search_WhenQueryIsCategory_ShouldDisplayRelevantResults()
        {
            driver.Navigate().GoToUrl("https://www.navigator.ba/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1168);
            driver.FindElement(By.Id("ember564")).Click();
            driver.FindElement(By.Id("ember564")).SendKeys("nightlife");

            Thread.Sleep(2000);

            driver.FindElement(By.CssSelector(".iconav-search")).Click();

            Thread.Sleep(2000);

            var body = driver.FindElement(By.TagName("body"));
            string[] elements = { "#ember1051 .name", "#ember1092 .content", "#ember1113 .content", "#ember1144 .content" };

            foreach (var selector in elements)
            {
                var element = driver.FindElement(By.CssSelector(selector));
                new Actions(driver).MoveToElement(element).Perform();

                Thread.Sleep(2000);

                new Actions(driver).MoveToElement(body, 0, 0).Perform();

                Thread.Sleep(2000);
            }

            var searchResults = driver.FindElement(By.CssSelector(".search-results"));
            Assert.That(searchResults.Displayed, Is.True, "Test failed: The search results are not being displayed.");
            Console.WriteLine("Test passed: Search results for 'nightlife' are displayed successfully.");
        }
    }
}
