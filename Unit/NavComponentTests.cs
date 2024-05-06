
using BlazorApp2.Components.Layout;

namespace Unit
{
    public class NavComponentTests : TestContext
    {
        [Fact]
        public void TitleExistsInNav()
        {
            this.AddTestAuthorization();

            var cut = RenderComponent<NavMenu>();

            Assert.Equal("Drummer", cut.Find(".navbar-brand span:nth-child(1)").TextContent);
            Assert.Equal(" Buddies", cut.Find(".navbar-brand span:nth-child(2)").TextContent);
        }

        [Fact]
        public void NavLinksArePresent()
        {
            this.AddTestAuthorization();

            var cut = RenderComponent<NavMenu>();
            var navLinks = cut.FindAll(".nav > .nav-item");

            Assert.Equal(3, navLinks.Count);
            Assert.Contains("Learn", navLinks[0].InnerHtml);
            Assert.Contains("Kit", navLinks[1].InnerHtml);
            Assert.Contains("Ask", navLinks[2].InnerHtml);
        }

        [Fact]
        public void LearnSubLinksArePresent()
        {
            this.AddTestAuthorization();

            var cut = RenderComponent<NavMenu>();
            var dropDownLinks = cut.FindAll("#learn-dropdown > li > a");

            Assert.Equal(3, dropDownLinks.Count);
            Assert.Contains("Fundamentals", dropDownLinks[0].InnerHtml);
            Assert.Contains("Techniques", dropDownLinks[1].InnerHtml);
            Assert.Contains("Inspiration", dropDownLinks[2].InnerHtml);
        }

        [Fact]
        public void SignedOutStateShowsLoginLink()
        {
            this.AddTestAuthorization();

            var cut = RenderComponent<NavMenu>();
            var userMenu = cut.Find("#user-menu-container > .nav-item > .nav-link");

            Assert.Contains("Login", userMenu.InnerHtml);
            
        }

        [Fact]
        public void SignedInStateShowsUserMenu()
        {
            var authContext = this.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER");

            var cut = RenderComponent<NavMenu>();
            var userMenu = cut.Find("#user-menu-container .dropdown-toggle");

            Assert.Contains("TEST USER", userMenu.InnerHtml);
        }

        [Fact]
        public void SignedInStateDropdownShowsUserMenuItems()
        {
            var authContext = this.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER");

            var cut = RenderComponent<NavMenu>();
            var userMenuLinks = cut.FindAll("#user-dropdown > .dropdown-menu > .nav-item");

            Assert.Equal(2, userMenuLinks.Count);
            Assert.Contains("Account", userMenuLinks[0].InnerHtml);
            Assert.Contains("Logout", userMenuLinks[1].InnerHtml);
        }
    }
}
