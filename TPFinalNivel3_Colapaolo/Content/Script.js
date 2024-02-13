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

function clickFavorito(elemento) {
    // Si la clase actual es "bi bi-star", la cambio a "bi bi-star-fill"
    if (elemento.classList.contains("bi-star")) {
        elemento.classList.remove("bi-star");
        elemento.classList.add("bi-star-fill");
    } else {
        // Si la clase actual es diferente de "bi bi-star", la cambiamos a "bi bi-star"
        elemento.classList.remove("bi-star-fill");
        elemento.classList.add("bi-star");
    }
}






