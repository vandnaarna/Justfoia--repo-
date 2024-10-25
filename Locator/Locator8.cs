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
        private IPage page8;
        public Locator8(IPage page)
        {
            page8 = page;
        }
        public ILocator label(string name) => page8.GetByLabel(name);
        public ILocator Arialink(string link) => page8.GetByRole(AriaRole.Link, new() { Name = link});
        public ILocator Ariabutton(string button) => page8.GetByRole(AriaRole.Button, new() { Name = button });
        public ILocator getlabel(string desc) => page8.GetByLabel(desc, new() { Exact = true });
    }
}
