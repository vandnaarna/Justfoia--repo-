using JustFoia.Page;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace JustFoia.Test
{
     public class Test7 : PageTest
     {
        private Page7 _page7;
        [SetUp]
        public void Setup() 
        {
          _page7= new Page7(Page);
        }
        [Test]
        public async Task Case7()
        {
            await _page7.VerifythattagscanbecreatedAsync(); 
        }
     }
}
