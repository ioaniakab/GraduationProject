using GraduateProject.Pages;
using GraduateProject.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GraduateProject.Tests
{
    class AddRemoveProductsToCartTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();
        [Category ("Add To Cart")]
        [Test, Order(1)]
        public void AccountAddTest()
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            MainPage qacc = new MainPage(_driver);
            qacc.CookieAccept();
            
            LoginPage lp = new LoginPage(_driver);
            lp.Login("email@email.com", "asd123");
                                   
            Navigation nav = new Navigation(_driver);
            nav.BikesMenu();

            SearchPages sp = new SearchPages(_driver);
            sp.SearchProduct(3);
            sp.AddToCart();

            nav.GlovesMenu();
            sp.SearchProduct(14);
            sp.IncreaseQuantity(2);
            sp.AddToCart();

            nav.HelmetsMenu();
            sp.PageNumber(0);
            sp.SearchProduct(11);
            sp.AddToCart();

            nav.GiftsMenu();
            sp.SearchProduct(7);
            sp.IncreaseQuantity(1);
            sp.AddToCart();
        }

        [Category("Add To Cart")]
        [Test, Order(2)]
        public void AccountEmptyCartTest()
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            MainPage qacc = new MainPage(_driver);
            qacc.CookieAccept();

            LoginPage lp = new LoginPage(_driver);
            lp.Login("email@email.com", "asd123");

            Navigation nav = new Navigation(_driver);
            nav.GoToCart();

            SearchPages sp = new SearchPages(_driver);
            sp.RemoveAllProducts();
           
        }
        [Category("Add To Cart")]
        [Test, Order(3)]
        public void AccountRemoveAProductTest()
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            MainPage qacc = new MainPage(_driver);
            qacc.CookieAccept();

            LoginPage lp = new LoginPage(_driver);
            lp.Login("email@email.com", "asd123");

            Navigation nav = new Navigation(_driver);
            nav.GoToCart();

            SearchPages sp = new SearchPages(_driver);
            sp.RemoveAProduct(2);
        }

        [Category("Add To Cart")]
        [Test, Order(4)]
        public void AddCartNOAccountTest()
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage qacc = new MainPage(_driver);
            qacc.CookieAccept();

            Navigation nav = new Navigation(_driver);
            nav.HelmetsMenu();

            SearchPages sp = new SearchPages(_driver);
            sp.PageNumber(1);
            sp.SearchProduct(2);
            sp.IncreaseQuantity(1);
            sp.AddToCart();
            
        }

    }
}
