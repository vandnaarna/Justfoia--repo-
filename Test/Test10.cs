using JustFoia.Page;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace JustFoia.Test
{
    public class Test10 : PageTest
    {
        private Page10? _page10;
        [SetUp]
        public void Setup()
        {
            _page10 = new Page10(Page);
        }
        [Test]
        public async Task Case10()
        {
            await _page10!.VerifyThatTagsCanBeArchivedAsync();
        }
    }
}

