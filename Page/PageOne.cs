using JustFoia.Locator;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;



namespace JustFoia.Page
{

    public class PageOne
    {
        private LocatorOne _loc;
        private IPage _page;

        public PageOne(IPage page)
        {
            _page = page;
            _loc = new LocatorOne(_page);
        }
        public async Task TestCase1()
        {
            await _page.GotoAsync("https://qa1auto.devjustfoia.com/Account/Login?ReturnUrl=%2FHolidays%2FList");
            await _page.GetByLabel("User Name").ClickAsync();
            await _page.GetByLabel("User Name").FillAsync("MCCi1");

            await _page.GetByLabel("Password").ClickAsync();

            await _page.GetByLabel("Password").FillAsync("Y*5e4b%J9bov46e5");

            await _page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            await _page.Locator("#main-content").GetByText("arrow_drop_down").ClickAsync();
            await _page.Locator("a").Filter(new() { HasText = "All" }).ClickAsync();

            await _page.GetByLabel("Profile options").ClickAsync();

            await _page.GetByRole(AriaRole.Link, new() { Name = "Holidays" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Add New" }).ClickAsync();

            await _page.GetByLabel("Holiday Name").ClickAsync();

            DateTime dateTime = DateTime.Now;

            string holidayName = "TestHoliday" + dateTime.ToString().Replace(":", "").Replace(" ","").Replace("/", "");

             
           await _loc.GetLocator12("Holiday Name").FillAsync(holidayName);
            await _page.GetByLabel("Holiday Date").ClickAsync();


            Random random = new Random();
           
            int day =  random.Next(1, 30);

           int month = random.Next(1, 12); 

            for (int i = 0; i < month; i++)
            {
                await _page.Locator("button").Filter(new() { HasText = "chevron_left" }).First.ClickAsync();

                //// Optionally, add a delay between clicks to simulate more natural behavior
                //await Task.Delay(random.Next(500, 1000)); // Random delay between 500ms and 1000ms
            }

          await _page.GetByRole(AriaRole.Button, new(){ Name = day.ToString(), Exact = true}).First.ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

            
            await _page.GetByRole(AriaRole.Row, new() { Name = holidayName })
            .GetByRole(AriaRole.Button).First.ClickAsync();

            await _page.GetByLabel("Holiday Name").ClickAsync();
            DateTime dateTime1 = DateTime.Now;

            string holidayName2 = "EditHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");

            await _loc.GetLocator12("Holiday Name").FillAsync(holidayName2);
            await _page.GetByLabel("Holiday Date").ClickAsync();

          for (int i = 0; i <month; i++)
            {
                await _page.Locator("button").Filter(new() { HasText = "chevron_left" }).First.ClickAsync();
            }
         await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true })
                .First.ClickAsync();


            await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

            

            await _page.GetByLabel("Filter").ClickAsync();
            await _page.GetByLabel("Filter").FillAsync(holidayName2);
            await _page.GetByLabel("Filter").PressAsync("Enter");
          
            await _page.Locator("button").Filter(new() { HasText = "archive" }).ClickAsync();
           

