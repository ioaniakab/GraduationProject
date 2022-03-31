using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GraduationProject.Pages
{
    class LoginPage : BasePage
    {
        const string emailInputSelector = "_loginEmail"; // id
        const string passwordInputSelector = "_loginPassword"; // id
        const string credentialsErrorSelector = "error"; // class
        const string loginPageSelector = "#register-page > div > div.old-client-section.col-sm-5.pull-right > div > div.title-carousel > h1"; //css
        const string loginButtonSelector = "doLogin"; // id
        const string logoutSelector = "//*[@id='wrapper']/div[3]/div/div[1]/div[2]/ul[5]/li/a"; // xpath
        const string recoverPasswordSelector = "#register-page > div > div.old-client-section.col-sm-5.pull-right > div > div.register-form > form > a.client-pass-recov"; // css
        const string lostPassFrameSelector = "iframe"; // tag
        const string emailToRecoverSelector = "#passwordRecovery > div.login-holder > div:nth-child(2) > div > input"; //css
        const string submitToRecoverBtnSelector = "_doRecover"; // id
        const string recoverMailErrSelector = "#passwordRecovery > div.login-holder > div:nth-child(2) > label > span"; // css

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public Boolean CheckLoginLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(loginPageSelector)).Text.ToLower());
        }
        
        public void Login(string email, string passw)
        {
            var emailInputElement = driver.FindElement(By.Id(emailInputSelector));
            emailInputElement.Clear();
            emailInputElement.SendKeys(email);

            var passwordInputElement = driver.FindElement(By.Id(passwordInputSelector));
            passwordInputElement.Clear();
            passwordInputElement.SendKeys(passw);

            var loginButtonElement = driver.FindElement(By.Id(loginButtonSelector));
            loginButtonElement.Submit();
        }

        public void Logout()
        {
            driver.FindElement(By.XPath(logoutSelector)).Click();
        }
                
        public string ErrorCheck()
        {
            return driver.FindElement(By.ClassName(credentialsErrorSelector)).Text;
        }
               
        public void RecoverPassword(string email)
        {
            driver.FindElement(By.CssSelector(recoverPasswordSelector)).Click();
            var lostPassFrameElement = driver.FindElement(By.TagName(lostPassFrameSelector));
            driver.SwitchTo().Frame(lostPassFrameElement);
            var emailToRecoverElement = driver.FindElement(By.CssSelector(emailToRecoverSelector));
            emailToRecoverElement.Clear();
            emailToRecoverElement.SendKeys(email);
            driver.FindElement(By.Id(submitToRecoverBtnSelector)).Click();
        }

        public string RecoverEmailErrorCheck()
        {
            return driver.FindElement(By.CssSelector(recoverMailErrSelector)).Text;
        }
    }
}
