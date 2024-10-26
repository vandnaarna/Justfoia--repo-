using JustFoia.Page;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace JustFoia.Test
{
    public class Test8 : PageTest
    {
        private Page8? page8;
        [SetUp]
        public void Setup()
        {
            page8 = new Page8(Page);
        }
        [Test]
        public async Task Case8()
        {
            await page8!.VerifyThatTagsCanBeEditedAsync();
        }
    }
}