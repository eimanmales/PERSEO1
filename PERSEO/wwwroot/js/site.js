// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//Inicializamos libreria aos
AOS.init();
/*por medio de js seleccionamos nuestros elementos para traer el menu devuelta.*/

let menu = document.getElementById('.navbar-nav');
let menu_bar = document.getElementById('.navbar-toggler');
menu_bar.addEventListener('click', function () {/*Escuchador de los eventos. Cuando escuche el 
                                                evento click va a ejecutar la función().*/
    menu.classList.toggle('menu-toggle');
});