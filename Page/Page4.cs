using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace JustFoia.Page
{
    public class Page4
    {
        private  readonly Locator4 _locator4;
        private  readonly IPage _page;
        private readonly Login _login;
        public Page4(IPage page)
        {
            _page = page;
            _locator4 = new Locator4(_page);
            _login = new Login(_page);
        }
        //Verify Holiday can be Archived
        public async Task VerifyHolidayCanBeArchivedAsync()
        {
            await _login.DoLogin();
            await _page.Locator("#main-content").GetByText("arrow_drop_down").ClickAsync();
            await _page.Locator("a").Filter(new() { HasText = "All" }).ClickAsync();
            await _locator4.Label("Profile options").ClickAsync();
            await _locator4.AriaLink("Holidays").ClickAsync();
            await _locator4.AriaButton("Add New").ClickAsync();
            await _locator4.Label("Holiday Name").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string holidayName = "TestHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");
            await _locator4.Label("Holiday Name").FillAsync(holidayName);
            await _locator4.Label("Holiday Date").ClickAsync();
            Random random = new Random();
            int day = random.Next(1, 30);
            int month = random.Next(1, 12);
            for (int i = 0; i < month; i++)
            {
                await _locator4.LocatorFilter("chevron_left").First.ClickAsync();
            }
            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();
            await _locator4.AriaButton("OK").ClickAsync();
            await _locator4.AriaButton("Save").ClickAsync();
            await _locator4.Label("Filter").ClickAsync();
            await _locator4.Label("Filter").FillAsync(holidayName);
            await _locator4.Label("Filter").PressAsync("Enter");
            await _locator4.LocatorFilter("archive").ClickAsync();
            await _locator4.AriaButton("No").ClickAsync();
            await _locator4.LocatorFilter("archive").ClickAsync();
            await _locator4.AriaButton("Yes").ClickAsync();
            await Expect(_page.GetByText("×Holiday deleted!")).ToBeVisibleAsync();
        }
    }
}
