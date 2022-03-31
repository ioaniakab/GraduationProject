using GraduationProject.Pages;
using GraduationProject.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GraduationProject.Tests
{
    class NavigationTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();
        [Category("Menu Navigation")]
        [Test]
        public void NavigationTest()
        {
            String testName = TestContext.CurrentContext.Test.FullName;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage qacc = new MainPage(_driver);
            qacc.CookieAccept();

            Navigation nav = new Navigation(_driver);
            nav.GoContact();
            nav.AccesoriesMenu();
            Assert.IsTrue(nav.CheckAccesoriesPageLabel("ACCESORII"));
            nav.BikesMenu();
            Assert.IsTrue(nav.CheckBikesPageLabel("BICICLETE"));
            nav.GlovesMenu();
            Assert.IsTrue(nav.CheckGlovesPageLabel("MANUSI"));
            nav.HelmetsMenu();
            Assert.IsTrue(nav.CheckHelmetsPageLabel("CASTI"));
            nav.HelmetsAdultMenu();
            Assert.IsTrue(nav.CheckAdultsHelmetsLabel("CASTI ADULTI"));
            nav.HelmetsKidsMenu();
            Assert.IsTrue(nav.CheckKidsHelmetsLabel("CASTI COPII"));
            // Menu deactivate until next winter :)
            //nav.GiftsMenu();
            //Assert.IsTrue(nav.CheckGiftsPageLabel("IDEI DE CADOU"));
        }
    }
}
