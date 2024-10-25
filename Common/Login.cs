using JustFoia.Locator;
using Microsoft.Playwright;

namespace JustFoia.Common
{
    public class Login
    {
        private Locator1 _locate;
        private IPage page;
        public Login(IPage page1)
        {
            page = page1;
            _locate = new Locator1(page1);
        }
        public async Task DoLogin()
        {
            await page.GotoAsync("https://qa1auto.devjustfoia.com/Account/Login?ReturnUrl=%2FHolidays%2FList");
            await _locate.lable("User Name").ClickAsync();
            await _locate.lable("User Name").FillAsync("MCCi1");
            await _locate.lable("Password").ClickAsync();
            await _locate.lable("Password").FillAsync("Y*5e4b%J9bov46e5");
            await _locate.ariabuttonnew("Login").ClickAsync();
        }      
    }
}
