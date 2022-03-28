using GraduateProject.Pages;
using GraduateProject.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateProject.Tests
{
    class RegistrationTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();
        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\registrationcredentials.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Category("Registration")]
        [Test, TestCaseSource("GetCredentialsDataCsv")]
        
        public void RegistrationTest(string email, string lname, string fname, string passw, string confPassw, string eula,
            string errmsg, string emailerr, string fnameerr, string lnameerr, string nopasswerr, string confpasswerr, string existmailerr)
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            RegistrationPage rp = new RegistrationPage(_driver);
            rp.LoginCookieAccept();
            Assert.AreEqual("CLIENT NOU: INREGISTRARE", rp.RegistrationPageCheck());
            rp.RegisterUser(email, lname, fname, passw, confPassw, eula);
            if(errmsg != "")
            {
            Assert.AreEqual("Va rugam sa completati toate campurile obligatorii.", rp.ErrorMessageCheck());
            }
            if (emailerr != "")
            {
                Assert.AreEqual("Adresa de email este obligatorie.", rp.EmailErrorCheck());
            }
            if (fnameerr != "")
            {
                Assert.AreEqual("Numele este obligatoriu.", rp.FirstNamerErrorCheck());
            }
            if (lnameerr != "")
            {
                Assert.AreEqual("Prenumele este obligatoriu.", rp.LastNameErrorCheck());
            }
            if (nopasswerr != "")
            {
                Assert.AreEqual("Parola este obligatorie.", rp.NoPasswordErrorCheck());
            }
            if (confpasswerr != "")
            {
                Assert.AreEqual("Parolele nu corespund.", rp.ConfPasswordErrorCheck());
            }
           
            if (existmailerr != "")
            {
            Assert.AreEqual("Adresa de email exista in baza de date. Va rugam sa va logati.", rp.ExistingEmailErrorCheck());
            }
             
        }

        [Category("Registration")]
        [Test]
        public void RegistrationRandom()
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            RegistrationPage rp = new RegistrationPage(_driver);
            rp.LoginCookieAccept();
            var pass = Utils.GenerateRandomStringCount(5);
            rp.RegisterUser(Utils.GenerateRandomStringCount(10) + "@test.com", Utils.GenerateRandomStringCount(5)+"5", Utils.GenerateRandomLettersStringCount(5), pass,pass, "true");
        }

    }
}
