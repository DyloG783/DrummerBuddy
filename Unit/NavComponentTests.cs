using System.Text.RegularExpressions;
using BlazorApp2.Components.Layout;

namespace Unit
{
    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
    /// </summary>
    public class NavComponentTests : TestContext
    {
        [Fact]
        public void TitleExistsInNav()
        {
            // Arrange
            this.AddTestAuthorization();

            // Act
            var cut = RenderComponent<NavMenu>();

            // Assert
            Assert.Matches(cut.Find("a.navbar-brand").InnerHtml, "Drummer Buddies");
        }

        [Fact]
        public void NavLinksArePresent()
        {
            // Arrange
            this.AddTestAuthorization();

            // Act
            var cut = RenderComponent<NavMenu>();
            var navLinks = cut.FindAll(".nav .nav-link");

            Assert.Equal(3, navLinks.Count);
            Assert.Contains("Learn", navLinks[0].InnerHtml);
            Assert.Contains("Kit", navLinks[1].InnerHtml);
            Assert.Contains("Ask", navLinks[2].InnerHtml);
        }

        [Fact]
        public void LearnSubLinksArePresent()
        {
            // Arrange
            this.AddTestAuthorization();

            // Act
            var cut = RenderComponent<NavMenu>();
            var dropDownLinks = cut.FindAll("#learn-dropdown .nav-item");

            Assert.Equal(2, dropDownLinks.Count);
            Assert.Matches(dropDownLinks[0].InnerHtml, "Fundamentals");
            Assert.Matches(dropDownLinks[1].InnerHtml, "Techniques");
        }
    }
}
