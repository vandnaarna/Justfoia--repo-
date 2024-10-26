using Microsoft.Playwright;
using JustFoia.Common;
using JustFoia.Page;

namespace JustFoia.Locator
{
    public class Locator3
    {
        private readonly IPage _page;
        public Locator3(IPage page)
        {
            _page = page;
        }
        public ILocator Label(string name) => _page.GetByLabel(name);
        public ILocator AriaLink(string local) => _page.GetByRole(AriaRole.Link, new() { Name = local });
        public ILocator LocatorFilter(string button) => _page.Locator("button").Filter(new() { HasText = button });
        public ILocator AriaButton(string log) => _page.GetByRole(AriaRole.Button, new() { Name = log });
    }
}


