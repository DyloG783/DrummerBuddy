var previousScrollTop = 0;

/* hides or shows top navigation when a user is scrolling a layout page */
function getScrollTop() {
    var element = document.getElementById("side-nav-layout-body-container");
    var scrollTop = element.scrollTop;

    if (scrollTop > previousScrollTop) {
        // User is scrolling down
        document.getElementById("nav-scrollable").style = "display: none;";

    }
    else if (scrollTop < previousScrollTop) {
        // User is scrolling up
        document.getElementById("nav-scrollable").style = "display: block;";
    }

    previousScrollTop = scrollTop;
}

/* used in top navigation componenet to hide or show nav on small mobile screens */
function toggleTopNavigation() {

    var navToggler = document.getElementById("navbar-toggler");

    if (navToggler.checked) {
        document.getElementById("nav-scrollable").style = "display: block;";
    }

    if (!navToggler.checked) {
        document.getElementById("nav-scrollable").style = "display: none;";
    }
}

 /* used to close navigation dropdowns after user clicks a navigation link */
function clickTopNavToggler() {
    document.getElementById("navbar-toggler").click();
}


