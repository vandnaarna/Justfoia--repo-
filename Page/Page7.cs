using JustFoia.Common;
using JustFoia.Locator;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;
namespace JustFoia.Page
{
    public class Page7
    {
        private Locator7 _loc;
        private IPage _page;
        private Login _login;
        public Page7(IPage page)
        {
            _page = page;
            _login = new Login(_page);
            _loc = new Locator7(_page);
        }
        //Verify that tags can be created
        public async Task VerifythattagscanbecreatedAsync()
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
            await Expect(_page.GetByText("×Tag created!")).ToBeVisibleAsync();
        }
    }
}
