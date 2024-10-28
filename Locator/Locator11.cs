using JustFoia.Page;
using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace JustFoia.Locator

{
    public class Locator11
    {
        private readonly IPage _page;
        public Locator11(IPage page)
        {
            _page = page;
        }
        public ILocator Label(string name) => _page.GetByLabel(name);
        public ILocator AriaNewLink(string link) => _page.GetByRole(AriaRole.Link, new() { Name = link });
        public ILocator AriaButton(string button) => _page.GetByRole(AriaRole.Button, new() { Name = button });
        public ILocator GetLabelNew(string desc) => _page.GetByLabel(desc, new() { Exact = true });
        public ILocator AriaRow(string name) => _page.GetByRole(AriaRole.Row, new() { Name = name });
    }
}