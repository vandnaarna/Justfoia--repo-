using Microsoft.Playwright;
using JustFoia.Common;
using JustFoia.Page;

namespace JustFoia.Locator
{
    public class Locator6
    {
        private readonly IPage _page;
        public Locator6(IPage page)
        {
            _page = page;
        }
        public ILocator GetByRoleAriaCell(string name) => _page.GetByRole(AriaRole.Cell,new(){ Name = name });
        public ILocator Label(string name) => _page.GetByLabel(name);
        public ILocator AriaButton(string log) => _page.GetByRole(AriaRole.Button,new(){ Name = log });
        public ILocator ButtonFilter(string button) => _page.Locator("button").Filter(new(){ HasText = button });
        public ILocator AriaLink(string local) => _page.GetByRole(AriaRole.Link, new(){ Name = local });
    }
}
