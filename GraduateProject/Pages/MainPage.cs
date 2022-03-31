using GraduationProject.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationProject.Pages
{
    class MainPage : BasePage
    {
        const string mainPageSelector = "#-g-homepage-productsDiscounts > div > div > div.title-carousel > p"; // css
        const string authButtonSelector = "#-g-homepage-productsDiscounts > div > div > div.title-carousel > p";// css
        const string authCookieAcceptSelector = "__gomagCookiePolicy"; // id
        const string accountSelector = "#main-menu > ul > li.user-m.-g-user-icon > a > i"; // css
        const string myCartSelector = "#main-menu > ul > li.cart-header-btn.cart > a > i"; // css
        const string contact1Selector = "#main-menu > ul > li:nth-child(1) > a > i"; //css
        const string contact2Selector = "#main-menu > ul > li.phone-m.-g-contact-phone2 > a > i"; // css
        const string reloadMainPageSelector = "#logo"; // css
        public MainPage(IWebDriver driver) : base(driver)
        {
        }
                
        public Boolean CheckMainPageLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(mainPageSelector)).Text.ToLower());
        }
        public void CookieAccept()
        {
            var authCookieAcceptButton = driver.FindElement(By.Id(authCookieAcceptSelector));
            authCookieAcceptButton.Click();
        }

        public void MoveToLoginRegPage()
        {
            var authButton = driver.FindElement(By.CssSelector(accountSelector));
            authButton.Click();
        }

        public void ReloadMainPage()
        {
            driver.FindElement(By.CssSelector(reloadMainPageSelector)).Click();
        }
    }
}
