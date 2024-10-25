using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using static System.Net.Mime.MediaTypeNames;

namespace JustFoia.Page
{
    public class Page3
    {
        private Locator3 _loc;
        private IPage _page;
        private Login _login;
        public Page3(IPage page)
        {
            _page = page;
            _loc = new Locator3(_page);
            _login = new Login(_page);
        }
        //Verify Holiday can be Edited
        public async Task VerifyHolidaycanbeEditedAsync()
        {
            await _login.DoLogin();
            await _page.Locator("#main-content").GetByText("arrow_drop_down").ClickAsync();
            await _page.Locator("a").Filter(new() { HasText = "All" }).ClickAsync();
            await _loc.locator("Profile options").ClickAsync();
            await _loc.locator4("Holidays").ClickAsync();
            await _loc.locator3("Add New").ClickAsync();
            await _loc.locator("Holiday Name").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string holidayName = "TestHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");
            await _loc.locator("Holiday Name").FillAsync(holidayName);
            await _loc.locator("Holiday Date").ClickAsync();
            Random random = new Random();
            int day = random.Next(1, 30);
            int month = random.Next(1, 12); // Generates a random month between 1 and 12
            for (int i = 0; i < month; i++)
            {
                await _loc.locator5("chevron_left").First.ClickAsync();
            }
            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
            //Edit locator
            await _page.GetByRole(AriaRole.Row, new() { Name = holidayName }).GetByRole(AriaRole.Button).First.ClickAsync();
            await _loc.locator("Holiday Name").ClickAsync();
            string holidayName2 = "EditHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");
            await _loc.locator("Holiday Name").FillAsync(holidayName2);
            await _loc.locator("Holiday Date").ClickAsync();
            for (int i = 0; i < month; i++)
            {
                await _loc.locator5("chevron_left").First.ClickAsync();
            }
            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();
            await _loc.locator3("OK").ClickAsync();
            await _loc.locator3("Save").ClickAsync();
            await Expect(_page.GetByText("×Holiday updated!")).ToBeVisibleAsync();
        }
    }
}
