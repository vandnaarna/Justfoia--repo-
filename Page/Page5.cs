using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace JustFoia.Page
{
    public class Page5
    {
        private readonly Locator5 _locator5;
        private readonly IPage _page;
        private readonly Login _login;
        public Page5(IPage page)
        {
            _page = page;
            _locator5 = new Locator5(_page);
            _login = new Login(_page);
        }
        //Verify that holiday fields are validated before saving
        public async Task VerifyThatHolidayFieldsAreValidatedBeforeSavingAsync()
        {
            await _login.DoLogin();
            await _page.Locator("#main-content").GetByText("arrow_drop_down").ClickAsync();
            await _page.Locator("a").Filter(new() { HasText = "All" }).ClickAsync();
            await _locator5.Label("Profile options").ClickAsync();
            await _locator5.AriaLink("Holidays").ClickAsync();
            await _locator5.AriaButton("Add New").ClickAsync();
            await _locator5.Label("Holiday Name").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string name = "Testone" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator5.Label("Holiday Name").FillAsync(name);
            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
            await _locator5.Label("Holiday Name").ClickAsync();
            await _locator5.Label("Holiday Name").ClearAsync();
            await _locator5.Label("Holiday Date").ClickAsync();
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
