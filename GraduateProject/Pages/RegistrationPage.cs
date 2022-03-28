using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateProject.Pages
{
    class RegistrationPage : BasePage
    {

        const string authCookieAcceptSelector = "__gomagCookiePolicy"; // id
        const string registrationPageCheckSelector = "#register-page > div > div.new-client-section.col-sm-7 > div.title-carousel > h1"; // css
        const string regExpandSubmitButtonSelector = "doRegister"; // id
        const string regSelector = "_submitRegistration"; // id
        const string emailSelector = "__emailRegister"; // id
        const string lastNameSelector = "__lastnameRegister"; // id
        const string firstNameSelector = "__firstnameRegister"; // id
        const string passwordSelector = "__passwordRegister"; // id
        const string confPasswSelector = "__confirmPasswordRegister"; // id
        const string eulaSelector = "#_submitRegistration > div > div > p > label > div > input"; // css
        const string errorMessageSelector = "#_submitRegistration > div > p"; // css
        const string emailErrSelector = "#_submitRegistration > div > div > div:nth-child(1) > span"; // css
        const string fnameErrSelector = "#_submitRegistration > div > div > div:nth-child(2) > span"; // css
        const string lnameErrSelector = "#_submitRegistration > div > div > div:nth-child(3) > span"; // css
        const string noPasswErrSelector = "#_submitRegistration > div > div > div:nth-child(4) > span"; // css
        const string confPasswErrSelector = "#_submitRegistration > div > div > div:nth-child(5) > span"; // css
        const string existingEmailSelector = "#_submitRegistration > div > div > div:nth-child(1) > span"; // css


        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public void LoginCookieAccept()
        {
            driver.FindElement(By.Id(authCookieAcceptSelector)).Click();
        }
                
        public string RegistrationPageCheck()
        {
            return driver.FindElement(By.CssSelector(registrationPageCheckSelector)).Text;
        }


        public void RegisterUser(string email, string lname, string fname, string passw, string confPassw, string eula)
        {
            var regElement = driver.FindElement(By.Id(regSelector));
            regElement.FindElement(By.Id(regExpandSubmitButtonSelector)).Click();
                       
            var emailElement = Utils.WaitForElement(driver, 20, By.Id(emailSelector));
            emailElement.Clear();
            emailElement.SendKeys(email);
                                   
            var lastNameElement = driver.FindElement(By.Id(lastNameSelector));
            lastNameElement.Clear();
            lastNameElement.SendKeys(lname);
            
            var firstNameElement = driver.FindElement(By.Id(firstNameSelector));
            firstNameElement.Clear();
            firstNameElement.SendKeys(fname);

            var passwordElement = driver.FindElement(By.Id(passwordSelector));
            passwordElement.Clear();
            passwordElement.SendKeys(passw);

            var confPasswordElement = driver.FindElement(By.Id(confPasswSelector));
            confPasswordElement.Clear();
            confPasswordElement.SendKeys(confPassw);

            if (eula == "true")
            {
                var eulaElement = driver.FindElement(By.CssSelector(eulaSelector));
                eulaElement.Click();
            }
                        
            regElement.Submit();
        }
        public string ErrorMessageCheck()
        {
            return driver.FindElement(By.CssSelector(errorMessageSelector)).Text;
        }
        public string EmailErrorCheck()
        {
            return driver.FindElement(By.CssSelector(emailErrSelector)).Text;
        }
        public string FirstNamerErrorCheck()
        {
            return driver.FindElement(By.CssSelector(fnameErrSelector)).Text;
        }
        public string LastNameErrorCheck()
        {
            return driver.FindElement(By.CssSelector(lnameErrSelector)).Text;
        }
        public string NoPasswordErrorCheck()
        {
            return driver.FindElement(By.CssSelector(noPasswErrSelector)).Text;
        }
        public string ConfPasswordErrorCheck()
        {
            return driver.FindElement(By.CssSelector(confPasswErrSelector)).Text;
        }

        public string ExistingEmailErrorCheck()
        {
            return driver.FindElement(By.CssSelector(existingEmailSelector)).Text;
        }
    }
}
