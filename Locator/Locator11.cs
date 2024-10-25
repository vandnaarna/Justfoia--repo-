using JustFoia.Page;
using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace JustFoia.Locator

{
    public class Locator11
    {
        private readonly IPage page11;
        public Locator11(IPage page)
        {
            page11 = page;
        }
        public ILocator label(string name) => page11.GetByLabel(name);
        public ILocator Arianewlink(string link) => page11.GetByRole(AriaRole.Link, new() { Name = link });
        public ILocator Ariabutton(string button) => page11.GetByRole(AriaRole.Button, new() { Name = button });
        public ILocator getlabel(string desc) => page11.GetByLabel(desc, new() { Exact = true });
        public ILocator Ariarow(string name) => page11.GetByRole(AriaRole.Row, new() { Name = name });
    }
}