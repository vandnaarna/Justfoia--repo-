using JustFoia.Page;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace JustFoia.Locator
{
    public class Locator12
    {
        private readonly IPage _page;
        public Locator12(IPage page)
        {
            _page = page;
        }
        public ILocator Label(string name) => _page.GetByLabel(name);
        public ILocator AriaNewLink(string link) => _page.GetByRole(AriaRole.Link, new() { Name = link });
        public ILocator AriaButton(string button) => _page.GetByRole(AriaRole.Button, new() { Name = button });
        public ILocator GetLabel(string desc) => _page.GetByLabel(desc, new() { Exact = true });
        public ILocator AriaRow(string name) => _page.GetByRole(AriaRole.Row, new() { Name = name });
        public ILocator Regex(string regex) => _page.Locator("div").Filter(new() { HasTextRegex = new Regex(regex) });
        public ILocator Filter(string filt) => _page.Locator("a").Filter(new() { HasText = filt });
        public ILocator PlaceHold(string place) => _page.GetByPlaceholder(place);
    }
}