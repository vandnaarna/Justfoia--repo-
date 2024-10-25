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
        private Locator10 _loc;
        private IPage _page;
        private Login _login;
        public Page10(IPage page)
        {
            _page = page;
            _loc = new Locator10(_page);
            _login = new Login(_page);
        }
        //Verify that tags can be archived
        public async Task VerifythattagscanbearchivedAsync()
        {
            await _login.DoLogin();
            await _loc.label("Profile options").ClickAsync();
            await _loc.Arianewlink("Tags").ClickAsync();
            await _loc.Ariabutton("Add New").ClickAsync();
            await _loc.label("Keywords *").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string tagname = "Tagtest" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _loc.label("Keywords *").FillAsync(tagname);
            await _loc.getlabel("Description").ClickAsync();
            string description = "Tagtestdescription" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _loc.getlabel("Description").FillAsync(description);
            await _loc.Ariabutton("Save").ClickAsync();
            //Archive locator
            await _loc.Ariarow(tagname).GetByRole(AriaRole.Button).Nth(1).ClickAsync();
            await _loc.Ariabutton("No").ClickAsync();
            await _loc.Ariarow(tagname).GetByRole(AriaRole.Button).Nth(1).ClickAsync();
            await _loc.Ariabutton("Yes").ClickAsync();
            await _page.Locator("nav").Filter(new() { HasText = "Filter" }).GetByRole(AriaRole.Button).ClickAsync();
            await _page.Locator(".v-input--selection-controls__ripple").ClickAsync();
            await Expect(_page.GetByText("Show Archived Tags")).ToBeVisibleAsync();
        }
    }
}
