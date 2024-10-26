using JustFoia.Page;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace JustFoia.Test
{
    public class Test3 : PageTest
    {
        private Page3? page3;
        [SetUp]
        public void Setup()
        {
            page3 = new Page3(Page);
        }
        [Test]
        public async Task Case3()
        {
            await page3!.VerifyHolidayCanBeEditedAsync();
        }
    }
}
