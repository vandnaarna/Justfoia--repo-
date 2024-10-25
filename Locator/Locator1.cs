using Microsoft.Playwright;

namespace JustFoia.Locator

{
    public class Locator1
    {
        private readonly IPage page1;
        public Locator1(IPage page)
        {
            page1 = page;
        }
        public ILocator lable(string name) => page1.GetByLabel(name);
        public ILocator ariabuttonnew(string log)=> page1.GetByRole(AriaRole.Button, new() { Name = log});
        public ILocator locatorbuttonnew(string button) => page1.Locator("button").Filter(new() { HasText = button });
        public ILocator Arialink(string local) => page1.GetByRole(AriaRole.Link, new() { Name = local });
    }

}
