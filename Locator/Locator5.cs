using Microsoft.Playwright;
using JustFoia.Common;
using JustFoia.Page;

namespace JustFoia.Locator
{
    public class Locator5
    {
        private readonly IPage page5;
        public Locator5(IPage page)
        {
            page5 = page;
        }
        public ILocator locator2(string name) => page5.GetByLabel(name);
        public ILocator locator3(string log) => page5.GetByRole(AriaRole.Button, new() { Name = log });
        public ILocator locator4(string local) => page5.GetByRole(AriaRole.Link, new() { Name = local });
    }
}
