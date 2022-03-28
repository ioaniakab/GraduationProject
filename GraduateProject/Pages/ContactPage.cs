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


        public Boolean CheckContactPageLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(contactPageCheckSelector)).Text.ToLower());
        }
        public ContactPage(IWebDriver driver) : base(driver)
        {
        }

        public void ContactMessage(string email)
        {
            var emailElement = driver.FindElement(By.Id(emailSelector));
            emailElement.Clear();
            emailElement.SendKeys(email);


        }

    }
}
