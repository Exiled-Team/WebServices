'use strict';

class Slider {
    constructor(sliderElement) {
        this.sliderContainer = sliderElement.querySelector("[data-slider-container]");
        this.sliderId = sliderElement.dataset.sliderId;

        this.visibleItemCount = Number(getComputedStyle(this.sliderContainer).getPropertyValue("--slider-items"));
        this.totalItems = this.sliderContainer.childElementCount - this.visibleItemCount;
        this.currentPosition = 0;

        this.prevButton = document.querySelector(`[data-slider-id="${this.sliderId}"][aria-label="previous"]`);
        this.nextButton = document.querySelector(`[data-slider-id="${this.sliderId}"][aria-label="next"]`);

        this.prevButton.addEventListener("click", () => this.slidePrev());
        this.nextButton.addEventListener("click", () => this.slideNext());

        window.addEventListener("resize", () => this.moveSliderItem());

        this.sliderContainer.addEventListener('touchstart', this.handleTouchStart.bind(this));
        this.sliderContainer.addEventListener('touchmove', this.handleTouchMove.bind(this));
        this.sliderContainer.addEventListener('touchend', this.handleTouchEnd.bind(this));
        this.sliderContainer.addEventListener('mousedown', this.handleMouseDown.bind(this));
        window.addEventListener('mousemove', this.handleMouseMove.bind(this));
        window.addEventListener('mouseup', this.handleMouseUp.bind(this));

        let isDragging = false;

        sliderElement.addEventListener('mousedown', () => {
            isDragging = true;
            sliderElement.style.pointerEvents = 'none';
        });

        sliderElement.addEventListener('mouseup', () => {
            isDragging = false;
            sliderElement.style.pointerEvents = 'auto';
        });

        sliderElement.addEventListener('mouseleave', () => {
            if (isDragging) {
                isDragging = false;
                sliderElement.style.pointerEvents = 'auto';
            }
        });
    }

    moveSliderItem() {
        this.sliderContainer.style.transform = `translateX(-${this.sliderContainer.children[this.currentPosition].offsetLeft}px)`;
    }

    slideNext() {
        this.currentPosition = (this.currentPosition >= this.totalItems) ? 0 : this.currentPosition + 1;
        this.moveSliderItem();
    }

    slidePrev() {
        this.currentPosition = (this.currentPosition <= 0) ? this.totalItems : this.currentPosition - 1;
        this.moveSliderItem();
    }

    handleMouseDown(event) {
        event.preventDefault();
        this.mouseStartX = event.clientX;
        this.isDragging = true;
    }

    handleMouseMove(event) {
        event.preventDefault();
        if (this.isDragging) {
            this.mouseEndX = event.clientX;
        }
    }

    handleMouseUp(event) {
        event.preventDefault();
        this._event = event;
        if (this.isDragging) {
            const mouseDeltaX = this.mouseEndX - this.mouseStartX;
            const mouseSwipeThreshold = 50;
            if (mouseDeltaX > mouseSwipeThreshold) {
                this.slidePrev();
            } else if (mouseDeltaX < -mouseSwipeThreshold) {
                this.slideNext();
            }
            this.isDragging = false;
        }
    }
    
    handleTouchStart(event) {
        this.touchStartX = event.touches[0].clientX;
        this.touchStartY = event.touches[0].clientY;
    }

    handleTouchMove(event) {
        this.touchEndX = event.touches[0].clientX;
        this.touchEndY = event.touches[0].clientY;
        this.swipeDirection = this.getSwipeDirection();
    }

    handleTouchEnd(event) {
        this._event = event;
        const swipeThreshold = 50;
        if (this.swipeDirection === 'left' && Math.abs(this.touchStartX - this.touchEndX) > swipeThreshold) {
            this.slideNext();
        } else if (this.swipeDirection === 'right' && Math.abs(this.touchStartX - this.touchEndX) > swipeThreshold) {
            this.slidePrev();
        }
    }

    getSwipeDirection() {
        const deltaX = this.touchEndX - this.touchStartX;
        const deltaY = this.touchEndY - this.touchStartY;
        if (Math.abs(deltaX) > Math.abs(deltaY)) {
            return (deltaX > 0) ? 'right' : 'left';
        }
        return null;
    }
}

const sliderElements = document.querySelectorAll("[data-slider]");
Array.from(sliderElements).map((sliderElement) => new Slider(sliderElement));