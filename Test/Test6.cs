using JustFoia.Page;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace JustFoia.Test
{
   public class Test6 : PageTest
    {
        private Page6? page6;
        [SetUp]
        public void setup()
        {
            page6 = new Page6(Page);
        }
        [Test]
        public async Task Case6()
        {
            await page6!.VerifythatcolumnsinHolidaybesortedbothinalphabateandascdesorderAsync();
        }
    }
}
