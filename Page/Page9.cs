using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using static Microsoft.Playwright.Assertions;
namespace JustFoia.Page
{
    public class Page9
    {
        private readonly Locator9 _locator9;
        private readonly IPage _page;
        private readonly Login _login;
        public Page9(IPage page)
        {
            _page = page;
            _login = new Login(_page);
            _locator9 = new Locator9(_page);
        }
        //Verify that tags can be applied to a request
        public async Task VerifyThatTagsCanBeAppliedToRequestAsync()
        {
            await _login.DoLogin();
            await _locator9.Label("Profile options").ClickAsync();
            await _locator9.AriaLinkNew("Tags").ClickAsync();
            await _locator9.AriaButton("Add New").ClickAsync();
            await _locator9.Label("Keywords *").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string tagName = "TagTest" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator9.Label("Keywords *").FillAsync(tagName);
            await _locator9.GetLabelNew("Description").ClickAsync();
            string description = "TagTestDescription" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator9.GetLabelNew("Description").FillAsync(description);
            await _locator9.AriaButton("Save").ClickAsync();
            await _locator9.Label("Request list").ClickAsync();
            //Add new request
            await _locator9.AriaButton("Add New").ClickAsync();
            await _locator9.AriaLinkNew("Public Records Request").First.ClickAsync();
            await _locator9.PlaceHold("John Doe").ClickAsync();
            await _locator9.PlaceHold("John Doe").FillAsync("john");
            await _locator9.PlaceHold("###-###-####").ClickAsync();
            await _locator9.PlaceHold("###-###-####").FillAsync("975820106912");
            await _locator9.PlaceHold("johndoe@example.com").ClickAsync();
            await _locator9.PlaceHold("johndoe@example.com").FillAsync("john@example.com");
            await _locator9.PlaceHold("Example Drive").ClickAsync();
            await _locator9.PlaceHold("Example Drive").FillAsync("scheme no 54");
            await _locator9.Label("City").ClickAsync();
            await _locator9.Label("City").PressAsync("CapsLock");
            await _locator9.Label("City").FillAsync("Indore");
            await _locator9.Label("State").ClickAsync();
            await _locator9.Label("State").FillAsync("madhya pradesh");
            await _locator9.PlaceHold("11111").ClickAsync();
            await _locator9.PlaceHold("11111").FillAsync("23212");
            await _locator9.PlaceHold("Enter Text").ClickAsync();
            await _locator9.PlaceHold("Enter Text").FillAsync("request for details");
            await _locator9.AriaButton("Submit").ClickAsync();
            await _page.PauseAsync();
            await _locator9.AriaLinkNew("Edit This Request").ClickAsync();
            await _page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Public Records Requesthelp_outline$") }).GetByRole(AriaRole.Button).Nth(2).ClickAsync();
            await _page.Locator("a").Filter(new() { HasText = "Public Portal Settings" }).ClickAsync();
            var checkbox = _locator9.RegexLocatorFilter("^check_box_outline_blank$").Locator("div").ClickAsync();
            if (checkbox == null)
            {
                await _page.Locator("div").Filter(new()
                { HasTextRegex = new Regex("^check_box$") }).Locator("div").ClickAsync();
            }
            await _locator9.Label("Select Tags").ClickAsync();
            await _locator9.LocatorFilter(tagName).ClickAsync();
            await _page.Locator(".container").First.ClickAsync();
            await _locator9.AriaButton("Save").ClickAsync();
        }
    }
}
