using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;

public class Tests : PageTest
{
    [Test]
    public async Task MyTest()
    {
        var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        await page.GotoAsync("https://www.saucedemo.com/");

        await page.Locator("[data-test=\"username\"]").FillAsync("standard_user");

        await page.Locator("[data-test=\"password\"]").FillAsync("secret_sauce");
        await page.Locator("[data-test=\"login-button\"]").ClickAsync();
        await Expect(page.Locator("[data-test=\"title\"]")).ToBeVisibleAsync();
        await Expect(page.Locator("[data-test=\"title\"]")).ToContainTextAsync("Products");
        await page.Locator("[data-test=\"item-1-title-link\"]").ClickAsync();
        await Expect(page.GetByText("Sauce Labs Bolt T-ShirtGet")).ToBeVisibleAsync();
        await Expect(page.Locator("[data-test=\"inventory-item\"]")).ToContainTextAsync("Sauce Labs Bolt T-Shirt");
        await page.Locator("[data-test=\"add-to-cart\"]").ClickAsync();
        await Expect(page.Locator("[data-test=\"remove\"]")).ToBeVisibleAsync();
        await Expect(page.Locator("[data-test=\"remove\"]")).ToContainTextAsync("Remove");
        await page.Locator("[data-test=\"shopping-cart-link\"]").ClickAsync();
        await Expect(page.Locator("[data-test=\"title\"]")).ToBeVisibleAsync();
        await Expect(page.Locator("[data-test=\"title\"]")).ToContainTextAsync("Your Cart");
        await Expect(page.Locator("[data-test=\"inventory-item\"]")).ToBeVisibleAsync();
        await Expect(page.Locator("[data-test=\"inventory-item\"]")).ToContainTextAsync("1Sauce Labs Bolt T-ShirtGet your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.$15.99Remove");
        await page.Locator("[data-test=\"checkout\"]").ClickAsync();
        await Expect(page.Locator("[data-test=\"title\"]")).ToBeVisibleAsync();
        await Expect(page.Locator("[data-test=\"title\"]")).ToContainTextAsync("Checkout: Your Information");
        await page.Locator("[data-test=\"firstName\"]").FillAsync("John");
        await page.Locator("[data-test=\"lastName\"]").FillAsync("Smith");
        await page.Locator("[data-test=\"postalCode\"]").FillAsync("100211");
        await page.Locator("[data-test=\"continue\"]").ClickAsync();
        await Expect(page.Locator("[data-test=\"inventory-item\"]")).ToBeVisibleAsync();
        await Expect(page.Locator("[data-test=\"inventory-item\"]")).ToContainTextAsync("1Sauce Labs Bolt T-ShirtGet your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.$15.99");
        await Expect(page.Locator("[data-test=\"total-label\"]")).ToBeVisibleAsync();
        await Expect(page.Locator("[data-test=\"total-label\"]")).ToContainTextAsync("Total: $17.27");
        await page.Locator("[data-test=\"finish\"]").ClickAsync();
        await Expect(page.Locator("[data-test=\"title\"]")).ToBeVisibleAsync();
        await Expect(page.Locator("[data-test=\"title\"]")).ToContainTextAsync("Checkout: Complete!");
        await Expect(page.Locator("[data-test=\"checkout-complete-container\"]")).ToBeVisibleAsync();
        await Expect(page.Locator("[data-test=\"checkout-complete-container\"]")).ToContainTextAsync("Thank you for your order!Your order has been dispatched, and will arrive just as fast as the pony can get there!Back Home");
        await page.GetByRole(AriaRole.Button, new() { Name = "Open Menu" }).ClickAsync();
        await page.Locator("[data-test=\"logout-sidebar-link\"]").ClickAsync();
        await Expect(page.GetByText("Swag Labs")).ToBeVisibleAsync();
        await Expect(page.Locator("#root")).ToContainTextAsync("Swag Labs");
        await Expect(page.Locator("[data-test=\"login-button\"]")).ToBeVisibleAsync();
        await Expect(page.Locator("[data-test=\"login-button\"]")).ToContainTextAsync("Login");
    }
}
