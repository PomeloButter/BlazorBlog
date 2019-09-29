function mobileBtn() {
    var toggleMenu = document.getElementsByClassName("menu-toggle")[0];
    var mobileMenu = document.getElementById("mobile-menu");
    if (toggleMenu.classList.contains("active")) {
        toggleMenu.classList.remove("active");
        mobileMenu.classList.remove("active");
    } else {
        toggleMenu.classList.add("active");
        mobileMenu.classList.add("active");
    }
}