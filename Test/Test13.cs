using JustFoia.Page;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace JustFoia.Test
{
    public class Test13 : PageTest
    {
        private Page13? page13;

        [SetUp]
        public void Setup()
        {
            page13 = new Page13(Page);
        }
        [Test]
        public async Task Case13()
        {
            await page13!.VerifyTagsColumnsSortProperlyAsync();
        }
    }
}