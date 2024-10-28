using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace JustFoia.Page
{
    public class Page13
    {
        private readonly Locator13 _locator13;
        private readonly IPage _page;
        private readonly Login _login;
        public Page13(IPage page)
        {
            _page = page;
            _locator13 = new Locator13(_page);
            _login = new Login(_page);
        }
        //Verify Tags Columns Sort Properly
        public async Task VerifyTagsColumnsSortProperlyAsync()
        {
            await _login.DoLogin();
            await _locator13.Label("Profile options").ClickAsync();
            await _locator13.AriaLink("Tags").ClickAsync();
            await _locator13.AriaButton("Add New").ClickAsync();
            await _locator13.Label("Keywords *").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string tagName = "TagTest" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator13.Label("Keywords *").FillAsync(tagName);
            await _locator13.GetLabelNew("Description").ClickAsync();
            string description = "TagTestDescription" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator13.GetLabelNew("Description").FillAsync(description);
            await _locator13.AriaButton("Save").ClickAsync();
            await _locator13.Label("Tag: Sorted ascending.").GetByText("arrow_upward").ClickAsync();
            await _page.PauseAsync();
            var tagSelect = await _page.QuerySelectorAllAsync("td:nth-child(1)");
            var tagList = new List<string>();
            foreach (var cell in tagSelect)
            {
                tagList.Add(await cell.InnerTextAsync());
            }

            bool isDescending = tagList.SequenceEqual(tagList.OrderByDescending(h => h));
            if (isDescending)
            {
                Console.WriteLine("Tag names in descending order.");
            }
            await _locator13.Label("Description: Not sorted.").GetByText("arrow_upward").ClickAsync();
            var descript = await _page.QuerySelectorAllAsync("td:nth-child(2)");
            var dList = new List<string>();
            foreach (var cell in descript)
            {
                dList.Add(await cell.InnerTextAsync());
            }
            bool IsAscending = dList.SequenceEqual(dList.OrderBy(h => h));
            if (IsAscending)
            {
                Console.WriteLine("Description in Ascending order.");
            }
            await _locator13.Label("Description: Sorted ascending").ClickAsync();
            var descript2 = await _page.QuerySelectorAllAsync("td:nth-child(2)");
            var dList2 = new List<string>();
            foreach (var cell in descript2)
            {
                dList2.Add(await cell.InnerTextAsync());
            }
            bool IsDescending = dList2.SequenceEqual(dList2.OrderByDescending(h => h));
            if (IsDescending)
            {
                Console.WriteLine("The holiday dates are in Descending order.");
            }
        }
    }
}
