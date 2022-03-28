using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateProject.Pages
{
    class SearchPages : BasePage
    {
        const string addCartButtonSelector = "btn"; // class
        const string addToCartSelectorClass = "product-box"; // class
        const string increaseQtyButtonSelector = "qtyplus"; // id
        const string decreaseQtyButtonSelector = "qtyminus"; // id
        const string quantitySelector = "quantity"; // id
        const string pageNumberSelector = "buttonPag"; // class
        const string removeProductSelector = "remove"; // class
        const string removeProductsSelector = "-g-checkout-item-remove"; // class
        const string outOfStockSelector = "//*[@id='product-page']/div[1]/div/div[2]/div/div[2]/a"; // xpath


        public SearchPages(IWebDriver driver) : base(driver)
        {
        }

        // look for number of products on page and select/open the one according to index number
        public void SearchProduct(int productIndex)
        {
            var countProductsOnPage = driver.FindElements(By.ClassName(addToCartSelectorClass));
            var productsOnPage = countProductsOnPage[productIndex];
            //Console.Write(countProductsOnPage.Count);
            //Console.WriteLine("products on page {0}", productsOnPage);
            productsOnPage.Click();
        }

        public void PageNumber(int pageIndex)
        {
            var countPages = driver.FindElements(By.ClassName(pageNumberSelector));
            var numberOfPages = countPages[pageIndex];
            //Console.Write(countPages.Count);
            //Console.WriteLine("pages {0}", numberOfPages);
            numberOfPages.Click();
        }

        public void AddToCart()
        {
            var addToCartButtonElement = Utils.WaitForElementClickable(driver, 2, By.ClassName(addCartButtonSelector));
            addToCartButtonElement.Click();
        }

        public void IncreaseQuantity(int quantity)
        {

            for (int i = 0; i < quantity; i++)
            {
                var button = Utils.WaitForElementClickable(driver, 2, By.Id(increaseQtyButtonSelector));
                button.Click();
            }
        }

        public void DecreaseQuantity(int quantity)
        {

            for (int i = 0; i < quantity; i++)
            {
                var button = Utils.WaitForElementClickable(driver, 2, By.Id(decreaseQtyButtonSelector));
                button.Click();
            }
        }

        public void QuantityToAddCount()
        {
            var countProductsToAdd = driver.FindElement(By.Id(quantitySelector)).Text;
            Console.Write(countProductsToAdd);
        }

        public void RemoveAProduct(int prodIndex)
        {
            var countProdInCartElement = driver.FindElements(By.ClassName(removeProductSelector));
            var removeProductElement = countProdInCartElement[prodIndex];
            Console.Write(countProdInCartElement.Count);
            removeProductElement.Click();
        }
        public void RemoveAllProducts()
        {
            var countProdInCartElement = driver.FindElements(By.ClassName(removeProductSelector));
            //var elements = countProdInCartElement.Count;
            //Console.Write(countProdInCartElement.Count);
            //Console.WriteLine("Numarul de produse din cos este {0}", elements);
            
            foreach (var item in countProdInCartElement)
            {
                //Utils.WaitForElementClickable(driver, 2, By.ClassName(removeProductsSelector)).Click();
                //var removeProductElement = Utils.WaitForFluentElement(driver, 2, By.ClassName(removeProductsSelector));
                //removeProductElement.Click();
                item.Click();
            }
        }

    }
}
