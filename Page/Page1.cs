using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace JustFoia.Page
{

    public class Page1
    {
        private Locator1 _loc;
        private IPage _page;
        private Login _login;
        public Page1(IPage page)
        {
            _page = page;
            _loc = new Locator1(_page);
            _login = new Login(_page);
        }
        //Verify holidays can be created, edited and archived
        public async Task VerifyholidayscanbecreatededitedarchivedAsync()
        {
            await _login.DoLogin();
            {
                await _loc.lable("Profile options").ClickAsync();
                await _loc.Arialink("Holidays").ClickAsync();
                await _loc.ariabuttonnew("Add New").ClickAsync();
                await _loc.lable("Holiday Name").ClickAsync();
                DateTime dateTime = DateTime.Now;
                string holidayName = "TestHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");
                await _loc.lable("Holiday Name").FillAsync(holidayName);
                await _loc.lable("Holiday Date").ClickAsync();
                Random random = new Random();
                int day = random.Next(1, 30);
                int month = random.Next(1, 12);
                for (int i = 0; i < month; i++)
                {
                    await _loc.locatorbuttonnew("chevron_left").First.ClickAsync();
                }
                await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();
                await _loc.ariabuttonnew("OK").ClickAsync();
                await _loc.ariabuttonnew("Save").ClickAsync();

                //Edit locator
                await _page.GetByRole(AriaRole.Row, new() { Name = holidayName }).GetByRole(AriaRole.Button).First.ClickAsync();
                await _loc.lable("Holiday Name").ClickAsync();
                string holidayName2 = "EditHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");
                await _loc.lable("Holiday Name").FillAsync(holidayName2);
                await _loc.lable("Holiday Date").ClickAsync();
                for (int i = 0; i < month; i++)
                {
                    await _loc.locatorbuttonnew("chevron_left").First.ClickAsync();
                }
                await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();
                await _loc.ariabuttonnew("OK").ClickAsync();
                await _loc.ariabuttonnew("Save").ClickAsync();
                await _loc.lable("Filter").ClickAsync();
                await _loc.lable("Filter").FillAsync(holidayName2);
                await _loc.lable("Filter").PressAsync("Enter");
                await _loc.locatorbuttonnew("archive").ClickAsync();
                await _loc.ariabuttonnew("Yes").First.ClickAsync();
                await Expect(_page.GetByText("×Holiday deleted!")).ToBeVisibleAsync();
            }

        }
    }
}