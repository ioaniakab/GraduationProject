﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateProject.Pages
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
