using JustFoia.Page;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace JustFoia.Test
{
    public class Test11 : PageTest
    {
        private Page11? page11;
        [SetUp]
        public void Setup()
        {
            page11 = new Page11(Page);
        }
        [Test]
        public async Task Case11()
        {
            await page11!.VerifyTagsCanBeDeletedAsync();
        }
    }
}