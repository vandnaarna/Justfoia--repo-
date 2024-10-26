using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace JustFoia.Page
{
    public class Page11
    {
        private readonly Locator11 _locator11;
        private  readonly IPage _page;
        private  readonly Login _login;
        public Page11(IPage page)
        {
            _page = page;
            _locator11 = new Locator11(_page);
            _login = new Login(_page);
        }
        //Verify Tags can be Deleted
        public async Task VerifyTagsCanBeDeletedAsync()
        {
            await _login.DoLogin();
            await _locator11.Label("Profile options").ClickAsync();
            await _locator11.AriaNewLink("Tags").ClickAsync();
            //Create new tag
            await _locator11.AriaButton("Add New").ClickAsync();
            await _locator11.Label("Keywords *").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string tagName = "TagTest" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator11.Label("Keywords *").FillAsync(tagName);
            await _locator11.GetLabelNew("Description").ClickAsync();
            string description = "TagTestDescription" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator11.GetLabelNew("Description").FillAsync(description);
            await _locator11.AriaButton("Save").ClickAsync();
            //Archive Label
            await _locator11.AriaRow(tagName).GetByRole(AriaRole.Button).Nth(1).ClickAsync();
            await _locator11.AriaButton("Yes").ClickAsync();
            await _page.Locator("nav").Filter(new() { HasText = "Filter" }).GetByRole(AriaRole.Button).ClickAsync();
            await _page.Locator(".v-input--selection-controls__ripple").ClickAsync();
            //Delete Label
            await _locator11.AriaRow(tagName).GetByRole(AriaRole.Button).Nth(1).ClickAsync();
            await _locator11.AriaButton("No").ClickAsync();
            await _locator11.AriaRow(tagName).GetByRole(AriaRole.Button).Nth(1).ClickAsync();
            await _locator11.AriaButton("Yes").ClickAsync();
            await Expect(_page.GetByText("Tag deleted!")).ToBeVisibleAsync();
        }
    }
}