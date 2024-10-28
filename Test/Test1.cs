using JustFoia.Page;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace JustFoia.Test
{
    public class Test1 : PageTest
    {
        private Page1? page1;
        [SetUp]
        public void Setup()
        {
            page1 = new Page1(Page);
        }
        [Test]
        public async Task Case1()
        {
            await page1!.VerifyHolidaysCanBeCreatedEditedArchivedAsync();
        }
    }
}



