using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;

namespace walmart
{
    public class search
    {
        IWebDriver Webdriver;

        [Test]
        public void testSearch()
        {
            //webdriver location
            string a = @"C:\Users\payam\\source\repos\NUnitTestWalmart\Drivers";
           //start new chrome session
            Webdriver = new ChromeDriver(a);
            Webdriver.Manage().Window.Maximize();
            Webdriver.Url = "https://www.walmart.com";
            //Wait for wallmart website to load
            System.Threading.Thread.Sleep(10000);
            IWebElement element = Webdriver.FindElement(By.Id("global-search-input"));
            element.Clear();
            element.SendKeys("Office Desk");
            IWebElement searchBtn = Webdriver.FindElement(By.XPath("//*[@id='global-search-submit']/span/img"));
            searchBtn.Click();

            //save result into a list
            List<IWebElement> allProduct = new List<IWebElement>(Webdriver.FindElements(By.XPath("//*[@id='searchProductResult']/ul")));
            //counter for total result
            int counter = 0;
            int Rcounter = 0; //counter for result contain keyword
            string keyW1 = "office";
            string keyW2 = "Desk";
            string keyW3 = "Office Desk";
            foreach (IWebElement e in allProduct)
            {
                //search in result for keywords
                if (e.Text.Contains(keyW1) | e.Text.Contains(keyW2) | e.Text.Contains(keyW3))
                {
                    
                    Rcounter++;
                }
                counter++;
            }//End if
                //check if number of result is relevant
                if ((Rcounter/counter) > (.5))
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }//End if
               
            
        }
        

        
    }
}
