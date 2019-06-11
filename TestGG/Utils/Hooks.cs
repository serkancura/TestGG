using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace TestGG.Utils {

    [Binding]


    public sealed class Hooks {
        
        IWebDriver driver;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeWebScenario() {
            driver = new ChromeDriver();
            ScenarioContext.Current["driver"] = driver;
            driver.Manage().Window.Maximize();

        }

        [AfterScenario]
        public void AfterScenario() {
            if (ScenarioContext.Current.TestError != null) {
                TakeScreenshot(driver);
            }
            driver.Quit();
        }

        private void TakeScreenshot(IWebDriver driver) {
            try {
                string fileNameBase = string.Format("error_{0}_{1}_{2}",
                    FeatureContext.Current.FeatureInfo.Title,
                    ScenarioContext.Current.ScenarioInfo.Title,
                    DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                
                var artifactDirectory = Path.Combine(Config.testResultFilePath, fileNameBase);
                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                string pageSource = driver.PageSource;
                string sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath, UriKind.Relative));


                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null) {
                    var screenshot = takesScreenshot.GetScreenshot();
                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");
                    screenshot.SaveAsFile(screenshotFilePath, OpenQA.Selenium.ScreenshotImageFormat.Png);
                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath, UriKind.Relative));
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
        }
    }
}


