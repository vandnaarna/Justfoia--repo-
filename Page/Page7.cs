using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;
namespace JustFoia.Page
{
    public class Page7
    {
        private readonly Locator7 _locator7;
        private readonly IPage _page;
        private readonly Login _login;
        public Page7(IPage page)
        {
            _page = page;
            _login = new Login(_page);
            _locator7 = new Locator7(_page);
        }
        //Verify that tags can be created
        public async Task VerifyThatTagsCanBeCreatedAsync()
        {
            await _login.DoLogin();
            await _locator7.Label("Profile options").ClickAsync();
            await _locator7.AriaNewLink("Tags").ClickAsync();
            await _locator7.AriaButton("Add New").ClickAsync();
            await _locator7.Label("Keywords *").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string tagName = "TagTest" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator7.Label("Keywords *").FillAsync(tagName);
            await _locator7.GetLabelNew("Description").ClickAsync();
            string description = "TagTestDescription" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator7.GetLabelNew("Description").FillAsync(description);
            await _locator7.AriaButton("Save").ClickAsync();
            await Expect(_page.GetByText("×Tag created!")).ToBeVisibleAsync();
        }
    }
}
