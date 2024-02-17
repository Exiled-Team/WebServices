'use strict';

class ArrowPointer {
  constructor(arrowElement) {
    this.arrowElement = arrowElement;
    this.id = this.arrowElement.getAttribute("data-arrow");
    this.invokers = document.querySelectorAll(`[data-arrow-id="${this.id}"]:not(.arrow-ptr), [data-arrow="${this.id}"]:not(.arrow-ptr)`);
    this.arrows = document.querySelectorAll(`[data-arrow-id="${this.id}"].arrow-ptr`);

    this.invokers.forEach((invoker) => {
      invoker.addEventListener("mouseover", () => {
        this.onMouseOver(this.arrows);
      });
      
      invoker.addEventListener("mouseleave", () => {
        this.onMouseLeave(this.arrows);
      });
    });
  }

  onMouseOver(element) {
    element.classList.add("active");
  }
  
  onMouseOver(elements) {
    elements.forEach((element) => {
      element.classList.add("active");
    });
  }

  onMouseLeave(element) {
    element.classList.remove("active");
  }
  
  onMouseLeave(elements) {
    elements.forEach((element) => {
      element.classList.remove("active");
    });
  }
}

const arrowReflectors = document.querySelectorAll("[data-arrow]");
const arrowInit = Array.from(arrowReflectors).map(arrowElement => new ArrowPointer(arrowElement));

