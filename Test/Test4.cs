using JustFoia.Page;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace JustFoia.Test
{
    public class Test4 : PageTest
    {
        private Page4? page4;
        [SetUp]
        public void setup()
        {
            page4 = new Page4(Page);
        }
        [Test]
        public async Task Case4()
        {
            await page4!.VerifyHolidaycanbeArchivedAsync();
        }
    }
}
