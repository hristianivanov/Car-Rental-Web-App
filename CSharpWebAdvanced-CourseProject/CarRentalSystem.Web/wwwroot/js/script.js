(function ($) {
  "use strict";

  $(document).ready(function () {
      // Initialize the rental swiper
      var rentalSwiper = new Swiper(".rental-swiper", {
          slidesPerView: 3,
          spaceBetween: 30,
          freeMode: true,
          navigation: {
              nextEl: ".rental-swiper-next",
              prevEl: ".rental-swiper-prev",
          },
          breakpoints: {
              0: {
                  slidesPerView: 1,
                  spaceBetween: 20,
              },
              768: {
                  slidesPerView: 2,
                  spaceBetween: 30,
              },
              1400: {
                  slidesPerView: 3,
                  spaceBetween: 30,
              },
          },
      });
  });
})(jQuery);