using JustFoia.Page;
using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace JustFoia.Locator

{
    public class Locator10
    {
        private readonly IPage page10;
        public Locator10(IPage page)
        {
            page10 = page;
        }
        public ILocator label(string name) => page10.GetByLabel(name);
        public ILocator Arianewlink(string link) => page10.GetByRole(AriaRole.Link, new() { Name = link });
        public ILocator Ariabutton(string button) => page10.GetByRole(AriaRole.Button, new() { Name = button });
        public ILocator getlabel(string desc) => page10.GetByLabel(desc, new() { Exact = true });
        public ILocator Ariarow(string name) => page10.GetByRole(AriaRole.Row, new() { Name = name });

    }
}