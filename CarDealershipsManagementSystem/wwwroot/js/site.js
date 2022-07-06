﻿function showThisHideOthers(id) {
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

function engineTypeOptionChanged(option) {
    var fuelConsumptionInput = document.getElementById("fuelConsumptionInput");
    var energyConsumptionInput = document.getElementById("energyConsumptionInput");
    switch (option.value) {
        case "Benzynowy":
        case "Diesel":
            energyConsumptionInput.classList.add("invisible");
            energyConsumptionInput.classList.add("d-none");

            fuelConsumptionInput.classList.remove("invisible");
            fuelConsumptionInput.classList.remove("d-none");
            break;
        case "Elektryczny":
            fuelConsumptionInput.classList.add("invisible");
            fuelConsumptionInput.classList.add("d-none");

            energyConsumptionInput.classList.remove("invisible");
            energyConsumptionInput.classList.remove("d-none");
            break;
        default:
            energyConsumptionInput.classList.remove("invisible");
            energyConsumptionInput.classList.remove("d-none");
            fuelConsumptionInput.classList.remove("invisible");
            fuelConsumptionInput.classList.remove("d-none");
            break;
    }
}

function generateLogin() {
    var firstName = document.getElementById("firstName");
    var lastName = document.getElementById("lastName");
    var login = document.getElementById("login");
    if (firstName.value && lastName.value)
        if (firstName.value.length >= 3 && lastName.value.length >= 3) {
            var randomNumber = Math.floor(Math.random() * (899)) + 100;
            login.value = firstName.value.substring(0, 3).toLowerCase() + lastName.value.substring(0, 3).toLowerCase() + randomNumber;
        }
}
function generatePass() {
    var pesel = document.getElementById("pesel").value;
    var password = document.getElementById("password");
    if (pesel.length == 11) {
        password.value = pesel;
    }
    var x = ""
}

function docReady(fn) {
    // see if DOM is already available
    if (document.readyState === "complete" || document.readyState === "interactive") {
        // call on next available tick
        setTimeout(fn, 1);
    } else {
        document.addEventListener("DOMContentLoaded", fn);
    }
}


function selectEngine(elementId) {
    var backColour = document.getElementsByClassName("back-background-colour-engine")
    for (let i = 0; i < backColour.length; i++) {
        backColour[i].style.backgroundColor = "coral";
    }

    var s = document.getElementById(elementId).style.backgroundColor = "green";

}
function selectEquipment(elementId) {
    var backColour = document.getElementsByClassName("back-background-colour-equipment")
    for (let i = 0; i < backColour.length; i++) {
        backColour[i].style.backgroundColor = "coral";
    }

    var s = document.getElementById(elementId).style.backgroundColor = "green";

}