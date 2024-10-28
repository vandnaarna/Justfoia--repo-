using Microsoft.Playwright;
using JustFoia.Common;
using JustFoia.Page;

namespace JustFoia.Locator
{
     public class Locator2
     {
        private readonly IPage _page;
        public Locator2(IPage page)
        {
             _page = page;
        }
        public ILocator Label(string name) => _page.GetByLabel(name);
        public ILocator AriaButton(string log) => _page.GetByRole(AriaRole.Button, new() { Name = log });
        public ILocator AriaLink(string local) => _page.GetByRole(AriaRole.Link, new() { Name = local });
    }
}
