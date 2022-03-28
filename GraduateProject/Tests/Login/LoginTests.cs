using GraduateProject.Pages;
using GraduateProject.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateProject.Tests
{
    class LoginTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\logincredentials.csv"))
            {
                yield return new TestCaseData(values);
            }
        }


        [Category("Login")]
        [Test, TestCaseSource("GetCredentialsDataCsv"), Order(1)]
        public void LoginTest(string email, string passw, string errMsg, string passRecoveryErr)
        {
            String testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            MainPage mp = new MainPage(_driver);
            mp.CookieAccept();
            LoginPage lp = new LoginPage(_driver);
            Assert.IsTrue(lp.CheckLoginLabel("CONTUL TAU"));
           
            lp.Login(email, passw);
            
            if (errMsg != "" || errMsg != " ")
            {
                Assert.AreEqual(errMsg, lp.ErrorCheck());
            }
        }

        [Category("Logout")]
        [Test, Order(2)]
        public void Logout()
        {
            String testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            MainPage mp = new MainPage(_driver);
            mp.CookieAccept();
            LoginPage lp = new LoginPage(_driver);
            lp.Login("email@email.com", "asd123");
            lp.Logout();
        }
        
        [Category("Positive Login")]
        [Test, Order(4)]
        public void PositiveLogin()
        {
            String testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            MainPage mp = new MainPage(_driver);
            mp.CookieAccept();
            LoginPage lp = new LoginPage(_driver);
            lp.Login("email@email.com", "asd123");
        }

        [Category("PasswordRecovery")]
        //[Test, TestCaseSource("GetCredentialsDataCsv"), Order(3)]
        [Test, Order (3)]
        public void PasswordREcoveryTest()
        {
            String testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            MainPage mp = new MainPage(_driver);
            mp.CookieAccept();
            LoginPage lp = new LoginPage(_driver);
            lp.PasswordRecovery("email","err");
            
            /*lp.PasswordRecovery("abc", "err");
            Console.WriteLine("{0}",lp.ErrorRecoveryPassword());
            //Assert.AreEqual(passRecoveryErr, lp.ErrorRecoveryPassword());
            */
        }
        
    }
}
