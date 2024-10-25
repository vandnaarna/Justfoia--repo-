using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
namespace JustFoia.Page
{
    public class Page8
    {
        private Locator8 _loc;
        private IPage _page;
        private Login _login;
        public Page8(IPage page)
        {
            _page = page;
            _login = new Login(_page);
            _loc = new Locator8(_page);
        }
        //Verify that tags can be edited
        public async Task VerifythattagscanbeeditedAsync()
        {
            await _login.DoLogin();
            await _loc.label("Profile options").ClickAsync();
            await _loc.Arialink("Tags").ClickAsync();
            await _loc.Ariabutton("Add New").ClickAsync();
            await _loc.label("Keywords *").ClickAsync();
            DateTime dateTime = DateTime.Now;
            string tagname = "Tagtest" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _loc.label("Keywords *").FillAsync(tagname);
            await _loc.getlabel("Description").ClickAsync();
            string description = "Tagtestdescription" + dateTime.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
            await _loc.getlabel("Description").FillAsync(description);
            await _loc.Ariabutton("Save").ClickAsync();
            //Edit locator
            await _page.GetByRole(AriaRole.Row, new() { Name = tagname }).GetByRole(AriaRole.Button).First.ClickAsync();
            await _loc.label("Keywords *").ClickAsync();
            await _loc.label("Keywords *").FillAsync(tagname);
            await _loc.getlabel("Description").ClickAsync();
            await _loc.getlabel("Description").FillAsync(description);
            await _loc.Ariabutton("Save").ClickAsync();
            await Expect(_page.GetByText("Tag updated!")).ToBeVisibleAsync();
        }
    }
}
