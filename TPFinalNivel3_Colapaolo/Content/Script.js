const hamBurger = document.querySelector(".toggle-btn");

hamBurger.addEventListener("click", function () {

    document.querySelector("#sidebar").classList.toggle("expand");
    const body = document.querySelector("body");
    const sidebarOverlay = document.querySelector("#sidebarOverlay");

    body.classList.toggle("sidebar-expanded");

    const icon = document.querySelector(".toggle-btn i");
    const sidebarNav = document.querySelector(".sidebar-nav");

    if (sidebar.classList.contains("expand")) {
        // Si la barra lateral se expande, cambia el icono a lni-arrow-left
        icon.classList.remove("bi-arrow-90deg-right");
        icon.classList.add("bi-arrow-90deg-left");

        // Scroll para los elementos del sidebar
        sidebarNav.classList.add("sidebar-nav-scroll");
        // Efecto offcanvas al abrir sidebar
        sidebarOverlay.style.backgroundColor = "rgba(0, 0, 0, 0.5)";
    } else {
        // Si la barra lateral se contrae, cambia el icono a bi-arrow-90deg-right
        icon.classList.remove("bi-arrow-90deg-left");
        icon.classList.add("bi-arrow-90deg-right");

        // Scroll para los elementos del sidebar
        sidebarNav.classList.remove("sidebar-nav-scroll");
        // Efecto offcanvas al cerrar sidebar
        sidebarOverlay.style.backgroundColor = "rgba(0, 0, 0, 0)";
    }

});


function clickFavorito(elemento) {
    // Si la clase actual es "bi bi-star", se cambia a "bi bi-star-fill"
    if (elemento.classList.contains("bi-star")) {
        elemento.classList.remove("bi-star");
        elemento.classList.add("bi-star-fill");
    } else {
        // Si la clase actual es diferente de "bi bi-star", se cambia a "bi bi-star"
        elemento.classList.remove("bi-star-fill");
        elemento.classList.add("bi-star");
    }
}



//Efecto offcanvas del toggler del navbar
const navbarToggler = document.querySelector(".navbar-toggler");
const sidebarOverlay = document.querySelector("#sidebarOverlay");

navbarToggler.addEventListener("click", function () {
    const body = document.querySelector("body");

    body.classList.toggle("sidebar-expanded");

    if (body.classList.contains("sidebar-expanded") || sidebar.classList.contains("expand")) {
        sidebarOverlay.style.backgroundColor = "rgba(0, 0, 0, 0.5)";
    } else {
        sidebarOverlay.style.backgroundColor = "rgba(0, 0, 0, 0)";
    }
});


//Cierre del sidebar y navbar y quito el offcanvas al clickear en el mainContainer
const mainContainer = document.querySelector("#mainContainer");
const togglerButton = document.querySelector(".navbar-toggler");
mainContainer.addEventListener("click", function () {

    const body = document.querySelector("body");

    if (sidebarOverlay.style.backgroundColor == "rgba(0, 0, 0, 0.5)") {

        sidebarOverlay.style.backgroundColor = "rgba(0, 0, 0, 0)";

        if (navbarTop.classList.contains("show") && sidebar.classList.contains("expand")) {
            togglerButton.click();
            hamBurger.click();
        }

        if (navbarTop.classList.contains("show")) {
            togglerButton.click();
        }

        if (sidebar.classList.contains("expand")) {
            hamBurger.click();
        }
    }
})


//Cierro todas las barras al cambiar de tamaño la pantalla 
window.addEventListener('resize', function () {
    mainContainer.click();
});