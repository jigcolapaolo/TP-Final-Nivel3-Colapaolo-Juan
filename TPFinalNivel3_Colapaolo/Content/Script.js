const hamBurger = document.querySelector(".toggle-btn");

hamBurger.addEventListener("click", function () {
    document.querySelector("#sidebar").classList.toggle("expand");

    const icon = document.querySelector(".toggle-btn i");
    if (sidebar.classList.contains("expand")) {
        // Si la barra lateral se expande, cambia el icono a lni-arrow-left
        icon.classList.remove("bi-arrow-90deg-right");
        icon.classList.add("bi-arrow-90deg-left");
    } else {
        // Si la barra lateral se contrae, cambia el icono a bi-arrow-90deg-right
        icon.classList.remove("bi-arrow-90deg-left");
        icon.classList.add("bi-arrow-90deg-right");
    }

});






