using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JustFoia.Locator
{
   public  class LocatorOne
   {
        private readonly IPage _page;

        public LocatorOne( IPage page) 
        {
            _page = page;
        }
        public ILocator locator(string name) =>
          _page.GetByRole(AriaRole.Button, new() { Name = name, Exact = true });

        public ILocator GetLocator12(string loc) =>
         _page.GetByLabel("Holiday Name");
    }
}
