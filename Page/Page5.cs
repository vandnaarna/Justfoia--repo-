using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace JustFoia.Page
{
    public class Page5
    {
        private Locator5 _loc;
        private IPage _page;
        private Login _login;
        public Page5(IPage page)
        {
            _page = page;
            _loc = new Locator5(_page);
            _login = new Login(_page);
        }
        //Verify that holiday fields are validated before saving
        public async Task Verifythatholidayfieldsarevalidatedbeforesaving()
        {
            await _login.DoLogin();
            await _page.Locator("#main-content").GetByText("arrow_drop_down").ClickAsync();
            await _page.Locator("a").Filter(new() { HasText = "All" }).ClickAsync();
            await _loc.locator2("Profile options").ClickAsync();
            await _loc.locator4("Holidays").ClickAsync();
            await _loc.locator3("Add New").ClickAsync();
            await _loc.locator2("Holiday Name").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string name = "Testone" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _loc.locator2("Holiday Name").FillAsync(name);
            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
            await _loc.locator2("Holiday Name").ClickAsync();
            await _loc.locator2("Holiday Name").ClearAsync();
            await _loc.locator2("Holiday Date").ClickAsync();
            Random random = new Random();
            int date = random.Next(1, 30);
            int month = random.Next(1, 12);
            for (int i = 0; i < month; i++)
            {
                await _page.Locator("button").Filter(new() { HasText = "chevron_left" }).First.ClickAsync();
            }
            await _page.GetByRole(AriaRole.Button, new() { Name = date.ToString(), Exact = true }).First.ClickAsync();
            await _page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Save$") }).First.ClickAsync();
        }
    }
}
