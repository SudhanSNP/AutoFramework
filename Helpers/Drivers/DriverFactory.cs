﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Helpers.Drivers
{
    public class DriverFactory
    {
        private IDriver driver;
        private DriverType driverType;

        public DriverFactory(DriverType type)
        {
            driverType = type;
        }

        public IDriver GetDriverType()
        {
            switch (driverType)
            {
                case DriverType.Chrome:
                    driver = new Chrome();
                    break;
                case DriverType.Firefox:
                    driver = new Firefox();
                    break;
                default:
                    Console.WriteLine("Enter the valid browser");
                    break;
            }
            return driver;
        }
    }
}