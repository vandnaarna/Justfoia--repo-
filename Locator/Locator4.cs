using Microsoft.Playwright;
using JustFoia.Common;

namespace JustFoia.Locator
{
    public class Locator4
    {
        private readonly IPage _page;
        public Locator4(IPage page)
        {
            _page = page;
        }
        public ILocator Label(string name) => _page.GetByLabel(name);
        public ILocator AriaButton(string log) => _page.GetByRole(AriaRole.Button, new() { Name = log });
        public ILocator LocatorFilter(string button) => _page.Locator("button").Filter(new() { HasText = button });
        public ILocator AriaLink(string local) => _page.GetByRole(AriaRole.Link, new() { Name = local });
    }
}


