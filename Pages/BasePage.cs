﻿using Helpers.Actions;
using OpenQA.Selenium;

namespace Pages
{
    public sealed class BasePage : DriverActions
    {
        public KeyBoardActions keysAction = new KeyBoardActions();
        public MouseActions mouseAction = new MouseActions();
        private static Lazy<BasePage> _basePage = new Lazy<BasePage>(() => new BasePage());
        public static BasePage GetInstance
        {
            get
            {
                return _basePage.Value;
            }
        }

        private BasePage()
        {
            Console.WriteLine("--------------------------- EPAM Base Page ---------------------------");
        }

        public override void SetWebDriver(IWebDriver _driver)
        {
            driver = _driver;
        }
    }
}
