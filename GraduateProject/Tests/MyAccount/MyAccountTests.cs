using GraduationProject;
using GraduationProject.Pages;
using GraduationProject.Tests;
using GraduationProject.Utilities;
using GraduationProject.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationProject.Tests
{
    class MyAccountTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\changepasscredentials.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Category ("My Account")]
        [Test, Order (1)]
        public void MyAccountNavigate()
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            
            MainPage qacc = new MainPage(_driver);
            qacc.CookieAccept();

            LoginPage lp = new LoginPage(_driver);
            lp.Login("test1@email.com", "asd123");

            MyAccountPage ma = new MyAccountPage(_driver);
            Assert.IsTrue(ma.CheckMyAccountLabel("CONTUL MEU"));
            ma.MyAccountFavorites();
            ma.MyAccountOrderHistory();
            ma.MyAccountOrderStatus();
            ma.MyAccountFavorites();
            ma.MyAccountAdress();
            ma.MyAccountCompany();
            ma.MyAccountPersonalInfo();
            ma.MyAccountChangePassword();
            ma.MyAccountRefresh();
        }

        [Category("My Account")]
        [Test, TestCaseSource("GetCredentialsDataCsv"), Order (2)]
        public void ChangePasswordTest(string oldpass, string newpass, string renewpass, string errMsg)
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);

            MainPage qacc = new MainPage(_driver);
            qacc.CookieAccept();

            LoginPage lp = new LoginPage(_driver);
            lp.Login("test1@email.com", "asd123");

            MyAccountPage ma = new MyAccountPage(_driver);
            ma.MyAccountChangePassword();
            ma.ChangePassword(oldpass, newpass, renewpass);
            if (errMsg != "")
            {
                Assert.IsTrue(ma.CheckErrorMessageLabel("Va rugam sa completati toate campurile."));
            }
        }

    }
}
