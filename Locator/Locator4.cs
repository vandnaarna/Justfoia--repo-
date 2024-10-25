using Microsoft.Playwright;
using JustFoia.Common;

namespace JustFoia.Locator
{
    public class Locator4
    {
        private readonly IPage page4;
        public Locator4(IPage page)
        {
            page4 = page;
        }
        public ILocator locator2(string name) => page4.GetByLabel(name);
        public ILocator locator3(string log) => page4.GetByRole(AriaRole.Button, new() { Name = log });
        public ILocator locator5(string button) => page4.Locator("button").Filter(new() { HasText = button });
        public ILocator locator4(string local) => page4.GetByRole(AriaRole.Link, new() { Name = local });

    }
}


