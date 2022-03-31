using GraduationProject.Pages;
using GraduationProject.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationProject.Tests
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
        private static IEnumerable<TestCaseData> GetRecoverCredentialsDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\recovercredentials.csv"))
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
            lp.Login("test1@email.com", "asd123");
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
            lp.Login("test1@email.com", "asd123");
        }
        [Category("Recover Password")]
        [Test, TestCaseSource("GetRecoverCredentialsDataCsv"), Order(5)]
        public void RecoverPassword(string email, string errMsg)
        {
            String testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            MainPage mp = new MainPage(_driver);
            mp.CookieAccept();
            LoginPage lp = new LoginPage(_driver);
            lp.RecoverPassword(email);

            if (errMsg != "")
            {
                Assert.AreEqual(errMsg, lp.RecoverEmailErrorCheck());
            }
        }

    }
}
