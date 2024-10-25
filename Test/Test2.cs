using JustFoia.Page;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace JustFoia.Test
{
    public class Test2 : PageTest
    {
        private Page2? page2;
        [SetUp]
        public void setup()
        {
            page2 = new Page2(Page);
        }
        [Test]
        public async Task Case2()
        {
            await page2!.VerifyHolidaycanbecreated();
        }
    }
}
