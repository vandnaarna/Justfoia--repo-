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
        private readonly IPage _page;
        public Locator9(IPage page)
        {
            _page = page;
        }
        public ILocator Label(string name) => _page.GetByLabel(name);
        public ILocator GetLabelNew(string desc) => _page.GetByLabel(desc, new() { Exact = true });
        public ILocator AriaButton(string button) => _page.GetByRole(AriaRole.Button, new() { Name = button });
        public ILocator AriaLinkNew(string link) => _page.GetByRole(AriaRole.Link, new() { Name = link });
        public ILocator PlaceHold(string place) => _page.GetByPlaceholder(place);
        public ILocator Option(string option) => _page.GetByRole(AriaRole.Option, new() { Name = option }).Locator("a");
        public ILocator LocatorFilter(string filt) => _page.Locator("a").Filter(new() { HasText = filt });
        public ILocator RegexLocatorFilter(string regex) => _page.Locator("div").Filter(new() { HasTextRegex = new Regex(regex) });
    }
}