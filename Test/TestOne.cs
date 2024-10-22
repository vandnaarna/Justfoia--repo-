using JustFoia.Page;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Text.RegularExpressions;


namespace JustFoia.Test
{
 public class TestOne : PageTest
    {
        private PageOne  page1;

        [SetUp]
        public void setup()
        {
            page1 = new PageOne(Page);
        }

        [Test]
        public async Task Test7()
        {
            //await page1.TestCase1();
            //await Expect(Page.GetByText("×Holiday deleted!")).ToBeVisibleAsync();


            //await page1.TestCase2();
            //await Expect(Page.GetByText("Holiday created!")).ToBeVisibleAsync();


            //await page1.TestCase3();
            //await Expect(Page.GetByText("×Holiday updated!")).ToBeVisibleAsync();

            await page1.TestCase4();
            await Expect(Page.GetByText("×Holiday deleted!")).ToBeVisibleAsync();

            //await page1.TestCase5();
            //await Expect(Page.Locator("div")
            //.Filter(new() { HasTextRegex = new Regex("^Save$") }).First).ToBeVisibleAsync();

        }
    }
}


  
