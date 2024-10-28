using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
namespace JustFoia.Page
{
    public class Page8
    {
        private readonly Locator8 _locator8;
        private readonly IPage _page;
        private readonly Login _login;
        public Page8(IPage page)
        {
            _page = page;
            _login = new Login(_page);
            _locator8 = new Locator8(_page);
        }
        //Verify that tags can be edited
        public async Task VerifyThatTagsCanBeEditedAsync()
        {
            await _login.DoLogin();
            await _locator8.Label("Profile options").ClickAsync();
            await _locator8.AriaLinkNew("Tags").ClickAsync();
            await _locator8.AriaButton("Add New").ClickAsync();
            await _locator8.Label("Keywords *").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string tagName = "TagTest" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator8.Label("Keywords *").FillAsync(tagName);
            await _locator8.GetLabelNew("Description").ClickAsync();
            string description = "TagTestDescription" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator8.GetLabelNew("Description").FillAsync(description);
            await _locator8.AriaButton("Save").ClickAsync();
            //Edit Label
            await _page.GetByRole(AriaRole.Row, new() { Name = tagName }).GetByRole(AriaRole.Button).First.ClickAsync();
            await _locator8.Label("Keywords *").ClickAsync();
            await _locator8.Label("Keywords *").FillAsync(tagName);
            await _locator8.GetLabelNew("Description").ClickAsync();
            await _locator8.GetLabelNew("Description").FillAsync(description);
            await _locator8.AriaButton("Save").ClickAsync();
            await Expect(_page.GetByText("Tag updated!")).ToBeVisibleAsync();
        }
    }
}
