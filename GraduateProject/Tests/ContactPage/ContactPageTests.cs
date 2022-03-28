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
        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\contactmsgcredentials.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Category("Registration")]
        [Test, TestCaseSource("GetCredentialsDataCsv")]
        public void ContactPageTest(string email, string name, string phone, string message, string eula, 
            string errmsg, string emailerr, string nameerr,string phoneerr, string msgboxerr)
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + contactPath);
            MainPage qacc = new MainPage(_driver);
            qacc.CookieAccept();

            ContactPage cp = new ContactPage(_driver);
            Assert.IsTrue(cp.CheckContactPageLabel("BIKE ADDICT SRL-D"));
            cp.ContactMessage(email, name, phone, message, eula);
            if (errmsg != "")
            {
                Assert.AreEqual("Va rugam sa completati toate campurile obligatorii.", cp.ErrorMessageCheck());
            }
            if (emailerr != "")
            {
                Assert.AreEqual("Adresa de email este obligatorie.", cp.ErrorEmailCheck());
            }

            if (nameerr != "")
            {
                Assert.AreEqual("Numele este obligatoriu.", cp.ErrorNameCheck());
            }

            if (phoneerr != "")
            {
                Assert.AreEqual("Numarul de telefon este obligatoriu.", cp.ErrorPhoneCheck());
            }

            if (msgboxerr != "")
            {
                Assert.AreEqual("Mesajul este obligatoriu.", cp.ErrorMessageBoxCheck());
            }
        }
    }
}
