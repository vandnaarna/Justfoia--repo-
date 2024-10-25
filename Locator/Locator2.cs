using Microsoft.Playwright;
using JustFoia.Common;
using JustFoia.Page;

namespace JustFoia.Locator
{
     public class Locator2
     {
        private readonly IPage page2;
        public Locator2(IPage page)
        {
             page2 = page;
        }
        public ILocator locator(string name) => page2.GetByLabel(name);
        public ILocator locator2(string log) => page2.GetByRole(AriaRole.Button, new() { Name = log });
        public ILocator locator4(string local) => page2.GetByRole(AriaRole.Link, new() { Name = local });
    }
}
