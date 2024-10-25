using Microsoft.Playwright;

namespace JustFoia.Locator
{
    public class Locator7
    {
        private  IPage page7;
        public Locator7(IPage page)
        { 
            page7 = page;   
        }
        public ILocator label(string name) => page7.GetByLabel(name);
        public ILocator Arianewlink(string link) => page7.GetByRole(AriaRole.Link, new() { Name = link});
        public ILocator Ariabutton(string button) => page7.GetByRole(AriaRole.Button, new() { Name = button });
        public ILocator getlabel(string desc) => page7.GetByLabel(desc, new() { Exact = true });
    }
}
