using Microsoft.Playwright;
using JustFoia.Common;
using JustFoia.Page;

namespace JustFoia.Locator
{
    public class Locator3
    {
        private readonly IPage page3;
        public Locator3(IPage page)
        {
            page3 = page;
        }
        public ILocator locator(string name) => page3.GetByLabel(name);
        public ILocator locator4(string local) => page3.GetByRole(AriaRole.Link, new() { Name = local });
        public ILocator locator5(string button) => page3.Locator("button").Filter(new() { HasText = button });
        public ILocator locator3(string log) => page3.GetByRole(AriaRole.Button, new() { Name = log });
    }
}


