using JustFoia.Page;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace JustFoia.Test
{
    public class Test5 : PageTest
    {
        private Page5? page5;
        [SetUp]
        public void setup()
        {
            page5 = new Page5(Page);
        }
        [Test]
        public async Task Case5()
        {
            await page5!.Verifythatholidayfieldsarevalidatedbeforesaving();
        }
    }
}