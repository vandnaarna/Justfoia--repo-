using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using static Microsoft.Playwright.Assertions;
namespace JustFoia.Page
{
    public class Page9
    {
        private Locator9 _loc;
        private IPage _page;
        private Login _login;
        public Page9(IPage page)
        {
            _page = page;
            _login = new Login(_page);
            _loc = new Locator9(_page);
        }
        //Verify that tags can be applied to a request
        public async Task Verifythattagscanbeappliedtorequest()
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
            await _loc.label("Request list").ClickAsync();
            //Add new request
            await _loc.Ariabutton("Add New").ClickAsync();
            await _loc.Arialink("Public Records Request").First.ClickAsync();
            await _loc.placehold("John Doe").ClickAsync();
            await _loc.placehold("John Doe").FillAsync("john");
            await _loc.placehold("###-###-####").ClickAsync();
            await _loc.placehold("###-###-####").FillAsync("975820106912");
            await _loc.placehold("johndoe@example.com").ClickAsync();
            await _loc.placehold("johndoe@example.com").FillAsync("john@example.com");
            await _loc.placehold("Example Drive").ClickAsync();
            await _loc.placehold("Example Drive").FillAsync("scheme no 54");
            await _loc.label("City").ClickAsync();
            await _loc.label("City").PressAsync("CapsLock");
            await _loc.label("City").FillAsync("Indore");
            await _loc.label("State").ClickAsync();
            await _loc.label("State").FillAsync("madhya pradesh");
            await _loc.placehold("11111").ClickAsync();
            await _loc.placehold("11111").FillAsync("23212");
            await _loc.placehold("Enter Text").ClickAsync();
            await _loc.placehold("Enter Text").FillAsync("request for details");
            await _loc.Ariabutton("Submit").ClickAsync();
            await _loc.Arialink("Edit This Request").ClickAsync();
            await _loc.Regex("^Public Records Requesthelp_outline$").GetByRole(AriaRole.Button).Nth(4).ClickAsync();
            await _loc.Filter("Public Portal Settings").ClickAsync();
            var checkbox = _loc.Regex("^check_box_outline_blank$").Locator("div").ClickAsync();
            if (checkbox==null)
            {
                await _page.Locator("div").Filter(new()
                { HasTextRegex = new Regex("^check_box$") }).Locator("div").ClickAsync();
            }
            await _loc.label("Select Tags").ClickAsync();
            await _loc.Filter(tagname).ClickAsync();
            await _page.Locator(".container").First.ClickAsync();
            await _loc.Ariabutton("Save").ClickAsync();
            //await Expect(_page.GetByText("Tags (1)")).ToBeVisibleAsync();
        }
    }
}
