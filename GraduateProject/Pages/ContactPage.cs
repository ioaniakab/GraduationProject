using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateProject.Pages
{
    class ContactPage : BasePage
    {
        const string contactPageCheckSelector = "#contact-page > div.row > div.contact-information.col-sm-5.pull-right > div:nth-child(1) > h3"; // css
        const string emailSelector = "email"; // id
        const string nameSelector = "#-g-contact-form > div:nth-child(2) > input"; // css
        const string phoneSelector = "#-g-contact-form > div:nth-child(3) > input"; // css
        const string messageSelector = "#-g-contact-form > div.c-row.textarea > textarea"; // css
        const string eulaSelector = "#-g-contact-form > p > label > div > input"; // css
        const string sendMessageSelector = "sendMessage"; // id
        const string errorMessageSelector = "#-g-contact-form > p.regular-text.errorMsg"; // css
        const string emailErrorSelector = "#-g-contact-form > div:nth-child(2) > span"; // css
        const string nameErrorSelector = "#-g-contact-form > div:nth-child(3) > span"; // css
        const string phoneErrorSelector = "#-g-contact-form > div:nth-child(4) > span"; // css
        const string messageBoxErrorSelector = "#-g-contact-form > div.c-row.textarea > span"; // css

        public Boolean CheckContactPageLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(contactPageCheckSelector)).Text.ToLower());
        }
        public ContactPage(IWebDriver driver) : base(driver)
        {
        }

        public void ContactMessage(string email, string name, string phone, string message, string eula)
        {
            var emailElement = driver.FindElement(By.Id(emailSelector));
            emailElement.Clear();
            emailElement.SendKeys(email);

            var nameElement = driver.FindElement(By.CssSelector(nameSelector));
            nameElement.Clear();
            nameElement.SendKeys(name);

            var phoneElement = driver.FindElement(By.CssSelector(phoneSelector));
            phoneElement.Clear();
            phoneElement.SendKeys(phone);

            var messageElement = driver.FindElement(By.CssSelector(messageSelector));
            messageElement.Clear();
            messageElement.SendKeys(message);

            var eulaElement = driver.FindElement(By.CssSelector(eulaSelector));
            if (eula == "y")
            {
                eulaElement.Click();
            }

            driver.FindElement(By.Id(sendMessageSelector)).Click();
        }

        public string ErrorMessageCheck()
        {
            return driver.FindElement(By.CssSelector(errorMessageSelector)).Text;
        }

        public string ErrorEmailCheck()
        {
            return driver.FindElement(By.CssSelector(emailErrorSelector)).Text;
        }

        public string ErrorNameCheck()
        {
            return driver.FindElement(By.CssSelector(nameErrorSelector)).Text;
        }

        public string ErrorPhoneCheck()
        {
            return driver.FindElement(By.CssSelector(phoneErrorSelector)).Text;
        }
        public string ErrorMessageBoxCheck()
        {
            return driver.FindElement(By.CssSelector(messageBoxErrorSelector)).Text;
        }
    }
}
