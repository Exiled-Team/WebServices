'use strict';

class Navbar {
  constructor(navbarElement) {
    this.navbarElement = navbarElement;
    this.id = navbarElement.getAttribute("data-navbar");
    this.parentHeader = document.querySelector(`[data-header="${this.id}"]`);
    console.log(this.parentHeader);
    this.togglerElement = document.querySelector(`[data-nav-toggler="${this.id}"]`);
    this.nestElement = document.querySelector(`[data-nest="${this.id}"]`);
    this.links = document.querySelectorAll(`[data-link="${this.id}"]`);
    this.togglerElement.addEventListener("click", () => {
      this.toggleVisibility();
    });
  }
  
  toggleVisibility() {
    this.togglerElement.classList.toggle("active");
    this.parentHeader.classList.toggle("open");
    document.body.classList.toggle("nav-active");
    this.navbarElement.classList.toggle("active");
    if (this.navbarElement.classList.contains("active")) {
      this.navbarElement.visibilityState = this.nestElement.visibilityState = "visible";
    } else {
      this.navbarElement.visibilityState = this.nestElement.visibilityState = "hidden";
    }

    this.links.forEach((link) => {
      link.classList.toggle("active");
    });
  }
}

// Select navigation bar and navigation toggler elements
const navbarElements = document.querySelectorAll("[data-navbar]");
console.log(navbarElements.length);
const navbarInit = Array.from(navbarElements).map((navbarElement) => new Navbar(navbarElement));
