using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace JustFoia.Page
{
    public class Page1
    {
        private readonly Locator1 _locator1;
        private readonly IPage _page;
        private readonly Login _login;
        public Page1(IPage page)
        {
            _page = page;
            _locator1 = new Locator1(_page);
            _login = new Login(_page);
        }
        //Verify holidays can be created, edited and archived
        public async Task VerifyHolidaysCanBeCreatedEditedArchivedAsync()
        {
            await _login.DoLogin();
            await _locator1.lable("Profile options").ClickAsync();
            await _locator1.AriaLink("Holidays").ClickAsync();
            await _locator1.ariabuttonnew("Add New").ClickAsync();
            await _locator1.lable("Holiday Name").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string holidayName = "TestHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");
            await _locator1.lable("Holiday Name").FillAsync(holidayName);
            await _locator1.lable("Holiday Date").ClickAsync();
            Random random = new Random();
            int day = random.Next(1, 30);
            int month = random.Next(1, 12);
            for (int i = 0; i < month; i++)
            {
                await _locator1.LocatorButtonNew("chevron_left").First.ClickAsync();
            }
            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();
            await _locator1.ariabuttonnew("OK").ClickAsync();
            await _locator1.ariabuttonnew("Save").ClickAsync();
            //Edit Label
            await _page.GetByRole(AriaRole.Row, new() { Name = holidayName }).GetByRole(AriaRole.Button).First.ClickAsync();
            await _locator1.lable("Holiday Name").ClickAsync();
            string holidayName2 = "EditHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");
            await _locator1.lable("Holiday Name").FillAsync(holidayName2);
            await _locator1.lable("Holiday Date").ClickAsync();
            for (int i = 0; i < month; i++)
            {
                await _locator1.LocatorButtonNew("chevron_left").First.ClickAsync();
            }
            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();
            await _locator1.ariabuttonnew("OK").ClickAsync();
            await _locator1.ariabuttonnew("Save").ClickAsync();
            await _locator1.lable("Filter").ClickAsync();
            await _locator1.lable("Filter").FillAsync(holidayName2);
            await _locator1.lable("Filter").PressAsync("Enter");
            await _locator1.LocatorButtonNew("archive").ClickAsync();
            await _locator1.ariabuttonnew("Yes").First.ClickAsync();
            await Expect(_page.GetByText("×Holiday deleted!")).ToBeVisibleAsync();
        }
    }
}