            await _page.GetByRole(AriaRole.Button, new() { Name = "Yes" }).First.ClickAsync();
        }
        public async Task TestCase2()
        {
           
            await _page.GotoAsync("https://qa1auto.devjustfoia.com/Account/Login?ReturnUrl=%2FHolidays%2FList");
            await _page.GetByLabel("User Name").ClickAsync();
            await _page.GetByLabel("User Name").FillAsync("MCCi1");

            await _page.GetByLabel("Password").ClickAsync();

            await _page.GetByLabel("Password").FillAsync("Y*5e4b%J9bov46e5");

            await _page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            await _page.Locator("#main-content").GetByText("arrow_drop_down").ClickAsync();
            await _page.Locator("a").Filter(new() { HasText = "All" }).ClickAsync();

            await _page.GetByLabel("Profile options").ClickAsync();

            await _page.GetByRole(AriaRole.Link, new() { Name = "Holidays" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Add New" }).ClickAsync();

            await _page.GetByLabel("Holiday Name").ClickAsync();

            DateTime dateTime = DateTime.Now;

            string holidayName = "TestHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");


            await _loc.GetLocator12("Holiday Name").FillAsync(holidayName);
            await _page.GetByLabel("Holiday Date").ClickAsync();


            Random random = new Random();

            int day = random.Next(1, 30);
            int month = random.Next(1, 12); 

            for (int i = 0; i < month; i++)
            {
                await _page.Locator("button").Filter(new() { HasText = "chevron_left" }).First.ClickAsync();

                // Optionally, add a delay between clicks to simulate more natural behavior
                await Task.Delay(random.Next(500, 1000)); // Random delay between 500ms and 1000ms
            }

            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
          
        }
    public async Task TestCase3()
        {
          
            await _page.GotoAsync("https://qa1auto.devjustfoia.com/Account/Login?ReturnUrl=%2FHolidays%2FList");
            await _page.GetByLabel("User Name").ClickAsync();
            await _page.GetByLabel("User Name").FillAsync("MCCi1");

            await _page.GetByLabel("Password").ClickAsync();

            await _page.GetByLabel("Password").FillAsync("Y*5e4b%J9bov46e5");

            await _page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            await _page.Locator("#main-content").GetByText("arrow_drop_down").ClickAsync();
            await _page.Locator("a").Filter(new() { HasText = "All" }).ClickAsync();

            await _page.GetByLabel("Profile options").ClickAsync();

            await _page.GetByRole(AriaRole.Link, new() { Name = "Holidays" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Add New" }).ClickAsync();

            await _page.GetByLabel("Holiday Name").ClickAsync();

            DateTime dateTime = DateTime.Now;

            string holidayName = "TestHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");


            await _loc.GetLocator12("Holiday Name").FillAsync(holidayName);
            await _page.GetByLabel("Holiday Date").ClickAsync();


            Random random = new Random();


            int day = random.Next(1, 30);
            int month = random.Next(1, 12); // Generates a random number between 1 and 10

            for (int i = 0; i < month; i++)
            {
                await _page.Locator("button").Filter(new() { HasText = "chevron_left" }).First.ClickAsync();

                // Optionally, add a delay between clicks to simulate more natural behavior
                await Task.Delay(random.Next(500, 1000)); // Random delay between 500ms and 1000ms
            }

            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();


            await _page.GetByRole(AriaRole.Row, new() { Name = holidayName })
            .GetByRole(AriaRole.Button).First.ClickAsync();

            await _page.GetByLabel("Holiday Name").ClickAsync();
            DateTime dateTime1 = DateTime.Now;

            string holidayName2 = "EditHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");

            await _loc.GetLocator12("Holiday Name").FillAsync(holidayName2);
            await _page.GetByLabel("Holiday Date").ClickAsync();
         
            for (int i = 0; i < month; i++)
            {
                await _page.Locator("button").Filter(new() { HasText = "chevron_left" }).First.ClickAsync();
            }
            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();


            await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
         }
         
        public async Task TestCase4()
        {

            
            await _page.GotoAsync("https://qa1auto.devjustfoia.com/Account/Login?ReturnUrl=%2FHolidays%2FList");
            await _page.GetByLabel("User Name").ClickAsync();
            await _page.GetByLabel("User Name").FillAsync("MCCi1");

            await _page.GetByLabel("Password").ClickAsync();

            await _page.GetByLabel("Password").FillAsync("Y*5e4b%J9bov46e5");

            await _page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            await _page.Locator("#main-content").GetByText("arrow_drop_down").ClickAsync();
            await _page.Locator("a").Filter(new() { HasText = "All" }).ClickAsync();

            await _page.GetByLabel("Profile options").ClickAsync();

            await _page.GetByRole(AriaRole.Link, new() { Name = "Holidays" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Add New" }).ClickAsync();

            await _page.GetByLabel("Holiday Name").ClickAsync();

            DateTime dateTime = DateTime.Now;

            string holidayName = "TestHoliday" + dateTime.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");


            await _loc.GetLocator12("Holiday Name").FillAsync(holidayName);
            await _page.GetByLabel("Holiday Date").ClickAsync();


            Random random = new Random();

            int day = random.Next(1, 30);

            int month = random.Next(1, 12); // Generates a random number between 1 and 10

            for (int i = 0; i<month ; i++)
            {
                await _page.Locator("button").Filter(new() { HasText = "chevron_left" }).First.ClickAsync();

                //// Optionally, add a delay between clicks to simulate more natural behavior
                //await Task.Delay(random.Next(500, 1000)); // Random delay between 500ms and 1000ms
            }

            await _page.GetByRole(AriaRole.Button, new() { Name = day.ToString(), Exact = true }).First.ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

            await _page.PauseAsync();

            await _page.GetByLabel("Filter").ClickAsync();
            await _page.GetByLabel("Filter").FillAsync(holidayName);
            await _page.GetByLabel("Filter").PressAsync("Enter");


            await _page.Locator("button").Filter(new() { HasText = "archive" }).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "No" }).ClickAsync();
            await _page.Locator("button").Filter(new() { HasText = "archive" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "Yes" }).ClickAsync();

         }
        public async Task TestCase5()
        {
            await _page.PauseAsync();
            await _page.GotoAsync("https://qa1auto.devjustfoia.com/Account/Login?ReturnUrl=%2FHolidays%2FList");
            await _page.GetByLabel("User Name").ClickAsync();
            await _page.GetByLabel("User Name").FillAsync("MCCi1");
            await _page.GetByLabel("Password").ClickAsync();

            //await _page.GetByText("lockPasswordvisibility_off").ClickAsync();

            await _page.GetByLabel("Password").FillAsync("Y*5e4b%J9bov46e5");
            await _page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            await _page.GetByLabel("Profile options").ClickAsync();
            await _page.GetByRole(AriaRole.Link, new() { Name = "Holidays" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "Add New" }).ClickAsync();
            await _page.GetByLabel("Holiday Name").ClickAsync();

            DateTime dateTime = DateTime.Now;

            
         string name = "Testone" + dateTime.ToString().Replace(":","").Replace("/","").Replace(" ","");

            await _page.GetByLabel("Holiday Name").FillAsync(name);
            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
            await _page.GetByLabel("Holiday Name").ClickAsync();
            await _page.GetByLabel("Holiday Name").ClearAsync();
            await _page.GetByLabel("Holiday Date").ClickAsync();

            Random random = new Random();

            int date = random.Next(1,30);
            int  month = random.Next(1,12);

           for (int i = 0; i < month; i++)
            {
                await _page.Locator("button").Filter(new() { HasText = "chevron_left" }).First.ClickAsync();
            }
          await _page.GetByRole(AriaRole.Button, new() { Name = date.ToString(), Exact = true }).First.ClickAsync();

        //await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
         await _page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Save$") }).First.ClickAsync();

            
          
        }


    }


}





