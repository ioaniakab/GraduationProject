using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationProject.Pages
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
        

        public SearchPages(IWebDriver driver) : base(driver)
        {
        }

        // look for number of products on page and select/open the one according to index number
        public void SearchProduct(int productIndex)
        {
            var countProductsOnPage = driver.FindElements(By.ClassName(addToCartSelectorClass));
            var productsOnPage = countProductsOnPage[productIndex];
            productsOnPage.Click();
        }

        public void PageNumber(int pageIndex)
        {
            var countPages = driver.FindElements(By.ClassName(pageNumberSelector));
            var numberOfPages = countPages[pageIndex];
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

            var countProductsOnPage = driver.FindElements(By.ClassName(removeProductsSelector)).Count;
            int[] prodInCart = new int[] { countProductsOnPage };
            Console.Write(countProductsOnPage);


            /*foreach (int val in prodInCart)
            {
                driver.FindElement(By.ClassName(removeProductsSelector)).Click();
            }*/
            /*
            for (int i = 0; i < prodInCart; i++)
            {
                //driver.FindElement(By.ClassName(removeProductsSelector)).Click();
                Console.Write(countProductsOnPage);
            }
            //return countProductsOnPage; 
            */
           
            for (int i = 0; i <= countProductsOnPage; i++)
            {
            driver.FindElement(By.ClassName(removeProductSelector)).Click();
            }
            
        }

    }
}
