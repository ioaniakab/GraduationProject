using NUnit.Framework;
using AventStack.ExtentReports.Model;
using System;
using System.Collections.Generic;
using System.Text;
using GraduationProject.Utilities;
using GraduationProject.Pages;

namespace GraduationProject.Tests
{
    class MainPageTests : BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        [Test]
        public void TestMainPage()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            Assert.IsTrue(mp.CheckMainPageLabel("PROMOTII"));
            mp.CookieAccept();
            mp.MoveToLoginRegPage();
            mp.ReloadMainPage();
        }

    }
}
