'use strict';

/**
 * Function to add event listeners to multiple elements
 * @param {NodeList} elements - The elements to which the event listeners will be added
 * @param {string} eventType - The type of event to listen for (e.g., "click")
 * @param {function} callback - The callback function to execute when the event is triggered
 */
const addEventListeners = function (elements, eventType, callback) {
  for (let i = 0, length = elements.length; i < length; i++) {
    elements[i].addEventListener(eventType, callback);
  }
}

/**
 * Activate header and back-to-top button when scrolled down to 100px
 */
const headerElement = document.querySelector("[data-header]");
const backToTopButton = document.querySelector("[data-back-top-btn]");

window.addEventListener("scroll", () => {
  if (window.scrollY > 100) {
    headerElement.classList.add("active");
    backToTopButton.classList.add("active");
  } else {
    headerElement.classList.remove("active");
    backToTopButton.classList.remove("active");
  }
});

document.addEventListener('DOMContentLoaded', function() {
  const dropdowns = document.querySelectorAll('.dropdown');

  dropdowns.forEach(function(dropdown) {
    dropdown.addEventListener('click', function() {
      this.querySelector('.dropdown-menu').classList.toggle('show');
    });
  });
});
