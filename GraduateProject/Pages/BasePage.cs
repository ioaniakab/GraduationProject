using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationProject.Pages
{
    public class BasePage
    {

        public IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
