using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GraduateProject.Pages
{
    class Navigation : BasePage
    {
        const string accesorieMainSelector = "#main-menu > div > ul > li:nth-child(1)"; // css
        const string accessorieHoverSelector = "#main-menu > div > ul > li:nth-child(1) > a > span"; // css
        const string bikeSelector = "#main-menu > div > ul > li:nth-child(2) > a > span"; // css
        const string equipmentSelector = "#main-menu > div > ul > li:nth-child(3) > a > span"; // css
        const string glovesSelector = "#main-menu > div > ul > li:nth-child(3) > div > ul > li:nth-child(1) > span > p > a"; // css
        const string helmetsSelector = "#main-menu > div > ul > li:nth-child(3) > div > ul > li:nth-child(2) > span > p > a"; // css
        const string helmetsAdultsSelector = "#main-menu > div > ul > li:nth-child(3) > div > ul > li:nth-child(2) > span > a:nth-child(2)"; // css
        const string kidsHelemtsSelector = "#main-menu > div > ul > li:nth-child(3) > div > ul > li:nth-child(2) > span > a:nth-child(3)"; // css
        const string giftsSelector = "#main-menu > div > ul > li:nth-child(4) > a > span"; // css
        const string contactSelector = "#-g-footer-general > div > div > div:nth-child(1) > div > ul > li:nth-child(4) > a"; // css

        const string accessoriesPageCheckSelector = "#category-page > div > div:nth-child(1) > h1"; // css
        const string bikesPageCheckSelector = "#category-page > div > div:nth-child(1) > h1"; // css
        const string glovesPageCheckSelector = "#category-page > div > div:nth-child(1) > h1"; // css
        const string helmetsPageCheckSelector = "#category-page > div > div:nth-child(1) > h1"; // css
        const string helmetsAdultsPageCheckSelector = "#category-page > div > div:nth-child(1) > h1"; // css
        const string helmetsKidsPageCheckSelector = "#category-page > div > div:nth-child(1) > h1"; // css
        const string giftsPageCheckSelector = "#category-page > div > div:nth-child(1) > h1"; // css

        const string cartSelector = "#main-menu > ul > li.cart-header-btn.cart > a > i"; // css
        public Navigation(IWebDriver driver) : base(driver)
        {
        }

        public Boolean CheckAccesoriesPageLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(accessoriesPageCheckSelector)).Text.ToLower());
        }

        public Boolean CheckBikesPageLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(bikesPageCheckSelector)).Text.ToLower());
        }
        public Boolean CheckGlovesPageLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(glovesPageCheckSelector)).Text.ToLower());
        }
        public Boolean CheckHelmetsPageLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(helmetsPageCheckSelector)).Text.ToLower());
        }

        public Boolean CheckAdultsHelmetsLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(helmetsAdultsPageCheckSelector)).Text.ToLower());
        }

        public Boolean CheckKidsHelmetsLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(helmetsKidsPageCheckSelector)).Text.ToLower());
        }

        public Boolean CheckGiftsPageLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(giftsPageCheckSelector)).Text.ToLower());
        }
        public void AccesoriesMenu()
        {
            var hoverButton = driver.FindElement(By.CssSelector(accessorieHoverSelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(hoverButton).Build().Perform();
            driver.FindElement(By.CssSelector(accesorieMainSelector)).Click();
        }

        public void BikesMenu()
        {
            var bikeElement = driver.FindElement(By.CssSelector(bikeSelector));
            bikeElement.Click();
        }

        public void GlovesMenu()
        {
            var hoverButton = driver.FindElement(By.CssSelector(equipmentSelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(hoverButton).Build().Perform();
            driver.FindElement(By.CssSelector(glovesSelector)).Click();
        }
        public void HelmetsMenu()
        {
            var hoverButton = driver.FindElement(By.CssSelector(equipmentSelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(hoverButton).Build().Perform();
            driver.FindElement(By.CssSelector(helmetsSelector)).Click();
        }

        public void HelmetsAdultMenu()
        {
            var hoverButton = driver.FindElement(By.CssSelector(equipmentSelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(hoverButton).Build().Perform();
            driver.FindElement(By.CssSelector(helmetsAdultsSelector)).Click();
        }

        public void HelmetsKidsMenu()
        {
            var hoverButton = driver.FindElement(By.CssSelector(equipmentSelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(hoverButton).Build().Perform();
            driver.FindElement(By.CssSelector(kidsHelemtsSelector)).Click();
        }

        public void GiftsMenu()
        {
            var giftsElement = driver.FindElement(By.CssSelector(giftsSelector));
            giftsElement.Click();
        }

        public void GoToCart()
        {
            var cartElement = driver.FindElement(By.CssSelector(cartSelector));
            cartElement.Click();
        }

        public void GoContact()
        {
            var contactElement = driver.FindElement(By.CssSelector(contactSelector));
            contactElement.Click();
        }
    }

}
