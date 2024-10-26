using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace JustFoia.Page
{
    public class Page2
    {
        private readonly Locator2 _locator2;
        private  readonly IPage _page;
        private readonly Login _login;
        public Page2(IPage page)
        {
            _page = page;
            _locator2 = new Locator2(_page);
            _login = new Login(_page);
        }

        //Verify Holiday can be created
        public async Task VerifyHolidayCanBeCreatedAsync()
        {
            await _login.DoLogin();
            await _page.Locator("#main-content").GetByText("arrow_drop_down").ClickAsync();
            await _page.Locator("a").Filter(new() { HasText = "All" }).ClickAsync();
            await _locator2.Label("Profile options").ClickAsync();
            await _locator2.AriaLink("Holidays").ClickAsync();
            await _locator2.AriaButton("Add New").ClickAsync();
            await _locator2.Label("Holiday Name").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string holidayName = "TestHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");
            await _locator2.Label("Holiday Name").FillAsync(holidayName);
            await _locator2.Label("Holiday Date").ClickAsync();
            Random random = new Random();
            int day = random.Next(1, 30);
            int month = random.Next(1, 12);
            for (int i = 0; i < month; i++)
            {
                await _page.Locator("button").Filter(new() { HasText = "chevron_left" }).First.ClickAsync();
            }
            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();
            await _locator2.AriaButton("OK").ClickAsync();
            await _locator2.AriaButton("Save").ClickAsync();
            await Expect(_page.GetByText("Holiday created!")).ToBeVisibleAsync();
        }
    }
}
