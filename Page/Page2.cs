using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace JustFoia.Page
{
    public class Page2
    {
        private Locator2 _loc;
        private IPage _page;
        private Login _login;
        public Page2(IPage page)
        {
            _page = page;
            _loc = new Locator2(_page);
            _login = new Login(_page);
        }

        //Verify Holiday can be created
        public async Task VerifyHolidaycanbecreated()
        {
            await _login.DoLogin();
            await _page.Locator("#main-content").GetByText("arrow_drop_down").ClickAsync();
            await _page.Locator("a").Filter(new() { HasText = "All" }).ClickAsync();
            await _loc.locator("Profile options").ClickAsync();
            await _loc.locator4("Holidays").ClickAsync();
            await _loc.locator2("Add New").ClickAsync();
            await _loc.locator("Holiday Name").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string holidayName = "TestHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");
            await _loc.locator("Holiday Name").FillAsync(holidayName);
            await _loc.locator("Holiday Date").ClickAsync();
            Random random = new Random();
            int day = random.Next(1, 30);
            int month = random.Next(1, 12);
            for (int i = 0; i < month; i++)
            {
                await _page.Locator("button").Filter(new() { HasText = "chevron_left" }).First.ClickAsync();
            }
            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();
            await _loc.locator2("OK").ClickAsync();
            await _loc.locator2("Save").ClickAsync();
            await Expect(_page.GetByText("Holiday created!")).ToBeVisibleAsync();
        }
    }
}
