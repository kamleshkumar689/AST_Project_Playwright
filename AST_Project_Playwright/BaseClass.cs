using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace API_Test_Playwright
{
    public class BaseClass
    {
        public IPlaywright playwright;
        public IPage page;
        public static string baseUrl = Constants.baseUrl;

        public async Task InitializePlaywright()
        {
            playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

            page = await browser.NewPageAsync();
        }
    }
}