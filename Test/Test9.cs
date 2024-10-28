using JustFoia.Page;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFoia.Test
{
    public class Test9 : PageTest
    {
        private Page9? page9;
        [SetUp]
        public void Setup()
        {
            page9 = new Page9(Page);
        }
        [Test]
        public async Task Case9()
        {
            await page9!.VerifyThatTagsCanBeAppliedToRequestAsync();
        }
    }
}
