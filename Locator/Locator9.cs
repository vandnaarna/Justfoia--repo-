using JustFoia.Page;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JustFoia.Locator
{
    public class Locator9
    {
        private IPage page9;
        public Locator9(IPage page)
        {
            page9 = page;
        }
        public ILocator label(string name) => page9.GetByLabel(name);
        public ILocator getlabel(string desc) => page9.GetByLabel(desc, new() { Exact = true });
        public ILocator Arianewlink(string link) => page9.GetByRole(AriaRole.Link, new() { Name = link });
        public ILocator Ariabutton(string button) => page9.GetByRole(AriaRole.Button, new() { Name = button });
        public ILocator Arialink(string link) => page9.GetByRole(AriaRole.Link, new() { Name = link });
        public ILocator placehold(string place) => page9.GetByPlaceholder(place);
        public ILocator Option(string option) => page9.GetByRole(AriaRole.Option, new() { Name = option }).Locator("a");
        public ILocator Filter(string filt) => page9.Locator("a").Filter(new() { HasText = filt });
        public ILocator Regex(string regex) => page9.Locator("div").Filter(new() { HasTextRegex = new Regex(regex) });
    }
}