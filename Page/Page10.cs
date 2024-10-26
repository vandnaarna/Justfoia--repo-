using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Text.RegularExpressions;
using static Microsoft.Playwright.Assertions;

namespace JustFoia.Page
{  
    public class Page10
    {
        private readonly Locator10 _locator10;
        private readonly IPage _page;
        private readonly Login _login;
        public Page10(IPage page)
        {
            _page = page;
            _locator10 = new Locator10(_page);
            _login = new Login(_page);
        }
        //Verify that tags can be archived
        public async Task VerifyThatTagsCanBeArchivedAsync()
        {
            await _login.DoLogin();
            await _locator10.Label("Profile options").ClickAsync();
            await _locator10.AriaNewLink("Tags").ClickAsync();
            await _locator10.AriaButtonNew("Add New").ClickAsync();
            await _locator10.Label("Keywords *").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string tagName = "TagTest" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator10.Label("Keywords *").FillAsync(tagName);
            await _locator10.GetLabelNew("Description").ClickAsync();
            string description = "TagTestDescription" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator10.GetLabelNew("Description").FillAsync(description);
            await _locator10.AriaButtonNew("Save").ClickAsync();
            //Archive Label
            await _locator10.AriaRow(tagName).GetByRole(AriaRole.Button).Nth(1).ClickAsync();
            await _locator10.AriaButtonNew("No").ClickAsync();
            await _locator10.AriaRow(tagName).GetByRole(AriaRole.Button).Nth(1).ClickAsync();
            await _locator10.AriaButtonNew("Yes").ClickAsync();
            await _page.Locator("nav").Filter(new() { HasText = "Filter" }).GetByRole(AriaRole.Button).ClickAsync();
            await _page.Locator(".v-input--selection-controls__ripple").ClickAsync();
            await Expect(_page.GetByText("Show Archived Tags")).ToBeVisibleAsync();
        }
    }
}
