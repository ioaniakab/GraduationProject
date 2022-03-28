using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateProject.Pages
{
    class LoginPage : BasePage
    {
        const string authCookieAcceptSelector = "__gomagCookiePolicy"; // id
        const string emailInputSelector = "_loginEmail"; // id
        const string passwordInputSelector = "_loginPassword"; // id
        const string credentialsErrorSelector = "error"; // class
        const string loginPageSelector = "#register-page > div > div.old-client-section.col-sm-5.pull-right > div > div.title-carousel > h1"; //css
        const string loginButtonSelector = "doLogin"; // id
        const string passForgetSelector = "#register-page > div > div.old-client-section.col-sm-5.pull-right > div > div.register-form > form > a.client-pass-recov"; // css
        const string passRecoveryEmailSelector = "#passwordRecovery > div.login-holder > div:nth-child(2) > div > input"; // css
        const string passRecoveryEmailSelectorXpath = "//*[@id='passwordRecovery']/div[1]/div[1]/div/input"; // xpath
        const string passRecoveryEmailErrorSelector = "#passwordRecovery > div.login-holder > div:nth-child(2) > label > span"; // css
        const string passRecoveryPageCheckSelector = "#passwordRecovery > div.login-holder > p"; // css
        const string recoverPasswordSubmitSelector = "_doRecover"; // id
        const string recoverPassXpath = "/html/body/div[1]/div[1]/form/div[1]/a"; // Xpath
        const string recoverPasswordSubmitSelector2 = "#_doRecover"; // css
        const string logoutSelector = "//*[@id='wrapper']/div[3]/div/div[1]/div[2]/ul[5]/li/a"; // xpath

        const string recoverLoginHolderSelector = "passwordRecovery"; // id

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

        public void PasswordRecovery(string email, string passRecoveryErr)
        {
            var passForgetElement = driver.FindElement(By.CssSelector(passForgetSelector));
            passForgetElement.Click();

           
            /*var recoverPasswordSubmitElement = driver.FindElement(By.LinkText("Trimite"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(recoverPasswordSubmitElement);
            actions.Perform();*/
            //recoverPasswordSubmitElement.Click();
                //SendKeys(Keys.Return); 
        }
        
        public string ErrorCheck()
        {
            return driver.FindElement(By.ClassName(credentialsErrorSelector)).Text;
        }
        
        public string ErrorRecoveryPassword()
        {
            return driver.FindElement(By.CssSelector(passRecoveryEmailErrorSelector)).Text;
        }
        
    }
}
