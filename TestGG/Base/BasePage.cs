using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestGG.Utils;

namespace TestGG.Base {
    [Binding]

    class BasePage {

        readonly IWebDriver driver;


        public BasePage() {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
        }

        public void type(String inputText, By locator) {
            find(locator).SendKeys(inputText);
        }



        public IWebElement find(By locator) {
            var element = driver.FindElement(locator);
            scrollToView(element);
            return element;
        }

        public void visit(String url) {
            driver.Navigate().GoToUrl(Config.BaseUrl + url);

        }

        public void click(By locator) {
            find(locator).Click();
        }

        public String getText(By locator) {
            return find(locator).Text;
        }

        public Boolean isDisplayed(By locator) {
            try {
                return find(locator).Displayed && find(locator).Enabled;
            }
            catch (NoSuchElementException ex) {
                return false;
            }
        }

        public void submit(By locator) {
            find(locator).Submit();
        }

        public void waitElement(By locator) {
            if (isDisplayed(locator)) {
                return;
            } else {
                wait(TimeSpan.FromSeconds(3));
            }
        }

        public void wait(TimeSpan time) {
            Thread.Sleep(time);
        }

        public void mouseOver(By locator) {
            Actions builder = new Actions(driver);
            try {
                builder.MoveToElement(find(locator)).Build().Perform();
                wait(TimeSpan.FromSeconds(2));

            }
            catch (Exception e) {

                throw;
            }
        
        }

        public void ScrollTo(int xPosition = 0, int yPosition = 0) {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string title = (string)js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", xPosition, yPosition));
        }

        public void scrollToView(IWebElement element) {
            if (element.Location.Y > 200) {
                ScrollTo(0, element.Location.Y - 100); // Make sure element is in the view but below the top navigation pane
            }

        }
    }
}
