using GraduationProject.Pages;
using GraduationProject.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GraduationProject.Tests
{
    class AddRemoveProductsToCartTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();
        [Category ("Add To Cart")]
        [Test, Order(1)]
        public void AccountAddToCartTest()
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            MainPage qacc = new MainPage(_driver);
            qacc.CookieAccept();
            
            LoginPage lp = new LoginPage(_driver);
            lp.Login("test1@email.com", "asd123");
                                   
            Navigation nav = new Navigation(_driver);
            nav.BikesMenu();

            SearchPages sp = new SearchPages(_driver);
            sp.SearchProduct(3);
            sp.AddToCart();

            nav.GlovesMenu();
            sp.SearchProduct(14);
            sp.IncreaseQuantity(3);
            sp.DecreaseQuantity(2);
            sp.AddToCart();

            nav.HelmetsMenu();
            sp.PageNumber(0);
            sp.SearchProduct(11);
            sp.AddToCart();

            nav.HelmetsKidsMenu();
            sp.SearchProduct(7);
            sp.IncreaseQuantity(2);
            sp.AddToCart();

            nav.AccesoriesMenu();
            sp.SearchProduct(7);
            sp.IncreaseQuantity(2);
            sp.AddToCart();
        }

        [Category("Cart Tests")]
        [Test, Order(2)]
        public void AccountEmptyCartTest()
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            MainPage qacc = new MainPage(_driver);
            qacc.CookieAccept();

            LoginPage lp = new LoginPage(_driver);
            lp.Login("test1@email.com", "asd123");

            Navigation nav = new Navigation(_driver);
            nav.GoToCart();

            SearchPages sp = new SearchPages(_driver);
            sp.RemoveAllProducts();
           
        }
        [Category("Cart Tests")]
        [Test, Order(3)]
        public void AccountRemoveAProductTest()
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            MainPage qacc = new MainPage(_driver);
            qacc.CookieAccept();

            LoginPage lp = new LoginPage(_driver);
            lp.Login("test1@email.com", "asd123");

            Navigation nav = new Navigation(_driver);
            nav.GoToCart();

            SearchPages sp = new SearchPages(_driver);
            sp.RemoveAProduct(0);
        }

        [Category("Cart Tests")]
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
