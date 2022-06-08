// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function showThisHideOthers(id) {
    const buttons = document.getElementsByClassName("car-type-button")
    const sections = document.getElementsByClassName("car-type-section")

    Array.from(buttons).forEach(element => element.classList.remove("font-weight-bold"))
    document.getElementById(id).classList.add("font-weight-bold")

    if (id != "all") {
        Array.from(sections).forEach(element => element.classList.add("invisible"))
        Array.from(sections).forEach(element => element.classList.add("d-none"))
        Array.from(sections).forEach(element => element.classList.remove("d-flex"))

        var sectionToShow = id + "-section"
        document.getElementById(sectionToShow).classList.remove("invisible");
        document.getElementById(sectionToShow).classList.remove("d-none");
        document.getElementById(sectionToShow).classList.add("d-flex");
    } else {
        Array.from(sections).forEach(element => element.classList.remove("invisible"))
        Array.from(sections).forEach(element => element.classList.remove("d-none"))
        Array.from(sections).forEach(element => element.classList.add("d-flex"))
    }
}