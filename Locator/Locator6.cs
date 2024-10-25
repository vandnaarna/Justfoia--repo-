using Microsoft.Playwright;
using JustFoia.Common;
using JustFoia.Page;

namespace JustFoia.Locator
{
    public class Locator6
    {
        private readonly IPage page6;
        public Locator6(IPage page)
        {
            page6 = page;
        }
        public ILocator locator(string name) => page6.GetByRole(AriaRole.Cell, new()
        { Name = name });
        public ILocator locator2(string name) => page6.GetByLabel(name);
        public ILocator locator3(string log) => page6.GetByRole(AriaRole.Button, new() { Name = log });
        public ILocator locator5(string button) => page6.Locator("button").Filter(new() { HasText = button });
        public ILocator locator4(string local) => page6.GetByRole(AriaRole.Link, new() { Name = local });

    }

}
