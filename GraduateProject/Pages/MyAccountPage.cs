using GraduationProject.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationProject.Pages
{
    class MyAccountPage : BasePage
    {
        const string myaccountPageLabelSelector = "//*[@id='wrapper']/div[3]/div/div[1]/div[1]/h3"; // xpath
        const string myAccountRefreshSelector = "//*[@id='wrapper']/div[3]/div/div[1]/div[2]/ul[1]/li/a"; // xpath
        const string ordersHistorySelector = "//*[@id='wrapper']/div[3]/div/div[1]/div[2]/ul[2]/li[3]/a"; // xpath
        const string orderStatusSelector = "//*[@id='wrapper']/div[3]/div/div[1]/div[2]/ul[2]/li[4]/a"; // xpath
        const string favoritesSelector = "//*[@id='wrapper']/div[3]/div/div[1]/div[2]/ul[2]/li[5]/a"; // xpath
        const string adressSelector = "//*[@id='wrapper']/div[3]/div/div[1]/div[2]/ul[3]/li[2]/a"; // xpath
        const string companySelector = "//*[@id='wrapper']/div[3]/div/div[1]/div[2]/ul[3]/li[3]/a"; // xpath
        const string personalInfoSelector = "//*[@id='wrapper']/div[3]/div/div[1]/div[2]/ul[4]/li[2]/a"; // xpath
        const string passwordChangeSelector = "//*[@id='wrapper']/div[3]/div/div[1]/div[2]/ul[4]/li[3]/a"; // xpath
        const string deleteAccountSelector = "//*[@id='wrapper']/div[3]/div/div[1]/div[2]/ul[4]/li[4]/a"; // xpath

        const string oldPasswordSelector = "//*[@id='wrapper']/div[3]/div/div[2]/form/div[1]/input"; //
        const string newPasswordSelector = "__newPassword"; // id
        const string repetNewPasswordSelector = "//*[@id='wrapper']/div[3]/div/div[2]/form/div[3]/input"; // xpath
        const string changePasswordSubmitSelector = "doSave"; // id
        const string errorMessageSelector = "//*[@id='wrapper']/div[3]/div/div[2]/p"; // xpath



        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public Boolean CheckMyAccountLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.XPath(myaccountPageLabelSelector)).Text.ToLower());
        }

        public Boolean CheckErrorMessageLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.XPath(errorMessageSelector)).Text.ToLower());
        }

        public void MyAccountRefresh()
        {
           driver.FindElement(By.XPath(myAccountRefreshSelector)).Click();
        }

        public void MyAccountOrderHistory()
        {
            driver.FindElement(By.XPath(ordersHistorySelector)).Click();
        }

        public void MyAccountOrderStatus()
        {
            driver.FindElement(By.XPath(orderStatusSelector)).Click();
        }

        public void MyAccountFavorites()
        {
            driver.FindElement(By.XPath(favoritesSelector)).Click();
        }

        public void MyAccountAdress()
        {
            driver.FindElement(By.XPath(adressSelector)).Click();
        }

        public void MyAccountCompany()
        {
            driver.FindElement(By.XPath(companySelector)).Click();
        }

        public void MyAccountPersonalInfo()
        {
            driver.FindElement(By.XPath(personalInfoSelector)).Click();
        }

        public void MyAccountChangePassword()
        {
            driver.FindElement(By.XPath(passwordChangeSelector)).Click();
        }

        public void MyAccountDelete()
        {
            driver.FindElement(By.XPath(deleteAccountSelector)).Click();
        }

        public void ChangePassword(string oldpass, string newpass, string renewpass)
        {
            var oldPasswordElement = driver.FindElement(By.XPath(oldPasswordSelector));
            oldPasswordElement.Clear();
            oldPasswordElement.SendKeys(oldpass);

            var newPasswordElement = driver.FindElement(By.Id(newPasswordSelector));
            newPasswordElement.Clear();
            newPasswordElement.SendKeys(newpass);

            var repetNewPasswordElement = driver.FindElement(By.XPath(repetNewPasswordSelector));
            repetNewPasswordElement.Clear();
            repetNewPasswordElement.SendKeys(renewpass);

            driver.FindElement(By.Id(changePasswordSubmitSelector)).Click();
        }
    }
}
