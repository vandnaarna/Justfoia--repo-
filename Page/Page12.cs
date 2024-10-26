using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using static Microsoft.Playwright.Assertions;

namespace JustFoia.Page
{
    public class Page12
    {
        private readonly Locator12 _locator12;
        private readonly IPage _page;
        private readonly Login _login;
        public Page12(IPage page)
        {
            _page = page;
            _locator12 = new Locator12(_page);
            _login = new Login(_page);
        }
        //Verify that archived tags are not applicable to a request
        public async Task VerifyThatArchivedTagsAreNotApplicableToRequestAsync()
        {
            await _login.DoLogin();
            await _locator12.Label("Profile options").ClickAsync();
            await _locator12.AriaNewLink("Tags").ClickAsync();
            await _locator12.AriaButton("Add New").ClickAsync();
            await _locator12.Label("Keywords *").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string tagName = "TagTest" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator12.Label("Keywords *").FillAsync(tagName);
            await _locator12.GetLabel("Description").ClickAsync();
            string description = "TagTestDescription" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _locator12.GetLabel("Description").FillAsync(description);
            await _locator12.AriaButton("Save").ClickAsync();
            await _locator12.Label("Request list").ClickAsync();
            //Add new request
            await _locator12.AriaButton("Add New").ClickAsync();
            await _locator12.AriaNewLink("Public Records Request").First.ClickAsync();
            await _locator12.PlaceHold("John Doe").ClickAsync();
            await _locator12.PlaceHold("John Doe").FillAsync("john");
            await _locator12.PlaceHold("###-###-####").ClickAsync();
            await _locator12.PlaceHold("###-###-####").FillAsync("975820106912");
            await _locator12.PlaceHold("johndoe@example.com").ClickAsync();
            await _locator12.PlaceHold("johndoe@example.com").FillAsync("john@example.com");
            await _locator12.PlaceHold("Example Drive").ClickAsync();
            await _locator12.PlaceHold("Example Drive").FillAsync("scheme no 54");
            await _locator12.Label("City").ClickAsync();
            await _locator12.Label("City").PressAsync("CapsLock");
            await _locator12.Label("City").FillAsync("Indore");
            await _locator12.Label("State").ClickAsync();
            await _locator12.Label("State").FillAsync("madhya pradesh");
            await _locator12.PlaceHold("11111").ClickAsync();
            await _locator12.PlaceHold("11111").FillAsync("23212");
            await _locator12.PlaceHold("Enter Text").ClickAsync();
            await _locator12.PlaceHold("Enter Text").FillAsync("request for details");
            await _locator12.AriaButton("Submit").ClickAsync();
            await _locator12.AriaNewLink("Edit This Request").ClickAsync();
            await _page.ClickAsync("i.mdi.mdi-dots-vertical");
            await _locator12.Filter("Public Portal Settings").ClickAsync();
            var checkbox = _locator12.Regex("^check_box_outline_blank$").Locator("div").ClickAsync();
            if (checkbox == null)
            {
                await _page.Locator("div").Filter(new()
                { HasTextRegex = new Regex("^check_box$") }).Locator("div").ClickAsync();
            }
            await _locator12.Label("Select Tags").ClickAsync();
            await _locator12.Filter(tagName).ClickAsync();
            await _locator12.AriaButton("Save").ClickAsync();
        }
    }
}