using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace JustFoia.Page
{
    public class Page6
    {
        private Locator6 _loc;
        private IPage _page;
        private Login _login;
        public Page6(IPage page)
        {
            _page = page;
            _loc = new Locator6(_page);
            _login = new Login(_page);
        }
        //Verify that the columns in Holiday can be sorted both in alphabetical and ascending/desecending order
        public async Task VerifythatcolumnsinHolidaybesortedbothinalphabateandascdesorderAsync()
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
                await _page.Locator("button").Filter(new() { HasText = "chevron_left" }).First.ClickAsync();
            }
            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();
            await _loc.locator3("OK").ClickAsync();
            await _loc.locator3("Save").ClickAsync();
            await _page.PauseAsync();
            await _page.GetByLabel("Holiday: Sorted ascending.").
               GetByText("arrow_upward").ClickAsync();
            var holidayCells = await _page.QuerySelectorAllAsync("td.text-xs-left:nth-child(1)");
            var holidays = new List<string>();
            foreach (var cell in holidayCells)
            {
                holidays.Add(await cell.InnerTextAsync());
            }

            bool isDescending = holidays.SequenceEqual(holidays.OrderByDescending(h => h));
            if (isDescending)
            {
                Console.WriteLine("The holiday names in ascending order.");
            }
            await Expect(_page.GetByLabel("Holiday: Sorted descending.").GetByText("arrow_upward")).ToBeVisibleAsync();
            await _page.GetByLabel("Date: Not sorted. Activate to")
                .GetByText("arrow_upward").ClickAsync();


            var dateCell = await _page.QuerySelectorAllAsync("td.text-xs-left:nth-child(2)");
            var date = new List<string>();
            foreach (var cell in dateCell)
            {
                date.Add(await cell.InnerTextAsync());
            }
            bool IsAscending = date.SequenceEqual(date.OrderBy(h => h));
            if (IsAscending)
            {
                Console.WriteLine("The holiday dates are in Ascending order.");
            }
            await _page.GetByLabel("Date: Sorted ascending.").ClickAsync();
            // await Expect(_page.GetByLabel("Date: Not sorted. Activate to").GetByText("arrow_upward")).ToBeVisibleAsync();
            var dateCell2 = await _page.QuerySelectorAllAsync("td.text-xs-left:nth-child(2)");
            var date2 = new List<string>();
            foreach (var cell in dateCell2)
            {
                date2.Add(await cell.InnerTextAsync());
            }
            bool IsDescending = date2.SequenceEqual(date2.OrderByDescending(h => h));
            if (IsDescending)
            {
                Console.WriteLine("The holiday dates are in Descending order.");
            }
            await Expect(_page.GetByLabel("Date: Sorted descending.").GetByText("arrow_upward")).ToBeVisibleAsync();
        }
    }
}
