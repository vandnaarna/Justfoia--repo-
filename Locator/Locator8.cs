using JustFoia.Page;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFoia.Locator
{
    public class Locator8
    {
        private readonly IPage _page;
        public Locator8(IPage page)
        {
            _page = page;
        }
        public ILocator Label(string name) => _page.GetByLabel(name);
        public ILocator AriaLinkNew(string link) => _page.GetByRole(AriaRole.Link, new() { Name = link});
        public ILocator AriaButton(string button) => _page.GetByRole(AriaRole.Button, new() { Name = button });
        public ILocator GetLabelNew(string desc) => _page.GetByLabel(desc, new() { Exact = true });
    }
}
