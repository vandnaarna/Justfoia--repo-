using JustFoia.Page;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace JustFoia.Test
{
    public class Test12 : PageTest
    {
        private Page12? page12;
        [SetUp]
        public void Setup()
        {
            page12 = new Page12(Page);
        }
        [Test]
        public async Task Case12()
        {
            await page12!.VerifyThatArchivedTagsAreNotApplicableToRequestAsync();
        }
    }
}
