using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace JustFoia.Page
{
    public class Page4
    {
        private Locator4 _loc;
        private IPage _page;
        private Login _login;
        public Page4(IPage page)
        {
            _page = page;
            _loc = new Locator4(_page);
            _login = new Login(_page);
        }
        //Verify Holiday can be Archived
        public async Task VerifyHolidaycanbeArchivedAsync()
        {
            await _login.DoLogin();
            await _page.Locator("#main-content").GetByText("arrow_drop_down").ClickAsync();
            await _page.Locator("a").Filter(new() { HasText = "All" }).ClickAsync();
            await _loc.locator2("Profile options").ClickAsync();
            await _loc.locator4("Holidays").ClickAsync();
            await _loc.locator3("Add New").ClickAsync();
            await _loc.locator2("Holiday Name").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string holidayName = "TestHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");
            await _loc.locator2("Holiday Name").FillAsync(holidayName);
            await _loc.locator2("Holiday Date").ClickAsync();
            Random random = new Random();
            int day = random.Next(1, 30);
            int month = random.Next(1, 12);
            for (int i = 0; i < month; i++)
            {
                await _loc.locator5("chevron_left").First.ClickAsync();
            }
            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();
            await _loc.locator3("OK").ClickAsync();
            await _loc.locator3("Save").ClickAsync();
            await _loc.locator2("Filter").ClickAsync();
            await _loc.locator2("Filter").FillAsync(holidayName);
            await _loc.locator2("Filter").PressAsync("Enter");
            await _loc.locator5("archive").ClickAsync();
            await _loc.locator3("No").ClickAsync();
            await _loc.locator5("archive").ClickAsync();
            await _loc.locator3("Yes").ClickAsync();
            await Expect(_page.GetByText("×Holiday deleted!")).ToBeVisibleAsync();
        }
    }
}
