using GraduateProject.Pages;
using GraduateProject.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateProject.Tests
{
    class ContactPageTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test]
        public void ContactPageTest()
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + contactPath);
            MainPage qacc = new MainPage(_driver);
            qacc.CookieAccept();

            ContactPage cp = new ContactPage(_driver);
            Assert.IsTrue(cp.CheckContactPageLabel("BIKE ADDICT SRL-D"));
            
        }
    }
}
