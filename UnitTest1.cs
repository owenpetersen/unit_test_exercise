using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading.Tasks;

namespace unit_test
{
    public class Tests
    {

        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://www.cognitoforms.com/CognitoForms/testautomation?v2"; 
            driver.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            
            System.Threading.Thread.Sleep(2000);


            IWebElement firstName = driver.FindElement(By.Id("cog-input-auto-0"));

            //firstName.Click();
            firstName.SendKeys("Owen");
            
            IWebElement lastName = driver.FindElement(By.Id("cog-input-auto-1"));

            //lastName.Click();
            lastName.SendKeys("Petersen");

            IWebElement emailAddress = driver.FindElement(By.Id("cog-1"));

            //emailAddress.Click();
            emailAddress.SendKeys("owenp@clemson.edu");


            IWebElement phone = driver.FindElement(By.Id("cog-2"));

            //phone.Click();
            phone.SendKeys("1234567890");

            
            IWebElement state = driver.FindElement(By.Id("cog-3"));
            state.SendKeys("South Carolina");


            
            IWebElement city = driver.FindElement(By.Id("cog-4"));
            city.SendKeys("Columbia");
            city.SendKeys(Keys.Tab);

            System.Threading.Thread.Sleep(1000);

            IWebElement submit = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[4]/button"));


            submit.Click();

            System.Threading.Thread.Sleep(2000);

            IWebElement name = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[1]/fieldset/div[1]/div"));

            IWebElement emailCheck = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div[1]/div[1]"));

            IWebElement phoneCheck = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div[2]/div[1]"));

            IWebElement stateCheck = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[3]/div[1]/div[1]/div"));

            IWebElement cityCheck = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[3]/div[2]/div[1]/div/div"));

            try{
                Assert.That((name.Text.Equals("Owen Petersen") && 
                (emailCheck.Text.Equals("owenp@clemson.edu")) && 
                (phoneCheck.Text.Equals("(123) 456-7890")) && 
                (stateCheck.Text.Equals("South Carolina")) && 
                (cityCheck.Text.Equals("Columbia"))));
            }
            catch(Exception e){
                Console.WriteLine("Name value found: " + name.Text);
                Console.WriteLine("Email value found: " + emailCheck.Text);
                Console.WriteLine("Phone value found: " + phoneCheck.Text);
                Console.WriteLine("State value found: " + stateCheck.Text);
                Console.WriteLine("City value found: " + cityCheck.Text);
                Console.WriteLine(e.StackTrace);
            }
            
            
        }

        [OneTimeTearDown]
        public void Finish(){
            driver.Close();
        }
    }
}